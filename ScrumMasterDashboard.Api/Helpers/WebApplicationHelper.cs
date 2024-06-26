﻿using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ScrumMasterDashboard.Api.DataAccess;
using ScrumMasterDashboard.Api.Exceptions;
using ScrumMasterDashboard.Api.Models.AppSettings;
using ScrumMasterDashboard.Api.Models.Enums;
using ScrumMasterDashboard.Api.Resources;
using System.Reflection;

namespace ScrumMasterDashboard.Api.Helpers
{
	public static class WebApplicationHelper
	{
		/// <summary>
		/// Adds API versioning to the application
		/// </summary>
		public static void AddVersioning(this IServiceCollection services)
		{
			services.AddApiVersioning(options =>
			{
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.ReportApiVersions = true; //Adds headers "api-supported-versions" and "api-deprecated-versions" to the response
				options.ApiVersionReader = ApiVersionReader.Combine(
					new HeaderApiVersionReader("api-version"), //Reads request the header "api-version"
					new QueryStringApiVersionReader("api-version") //Reads the query string parameter "api-version"
				);
			})
			.AddApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});
		}

		/// <summary>
		/// Adds the database context and connection for <see cref="DatabaseContext"/>.
		/// </summary>
		/// <param name="services"></param>
		public static void AddDatabaseContext(this IServiceCollection services)
		{
			AppSettings appSettings = services.BuildServiceProvider().GetRequiredService<IOptions<AppSettings>>().Value;

			services.AddDbContext<DatabaseContext>(options =>
			{
				options.UseSqlServer(appSettings.ConnectionStrings.Database, sqlServerOptions =>
				{
					sqlServerOptions.EnableRetryOnFailure(
						maxRetryCount: 5,
						maxRetryDelay: TimeSpan.FromSeconds(20),
						errorNumbersToAdd: null
					);
				});
			});
		}

		/// <summary>
		/// Adds all the swagger documents to the API for each ApiVersion.
		/// </summary>
		/// <param name="services"></param>
		public static void AddSwagger(this IServiceCollection services)
		{
			IReadOnlyList<ApiVersionDescription> apiDescriptiontions = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions;
			AppSettings appSettings = services.BuildServiceProvider().GetRequiredService<IOptions<AppSettings>>().Value;

			services.AddSwaggerGen(options =>
			{
				foreach (ApiVersionDescription apiDescriptiontion in apiDescriptiontions)
				{
					var openApiInfo = new OpenApiInfo
					{
						Title = $"{appSettings.AppName} {apiDescriptiontion.GroupName.ToUpperInvariant()}",
						Version = apiDescriptiontion.ApiVersion.ToString(),
						Description = apiDescriptiontion.IsDeprecated ? "This version has been deprecated." : string.Empty
					};

					options.SwaggerDoc(apiDescriptiontion.GroupName, openApiInfo);
				}
			});
		}

		/// <summary>
		/// Adds dependency injection with scoped lifetime to all collectiontypes contained within <see cref="CollectionType"/>.
		/// </summary>
		/// <param name="services"></param>
		public static void AddDependencyInjection(this IServiceCollection services)
		{
			var collectionTypes = Enum.GetValues(typeof(CollectionType)).Cast<CollectionType>();

			foreach (CollectionType collectionType in collectionTypes)
			{
				ApplyDependencyInjection(services, collectionType);
			}
		}

		/// <summary>
		/// Applies dependency injection to all assembly classes that require it, with scoped lifetime.
		/// </summary>
		/// <param name="services"></param>
		/// <param name="collectionType">Type of collection to implement dependency injection for.</param>
		private static void ApplyDependencyInjection(IServiceCollection services, CollectionType collectionType)
		{
			IEnumerable<Type> classesThatImplementsAnInterface = AssemblyTypesThatImplementsInterfaces(collectionType);

			foreach (Type classType in classesThatImplementsAnInterface)
			{
				var implementedInterfaces = classType.GetInterfaces();

				foreach (Type interfaceType in implementedInterfaces)
				{
					services.AddScoped(interfaceType, classType);
				}
			}
		}

		/// <summary>
		/// Uses <see cref="Assembly.GetExecutingAssembly"/> to find all types within the application that fits the following criteria:<br/>
		/// - Is a class.<br/>
		/// - Implements at least one interface.<br/>
		/// - <paramref name="collectionType"/> is contained within it's typename.
		/// </summary>
		/// <param name="collectionType">Assumes the class contains this type in it's name.</param>
		/// <returns>An IEnumerable with all types in assembly that requires dependency injection.</returns>
		private static IEnumerable<Type> AssemblyTypesThatImplementsInterfaces(CollectionType collectionType)
		{
			IEnumerable<Type> classesThatImplementsAnInterface = Assembly
				.GetExecutingAssembly()
				.GetTypes()
				.Where(type => type.IsClass &&
					type.GetInterfaces().Length > 0 &&
					type.Name.Contains(collectionType.ToString(), StringComparison.InvariantCultureIgnoreCase)
				);

			return classesThatImplementsAnInterface;
		}

		/// <summary>
		/// Adds request localization resourcepath and <see cref="RequestLocalizationOptions"/> to the application.<br/><br/>
		/// Assues that the resource files are located in a project root-folder named "Resources".
		/// </summary>
		/// <param name="services"></param>
		public static void AddLocalizationCultures(this IServiceCollection services)
		{
			services.AddLocalization(options => options.ResourcesPath = "Resources");

			services.Configure<RequestLocalizationOptions>(configureOptions =>
			{
				configureOptions = SupportedCultures.LocalizationOptions;
			});
		}

		/// <summary>
		/// Adds global error handling with <see cref="GlobalExceptionHandler"/> and <see cref="ProblemDetails"/>.
		/// </summary>
		public static void AddExceptionHandling(this IServiceCollection services)
		{
			services.AddExceptionHandler<GlobalExceptionHandler>();
			services.AddProblemDetails();
		}

		/// <summary>
		/// Applies UseSwagger and UseSwaggerUI to the application.<br/>
		/// Creates swagger endpoints for each ApiVersion.
		/// </summary>
		/// <param name="app"></param>
		public static void ApplySwagger(this WebApplication app)
		{
			AppSettings appSettings = app.Configuration.Get<AppSettings>() ?? new AppSettings();
			IReadOnlyList<ApiVersionDescription> apiDescriptiontions = app.DescribeApiVersions();

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				foreach (ApiVersionDescription apiDescriptiontion in apiDescriptiontions)
				{
					string url = $"/swagger/{apiDescriptiontion.GroupName}/swagger.json";
					string name = apiDescriptiontion.GroupName.ToUpperInvariant();

					options.SwaggerEndpoint(url, name);
				}
			});
		}

		/// <summary>
		/// Applies the configured <see cref="RequestLocalizationOptions"/> via UseRequestLocalization to the application.
		/// </summary>
		/// <param name="app"></param>
		public static void UseLocalization(this WebApplication app)
		{
			RequestLocalizationOptions? localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>()?.Value;

			app.UseRequestLocalization(localizationOptions ?? SupportedCultures.LocalizationOptions);
		}
	}
}

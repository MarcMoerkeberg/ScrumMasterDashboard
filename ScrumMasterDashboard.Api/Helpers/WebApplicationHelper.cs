using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ScrumMasterDashboard.Api.Models.AppSettings;

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
	}
}

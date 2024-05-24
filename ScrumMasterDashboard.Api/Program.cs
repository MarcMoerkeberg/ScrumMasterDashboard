using ScrumMasterDashboard.Api.Helpers;
using ScrumMasterDashboard.Api.Models.AppSettings;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AppSettings>(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVersioning();
builder.Services.AddSwagger();
builder.Services.AddDatabaseContext();
builder.Services.AddDependencyInjection();
builder.Services.AddLocalizationCultures();
builder.Services.AddExceptionHandling();

WebApplication app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.ApplySwagger();
app.UseLocalization();
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.Run();
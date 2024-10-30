using SmartMed.Application;
using SmartMed.RestApi.Configs.Services;

var builder = WebApplication.CreateBuilder(args);
var config = GetEnvironment();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
{
    builder.Services.RegisterApplicationServices();
}
builder.Host.AddAutofacConfig(config);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

static IConfigurationRoot GetEnvironment(
    string settingFileName = "appsettings.json")
{
    var baseDirectory = Directory.GetCurrentDirectory();

    return new ConfigurationBuilder()
        .SetBasePath(baseDirectory)
        .AddJsonFile(settingFileName, optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();
}
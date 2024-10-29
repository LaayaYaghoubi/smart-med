using SmartMed.RestApi.Configs.Services;

var builder = WebApplication.CreateBuilder(args);
var config = GetEnvironment();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Host.AddAutofacConfig(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
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
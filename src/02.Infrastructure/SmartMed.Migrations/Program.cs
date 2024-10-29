using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartMed.Migrations;

var options = GetSettings(args, Directory.GetCurrentDirectory());

var connectionString = options.ConnectionString;

CreateDatabase(connectionString);
var runner = CreateRunner(connectionString, options);

runner.MigrateUp();

static void CreateDatabase(string connectionString)
{
    var databaseName = GetDatabaseName(connectionString);
    string masterConnectionString =
        ChangeDatabaseName(connectionString, "master");
    var commandScript =
        $"if db_id(N'{databaseName}') is null create database [{databaseName}]";

    using var connection = new SqlConnection(masterConnectionString);
    using var command = new SqlCommand(commandScript, connection);
    connection.Open();
    command.ExecuteNonQuery();
    connection.Close();
}

static string ChangeDatabaseName(string connectionString,
    string databaseName)
{
    var csb = new SqlConnectionStringBuilder(connectionString)
    {
        InitialCatalog = databaseName
    };
    return csb.ConnectionString;
}

static string GetDatabaseName(string connectionString)
{
    return new SqlConnectionStringBuilder(connectionString)
        .InitialCatalog;
}


static IMigrationRunner CreateRunner(string connectionString,
    MigrationSettings options)
{
    var container = new ServiceCollection()
        .AddFluentMigratorCore()
        .ConfigureRunner(_ => _
            .AddSqlServer()
            .WithGlobalConnectionString(connectionString)
            .ScanIn(typeof(Program).Assembly).For.All())
        .AddSingleton(options)
        .AddLogging(_ => _.AddFluentMigratorConsole())
        .BuildServiceProvider();
    return container.GetRequiredService<IMigrationRunner>();
}

static MigrationSettings GetSettings(string[] args,
    string baseDir)
{
    var configurations = new ConfigurationBuilder()
        .SetBasePath(baseDir)
        .AddJsonFile("appsettings.json", optional: true,
            reloadOnChange: true)
        .AddEnvironmentVariables()
        .AddCommandLine(args)
        .Build();

    var settings = new MigrationSettings
    {
        ConnectionString =
            configurations.GetValue<string>("connectionString")
    };
    return settings;
}


namespace SmartMed.Migrations
{
    public class MigrationSettings
    {
        public string ConnectionString { get; set; }
    }
}
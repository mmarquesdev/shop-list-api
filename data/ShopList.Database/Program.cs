using Npgsql;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

string location = "db/migrations";
var app = builder.Build();

try
{
    var cnx = new NpgsqlConnection(builder.Configuration.GetConnectionString("DBConnection"));
    var evolve = new Evolve.Evolve(cnx, msg => Log.Information(msg))
    {
        Locations = new[] { location },
        IsEraseDisabled = true,
    };

    evolve.Migrate();
}
catch (Exception ex)
{
    Log.Error("Database migration failed.", ex);
}
app.Run();

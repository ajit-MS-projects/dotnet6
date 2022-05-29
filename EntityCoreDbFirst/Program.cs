using Microsoft.Data.SqlClient;


Console.WriteLine("Hello, World!");
try
{

    var cs = @"Data Source = ajitpi1; Persist Security Info = True; User ID = sa; Password = mypassword; Database = Blogging;TrustServerCertificate=True";
    var con = new SqlConnection(cs);

    var evolve = new Evolve.Evolve(con, msg => Console.WriteLine(msg))
    {
        Locations = new[] { "db/migrations" },
        IsEraseDisabled = true,
    };
    evolve.Migrate();
}
catch (Exception ex)
{
    Console.WriteLine("Database migration failed.", ex);
    throw;
}
using Microsoft.EntityFrameworkCore;
using Library.Data;
namespace WorkoutApp.Tests;

#region TestDatabaseFixture
public class TestDatabaseFixture
{
    private const string ConnectionString = @"Server=tcp:workout.database.windows.net,1433;Initial Catalog=WorkoutApp;Persist Security Info=False;User ID=WorkoutAppName;Password=Passwordisverysafe!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using (var context = CreateContext())
                {

                }

                _databaseInitialized = true;
            }
        }
    }

    public ApplicationDbContext CreateContext()
        => new ApplicationDbContext(
            new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(ConnectionString)
                .Options);
}
#endregion
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace WorkoutApp.Tests;

#region TestDatabaseFixture
public class TestDatabaseFixture
{
    private const string ConnectionString = @"Server=tcp:workoutapp3.database.windows.net,1433;Initial Catalog=WorkoutAppDb;Persist Security Info=False;User ID=WorkoutAppName3;Password=Passwordisverysafe!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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
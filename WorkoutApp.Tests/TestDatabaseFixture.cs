using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace WorkoutApp.Tests;

#region TestDatabaseFixture
public class TestDatabaseFixture
{
    //Mohammeds COnnection String
    //"Server=(localdb)\MSSQLLocalDB; Database=WorkoutAppEX;Trusted_Connection=True; Encrypt=false"

    private const string ConnectionString = @"Data Source=mssql-168906-0.cloudclusters.net,10004;Initial Catalog=WorkoutAppEX;User ID=superuser;Password=Super123;Encrypt=true;TrustServerCertificate=true;";

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
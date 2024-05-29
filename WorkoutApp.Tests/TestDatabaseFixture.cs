using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace WorkoutApp.Tests;

#region TestDatabaseFixture
public class TestDatabaseFixture
{
    //Mohammeds COnnection String
    //"Server=(localdb)\MSSQLLocalDB; Database=WorkoutAppEX;Trusted_Connection=True; Encrypt=false"

    private const string ConnectionString = "Server=.\\SQLEXPRESS; Database=WorkoutAppEX2;Trusted_Connection=True; Encrypt=false";

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
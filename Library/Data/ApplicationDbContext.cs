using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Core.Models;


namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private readonly Action<ApplicationDbContext, ModelBuilder> _modelCustomizer;

    #region Constructors
    public ApplicationDbContext()
    {

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, Action<ApplicationDbContext, ModelBuilder> modelCustomizer = null)
        : base(options)
    {
        _modelCustomizer = modelCustomizer;
    }
    #endregion

    public DbSet<Workout> Workouts => Set<Workout>();
    public DbSet<ExercisesAPI> ExercisesAPIs { get; set; }
    public DbSet<Schedule> Schedules { get; set; }

    public DbSet<Nutrition> Nutritions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Server=tcp:workout.database.windows.net,1433;InitialCatalog=WorkoutApp;PersistSecurityInfo=False;UserID=WorkoutAppName;Password=Passwordisverysafe!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;ConnectionTimeout=30;");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<UrlResource>().HasNoKey()
        //    .ToView("AllResources");

        if (_modelCustomizer is not null)
        {
            _modelCustomizer(this, modelBuilder);
        }
    }
}
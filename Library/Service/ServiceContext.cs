using System;

using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Library.Models;


namespace Library.Service;

public class ServiceContext : DbContext
{
    private readonly Action<ServiceContext, ModelBuilder> _modelCustomizer;

    #region Constructors
    public ServiceContext()
    {
    }

    public ServiceContext(DbContextOptions<ServiceContext> options, Action<ServiceContext, ModelBuilder> modelCustomizer = null)
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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Core.Models;


namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private readonly Action<ApplicationDbContext, ModelBuilder> _modelCustomizer;
    public DbSet<Workout> Workouts {  get; set; }
    public DbSet<ExercisesAPI> ExercisesAPIs { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Nutrition> Nutritions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, Action<ApplicationDbContext, ModelBuilder> modelCustomizer = null)
    : base(options)
    {
        _modelCustomizer = modelCustomizer;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<UrlResource>().HasNoKey()
        //    .ToView("AllResources");
        base.OnModelCreating(modelBuilder);
        if (_modelCustomizer is not null)
        {
            _modelCustomizer(this, modelBuilder);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Core.Models;


namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private readonly Action<ApplicationDbContext, ModelBuilder>? _modelCustomizer;
    public DbSet<Workout> Workouts {  get; set; }
    public DbSet<ExercisesAPI> ExercisesAPIs { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Nutrition> Nutritions { get; set; }
    public DbSet<ExerciseList> ExerciseLists { get; set; }
    public DbSet<InputValues> InputValues { get; set; }
    public DbSet<GeneratedWorkout> GeneratedWorkouts { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, Action<ApplicationDbContext, ModelBuilder>? modelCustomizer = null)
    : base(options)
    {
        _modelCustomizer = modelCustomizer;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        if (_modelCustomizer is not null)
        {
            _modelCustomizer(this, builder);
        }
    }
}


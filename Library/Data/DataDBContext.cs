//using Microsoft.EntityFrameworkCore;
//using Microsoft.SqlServer;
//using System.Diagnostics;

//using Library.Models;

//namespace Library.Data
//{
//    public class DataDBContext : DbContext
//    {
//        public DbSet<Workout> Workouts { get; set; }
//        public DbSet<ExercisesAPI> ExercisesAPIs { get; set; }
//        public DbSet<Schedule> Schedules { get; set; }

//        public DbSet<Nutrition> Nutritions { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlServer(@"Server=tcp:workoutapp.database.windows.net,1433;Initial Catalog=WorkoutAppDatabase;Persist Security Info=False;User ID=EliasMohammedThom;Password=Passwordisverysafe!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

//        }
//    }
//}

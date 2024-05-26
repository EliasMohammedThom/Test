using Core.Commands.Exercises;
using Core.Helpers;
using Core.Interfaces.Commands.Exercises;
using Core.Interfaces.Helpers;
using Core.Interfaces.ModelServices;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfanityFilter.Interfaces;

namespace Web
{

    public class Program
    {

        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();



            //Add our services
            builder.Services.AddScoped<IWorkoutService, WorkoutService>();
            builder.Services.AddScoped<IExerciseService, ExerciseService>();
            builder.Services.AddScoped<IExerciseListService, ExerciseListService>();
            builder.Services.AddScoped<IScheduleService, ScheduleService>();
            builder.Services.AddScoped<IImportValues, ImportValues>();
            builder.Services.AddScoped<IExtensions, Extensions>();
            builder.Services.AddScoped<IGeneratorService, GeneratorService>();
            builder.Services.AddScoped<IProfanityFilter, ProfanityFilter.ProfanityFilter>();
            builder.Services.AddHttpClient();
            builder.Services.AddHealthChecks();

            builder.Services.AddControllersWithViews(options =>
           {
               options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
           });




            WebApplication app = builder.Build();
            app.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapHealthChecks("/health");
            app.Run();
        }
    }
}

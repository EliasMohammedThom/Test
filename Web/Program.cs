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
            _ = builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            _ = builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            _ = builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            _ = builder.Services.AddRazorPages();



            //Add our services
            _ = builder.Services.AddScoped<IWorkoutService, WorkoutService>();
            _ = builder.Services.AddScoped<IExerciseService, ExerciseService>();
            _ = builder.Services.AddScoped<IExerciseListService, ExerciseListService>();
            _ = builder.Services.AddScoped<IScheduleService, ScheduleService>();
            _ = builder.Services.AddScoped<IImportValues, ImportValues>();
            _ = builder.Services.AddScoped<IExtensions, Extensions>();
            _ = builder.Services.AddScoped<IGeneratorService, GeneratorService>();
            _ = builder.Services.AddScoped<IProfanityFilter, ProfanityFilter.ProfanityFilter>();
            _ = builder.Services.AddHttpClient();
            _ = builder.Services.AddHealthChecks();

            _ = builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });




            WebApplication app = builder.Build();
            _ = app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                _ = app.UseMigrationsEndPoint();
            }
            else
            {
                _ = app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                _ = app.UseHsts();
            }


            _ = app.UseHttpsRedirection();
            _ = app.UseStaticFiles();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.MapRazorPages();
            _ = app.MapHealthChecks("/health");
            app.Run();
        }
    }
}

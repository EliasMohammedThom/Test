using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class YourProgressionModel : PageModel
    {
        ApplicationDbContext ApplicationDbContext { get; set; }
        public List<Workout> Workouts { get; set; }
        public IWorkoutService _WorkoutService { get; set; }
        public IdentityUser? IdentityUser { get; set; }
        private readonly UserManager<IdentityUser> _userManager;
        public List<FetchedExercises> ExerciseList { get; set; }

        public YourProgressionModel
            (
            ApplicationDbContext applicationDbContext,
            IWorkoutService workoutService,
            UserManager<IdentityUser> userManager 
            )
        {
            ApplicationDbContext = applicationDbContext;
            _WorkoutService = workoutService;
            _userManager = userManager;
        }


        public async Task OnGetAsync()
        {
            IdentityUser = await _userManager.GetUserAsync(User);

            Workouts = _WorkoutService.GetWorkoutsByUserId(IdentityUser.Id);
            


            //hämta alla workouts 
            //Dela upp exercises baserat på deras type
            
            
        }
    }
}

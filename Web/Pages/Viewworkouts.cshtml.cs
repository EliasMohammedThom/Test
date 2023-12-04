using Core.Interfaces;
using Core.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class View_workoutsModel : PageModel
    {

        private readonly IWorkoutService _workoutService;
        private readonly IScheduleService _scheduleService;
        private readonly IExerciseService _exerciseService;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public List<Workout>? SortedWorkoutList { get; set; }
        [BindProperty]
        public List <ExercisesAPI>? Exercises {  get; set; }
        public View_workoutsModel(IWorkoutService workoutService, IScheduleService scheduleService, UserManager<IdentityUser> userManager, IExerciseService exerciseService)
    {
            _workoutService = workoutService;
            _scheduleService = scheduleService;
            _userManager = userManager;
            _exerciseService = exerciseService;
        }

        public async Task<IActionResult> OnGet()
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);
            SortedWorkoutList = _workoutService.GetAllWorkouts().Where(X => X.UserId == identityUser.Id).ToList();
            Exercises = _exerciseService.GetAllExercisesAPIs().ToList();

            return Page();
        }
        public async Task<IActionResult> OnpostAsync()
        {


            return Page();
        }
    }
}

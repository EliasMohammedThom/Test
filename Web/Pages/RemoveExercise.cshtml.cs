using Core.Interfaces;
using Core.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class RemoveExerciseModel : PageModel
    {
        private readonly IWorkoutService _workoutService;
        private readonly IScheduleService _scheduleService;
        private readonly IExerciseService _exerciseService;
        private readonly UserManager<IdentityUser> _userManager;

        public RemoveExerciseModel(IWorkoutService workoutService, IScheduleService scheduleService, UserManager<IdentityUser> userManager, IExerciseService exerciseService)
        {
            _scheduleService = scheduleService;
            _workoutService = workoutService;
            _userManager = userManager;
            _exerciseService = exerciseService;
        }

        #region Public_Fields
        public Workout workout { get; set; }
        [BindProperty]
        public List<Workout> AllWorkoutsByCurrentUser { get; set; }

        [BindProperty]
        public List<ExercisesAPI> AllExercisesByCurrentUser { get; set; }

        [BindProperty]
        public int SelectedWorkoutToUpdate { get; set; }



        #endregion


        public async Task<IActionResult> OnGet()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);

            AllWorkoutsByCurrentUser = _workoutService.GetAllWorkouts().Where(X => X.UserId == identityUser.Id).ToList();

            //AllExercisesByCurrentUser = _exerciseService.GetAllExercisesAPIs().Where(X => X.WorkoutId == workout.Id).ToList();

            workout = AllWorkoutsByCurrentUser.FirstOrDefault();

            if (workout != null)
                AllExercisesByCurrentUser = _exerciseService.GetAllExercisesAPIs().Where(X => X.WorkoutId == workout.Id).ToList();


            //workout = SortedWorkoutList.FirstOrDefault();
            //if (workout != null)
            //{
            //    SortedExercise = _exerciseService.GetAllExercisesAPIs().Where(X => X.WorkoutId == workout.Id).ToList();
            //}

            return Page();
        }
    }
}

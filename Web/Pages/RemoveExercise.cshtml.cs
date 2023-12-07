using Core.Interfaces.ModelServices;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class RemoveExerciseModel : PageModel
    {
        private readonly IWorkoutService _workoutService;
        private readonly IExerciseService _exerciseService;
        private readonly UserManager<IdentityUser> _userManager;

        public RemoveExerciseModel(IWorkoutService workoutService, UserManager<IdentityUser> userManager, IExerciseService exerciseService)
        {
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

        [BindProperty]
        public int SelectedExerciseToRemove { get; set; }
        #endregion


        public async Task<IActionResult> OnGetAsync()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);

            AllWorkoutsByCurrentUser = _workoutService.GetAllWorkouts().Where(X => X.UserId == identityUser.Id).ToList();
            foreach (var item in AllWorkoutsByCurrentUser)
            {
                //item.Exercises = _exerciseService.GetAllExercisesAPIs().Where(X=>X.WorkoutId == item.Id).ToList();
                item.Exercises = _exerciseService.GetExercisesByWorkoutId(item.Id);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            _exerciseService.RemoveExerciseById(SelectedExerciseToRemove);

            return Redirect("/RemoveExercise");
        }
    }
}

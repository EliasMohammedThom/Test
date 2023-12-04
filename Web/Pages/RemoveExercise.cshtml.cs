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

        [BindProperty]
        public int SelectedExerciseToRemove { get; set; }

        [BindProperty]

        public ExercisesAPI Randomtest {  get; set; }




        #endregion


        public async Task<IActionResult> OnGetAsync()
        {
            IdentityUser identityUser = await _userManager.GetUserAsync(User);

            AllWorkoutsByCurrentUser = _workoutService.GetAllWorkouts().Where(X => X.UserId == identityUser.Id).ToList();
            foreach (var item in AllWorkoutsByCurrentUser)
            {
                item.Exercises = _exerciseService.GetAllExercisesAPIs().Where(X=>X.WorkoutId == item.Id).ToList();
                foreach (var exercise in item.Exercises) ;
            }

            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            _exerciseService.RemoveExerciseById(SelectedExerciseToRemove, Randomtest);

            return Redirect("/RemoveExercise");
        }
    }
}

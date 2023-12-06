using Core.Interfaces.Helpers;
using Core.Interfaces.ModelServices;
using Core.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class ShowScheduleModel : PageModel
    {
        private readonly IWorkoutService _workoutService;
        private readonly IScheduleService _scheduleService;
        private readonly IExerciseService _exerciseService;
        private readonly IExtensions _extensionService;
        private readonly UserManager<IdentityUser> _userManager;


        #region Public_Fields
        public Workout Workouts { get; set; }

        [BindProperty]
        public int SelectedWorkoutToRemove { get; set; }

        [BindProperty]
        public string ReplyToUser { get; set; } = default!;
        [BindProperty]
        public Schedule schedule { get; set; }

        [BindProperty]
        public List<Schedule> SortedScheduleList { get; set; }

        [BindProperty]
        public List<Workout> SortedWorkoutList { get; set; }

        [BindProperty]
        public List<Schedule> TestList { get; set; }

        [BindProperty]
        public int? CurrentUserScheduleId { get; set; }

        [BindProperty]
        public List<ExercisesAPI> SortedExercise { get; set; }
      
        public List<Workout> workouts { get; set; }
        #endregion

        public ShowScheduleModel(IWorkoutService workoutService,
            IScheduleService scheduleService,
            UserManager<IdentityUser> userManager,
            IExerciseService exerciseService,
            IExtensions extensions)
        {
            _workoutService = workoutService;
            _scheduleService = scheduleService;
            _userManager = userManager;
            _exerciseService = exerciseService;
            _extensionService = extensions;
        }
        public async Task<IActionResult> OnGet()
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            CurrentUserScheduleId = _scheduleService.GetScheduleByUserId(identityUser.Id).Id;

            //SortedWorkoutList = _workoutService.GetAllWorkouts().Where(X => X.ScheduleId == CurrentUserScheduleId).OrderBy(X => X.Date).ToList();
            SortedWorkoutList = _workoutService.GetWorkoutsByScheduleId(CurrentUserScheduleId);

            foreach(var workout in SortedWorkoutList)
            {
                //workout.Exercises = _exerciseService.GetAllExercisesAPIs().Where(X => X.WorkoutId == workout.Id);
                workout.Exercises = _exerciseService.GetExercisesByWorkoutId(workout.Id);
                workout.Description = _extensionService.LimitLength(workout.Description,40) + "...";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            _workoutService.UpdateWorkoutScheduleIDToNull(SelectedWorkoutToRemove, Workouts);
           
            return Redirect("/ShowSchedule");
        }
    }
}

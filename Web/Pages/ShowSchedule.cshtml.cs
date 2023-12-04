using Core.Interfaces;
using Core.Models;
using Humanizer;
using Infrastructure.Services;
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
        private readonly UserManager<IdentityUser> _userManager;

        #region Public_Fields
        public Workout workout { get; set; }

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

        public ShowScheduleModel(IWorkoutService workoutService, IScheduleService scheduleService, UserManager<IdentityUser> userManager, IExerciseService exerciseService)
        {
            _workoutService = workoutService;
            _scheduleService = scheduleService;
            _userManager = userManager;
            _exerciseService = exerciseService;
        }
        public async Task<IActionResult> OnGet()
        {

            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            SortedScheduleList = _scheduleService.GetAllSchedules().Where(X => X.UserId == identityUser.Id).ToList();

            CurrentUserScheduleId = _scheduleService.GetAllSchedules()?.SingleOrDefault(x => x.UserId == identityUser.Id)?.Id;

            SortedWorkoutList = _workoutService.GetAllWorkouts().Where(X => X.ScheduleId == CurrentUserScheduleId).OrderBy(X => X.Date).ToList();


            //Find current users exercises thru its workoutid and display it
            workout = SortedWorkoutList.FirstOrDefault();
            if (workout != null) 
            {
                SortedExercise = _exerciseService.GetAllExercisesAPIs().Where(X => X.WorkoutId == workout.Id).ToList();
            }
          

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
         
            _workoutService.DeleteWorkoutByWorkoutId(SelectedWorkoutToRemove, workout);
           
            return Redirect("/ShowSchedule");
        }
    }
}

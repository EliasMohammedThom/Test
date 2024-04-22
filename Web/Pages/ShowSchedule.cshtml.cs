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
        public List<FetchedExercises> SortedExercise { get; set; }
      
        public List<Workout> workouts { get; set; }

        [BindProperty]
        public int DaysToLoop { get; set; }

        [BindProperty]
        public List<string>? Weekdays { get; set; }
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

           DaysToLoop =  DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month); 


            Weekdays = new List<string>();
            Weekdays = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        }
        public async Task<IActionResult> OnGet()
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            CurrentUserScheduleId = _scheduleService.GetScheduleByUserId(identityUser.Id).Id;

            SortedWorkoutList = _workoutService.GetWorkoutsByScheduleId(CurrentUserScheduleId);

            foreach(var workout in SortedWorkoutList)
            {
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
        public void GetCalender()
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            int daysInMonth = DateTime.DaysInMonth(currentMonth, currentYear);

            for (int i = 1; i <= daysInMonth; i++)
            {
                DateTime currentDate = new DateTime(currentYear, currentMonth, i);
                string dayOfWeek = currentDate.ToString("dddd");
                //Schedule.Add((currentDate, dayOfWeek));
            }
        }
    }
}

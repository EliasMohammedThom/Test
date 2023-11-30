using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class ShowScheduleModel : PageModel
    {
        private readonly IWorkoutService _workoutService;
        private readonly IScheduleService _scheduleService;
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser currentUser;

        #region Public_Fields
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
        #endregion

        public ShowScheduleModel(IWorkoutService workoutService, IScheduleService scheduleService, UserManager<IdentityUser> userManager)
        {
            _workoutService = workoutService;
            _scheduleService = scheduleService;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGet()
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            SortedScheduleList = _scheduleService.GetAllSchedules();
            //Sort schedule list so you only get schedules with the current Users UserId
            SortedScheduleList.Where(X => X.UserId == identityUser.Id);

            CurrentUserScheduleId = _scheduleService.GetAllSchedules()?.SingleOrDefault(x => x.UserId == identityUser.Id)?.Id;

            SortedWorkoutList = _workoutService.GetAllWorkouts();
            //Sort workouts so you only get workouts with the current users ScheduleId
            SortedWorkoutList.Where(X => X.ScheduleId == CurrentUserScheduleId);





            return Page();
        }
    }
}

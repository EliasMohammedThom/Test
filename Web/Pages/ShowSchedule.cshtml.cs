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
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser currentUser;

        #region Public_Fields
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

            SortedScheduleList = _scheduleService.GetAllSchedules().Where(X => X.UserId == identityUser.Id).ToList();

            CurrentUserScheduleId = _scheduleService.GetAllSchedules()?.SingleOrDefault(x => x.UserId == identityUser.Id)?.Id;

            SortedWorkoutList = _workoutService.GetAllWorkouts().Where(X => X.ScheduleId == CurrentUserScheduleId).OrderBy(X => X.Date).ToList();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            //@*Ta ScheduleID p� en workout och s�tt den som NULL f�r att ta bort den ifr�n en users schedule*@
            SelectedWorkoutToRemove = _scheduleService.GetAllSchedules().SingleOrDefault(x => x.UserId == identityUser.Id).Id;

            var ScheduleIdToRemove = SelectedWorkoutToRemove;




            _scheduleService.RemoveWorkoutFromSchedule(ScheduleIdToRemove);
            return Page();
        }
    }
}

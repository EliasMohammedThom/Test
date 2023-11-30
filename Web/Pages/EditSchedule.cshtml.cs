using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Models;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Infrastructure.Services;
using Humanizer;
using Microsoft.AspNetCore.Identity;

namespace Web.Pages
{
    public class CreateScheduleModel : PageModel
    {
        private readonly IWorkoutService _workoutService;
        private readonly IScheduleService _scheduleService;

        [BindProperty]
        public List<Schedule> ScheduleList { get; set; } = default!;

        [BindProperty]
        public List<Workout> WorkoutList { get; set; }

        [BindProperty]
        public List<Workout> NewWorkoutList { get; set; }

        [BindProperty]
        public DateTime SelectedDate { get; set; }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;
        [BindProperty]
        public Workout Workout { get; set; } = default!;
        private readonly UserManager<IdentityUser> _userManager;

     
        public CreateScheduleModel(IWorkoutService workoutService, IScheduleService scheduleService, UserManager<IdentityUser> userManager)
        {
            _workoutService = workoutService;
            _scheduleService = scheduleService;
            _userManager = userManager;
        }
    
        public async Task OnGetAsync()
        {


            IdentityUser currentUser = await _userManager.GetUserAsync(User);

            WorkoutList = _workoutService.GetAllWorkouts().Where(X=>X.UserId == currentUser.Id).ToList();
          


        }

        public void OnPost(string userId, int scheduleId, string title)
        {
            
            //Schedule.UserId = userId;


            _workoutService.UpdateWorkout(Workout);
            //_scheduleService.UpdateSchedule(Schedule);


        }
    }

}

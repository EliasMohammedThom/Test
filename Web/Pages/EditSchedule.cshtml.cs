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
        public DateOnly SelectedDate{ get; set; }

        [BindProperty]
        public string SelectedItem { get; set; }


        [BindProperty]
        public Schedule Schedule { get; set; } = default!;
        [BindProperty]
        public Workout Workout { get; set; }
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser currentUser;

     
        public CreateScheduleModel(IWorkoutService workoutService, IScheduleService scheduleService, UserManager<IdentityUser> userManager)
        {
            _workoutService = workoutService;
            _scheduleService = scheduleService;
            _userManager = userManager;
        }
    
        public async Task OnGetAsync()
        {


            currentUser = await _userManager.GetUserAsync(User);

            WorkoutList = _workoutService.GetAllWorkouts().Where(X=>X.UserId == currentUser.Id).ToList();


          


        }

        public async Task<IActionResult>  OnPostAsync()
        {

            IdentityUser identityUser = await _userManager.GetUserAsync(User);

           Workout = _workoutService.GetWorkoutByTitle(SelectedItem);

           Workout.ScheduleId = _scheduleService.GetAllSchedules().Where(X => X.UserId == identityUser.Id).SingleOrDefault().Id;
           Workout.Date = SelectedDate;
           






            //Schedule.UserId = userId;



            _workoutService.UpdateWorkout(Workout);
            //_scheduleService.UpdateSchedule(Schedule);
            return Page();


        }
    }

}

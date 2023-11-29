using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Models;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Infrastructure.Services;
using Humanizer;

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
        public Schedule Schedule { get; set; } = default!;
        [BindProperty]
        public Workout Workout { get; set; } = default!;

        public CreateScheduleModel(IWorkoutService workoutService, IScheduleService scheduleService)
        {
            _workoutService = workoutService;
            _scheduleService = scheduleService;
        }
        public void OnPost(int workoutID, string userId, int scheduleId)
        {
            Workout.ScheduleId = scheduleId;
            Schedule.WorkoutId = workoutID;
            Schedule.UserId = userId;
            

            _workoutService.UpdateWorkout(Workout);
            _scheduleService.UpdateSchedule(Schedule);
            
            
        }
        public void OnGet()
        {
            ScheduleList = _scheduleService.GetAllSchedules();
            WorkoutList = _workoutService.GetAllWorkouts();


            //public IActionResult OnPost(List<int> selectedWorkouts)
            //{
            //    foreach (var workout in selectedWorkouts)
            //    { 
            //        _scheduleService.AddSchedule()
            //    }


            //    //WorkoutList = _workoutService.GetAllWorkouts();
            //    //Schedule.Workouts ??= new List<Workout>();

            //    //foreach (var workoutId in selectedWorkouts)
            //    //{
            //    //    var selectedWorkout = _workoutService.GetWorkoutById(workoutId);
            //    //    if (selectedWorkout != null)
            //    //    {
            //    //        Schedule.Workouts.Add(selectedWorkout);
            //    //    }

            //    //}

            //    return RedirectToPage("/Index"); 
            //}
        }
    }

}

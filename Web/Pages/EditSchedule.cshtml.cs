using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Models;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Infrastructure.Services;

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
        public Schedule Schedule { get; set; } = default!;

        public CreateScheduleModel(IWorkoutService workoutService, IScheduleService scheduleService)
        {
            _workoutService = workoutService;
            _scheduleService = scheduleService;
        }
        public void OnGet()
        {
            WorkoutList = _workoutService.GetAllWorkouts();
        }
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

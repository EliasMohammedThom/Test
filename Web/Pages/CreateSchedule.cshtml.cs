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

        [BindProperty]
        public List<Schedule> ScheduleList { get; set; } = default!;

        [BindProperty]
        public List<Workout> WorkoutList { get; set; }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;

        public CreateScheduleModel(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }
        public void OnGet()
        {
            WorkoutList = _workoutService.GetAllWorkouts();
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.CodeDom;
using System.Reflection.Metadata;
using Core.Models;
using Core.Interfaces;
namespace Web.Pages
{
    public class AddWorkoutModel : PageModel
    {
        private readonly IWorkoutService _workoutService;

        [BindProperty]
        public string ChosenWorkoutName { get; set; }

        [BindProperty]
        public Workout workout { get; set; } = default!;
        public AddWorkoutModel(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ChosenWorkoutName = workout.Name;
            _workoutService.AddWorkout(ChosenWorkoutName);


            return Page();
        }
    }
}

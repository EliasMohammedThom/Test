using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Library.Service;
using Library.Controllers;
using System.CodeDom;
using System.Reflection.Metadata;
using Library.Models;
namespace Web.Pages
{
    public class AddWorkoutModel : PageModel
    {
        private readonly ServiceContext context;
        public string ChosenWorkoutName { get; set; }

        [BindProperty]
        public Workout workout { get; set; } = default!;
        public WorkoutController workoutController { get; set; }
        public AddWorkoutModel()
        {
            context = new ServiceContext();
            var controllers = new WorkoutController(context);
            workoutController = controllers;
        }
        public async Task<IActionResult> OnPostAsync(string workoutName)
        {
            ChosenWorkoutName = workoutName;
            workoutController.AddWorkout(workoutName);


            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.CodeDom;
using System.Reflection.Metadata;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Core.Interfaces.ModelServices;
namespace Web.Pages
{
    public class AddWorkoutModel : PageModel
    {
        private readonly IWorkoutService _workoutService;

        [BindProperty]
        public Workout workout { get; set; } = default!;

        [BindProperty]
        public string ReplyToUser { get; set; } = default!;
        
        public AddWorkoutModel(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }
      
        public async Task<IActionResult> OnPostAsync()
        {
            var listofworkouts = _workoutService.GetWorkoutsByTitle(workout.Title);

            if(listofworkouts.Count >= 1 ) 
            {
                ReplyToUser = "This Workouts name already exists, please choose something else";
                TempData["ErrorMessage"] = ReplyToUser;
            }
            else
            {
                _workoutService.AddWorkout(workout);
                ReplyToUser = "Workout successfully added";
            }
            return Page();
        }
    }
}

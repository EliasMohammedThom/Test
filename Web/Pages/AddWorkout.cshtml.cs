using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.CodeDom;
using System.Reflection.Metadata;
using Core.Models;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
namespace Web.Pages
{
    public class AddWorkoutModel : PageModel
    {
        private readonly IWorkoutService _workoutService;


        [BindProperty]
        public Workout workout { get; set; } = default!;

        
        public AddWorkoutModel(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

      
        public async Task<IActionResult> OnPostAsync()
        {

            var listofworkouts = _workoutService.GetAllWorkouts().Where(X => X.Title == workout.Title).ToList();

            if(listofworkouts.Count >= 2 ) 
            {
            
            }
            

             _workoutService.AddWorkout(workout);
            
            return Page();
        }
    }
}

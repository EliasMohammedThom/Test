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


        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser currentUser;


        public AddWorkoutModel(IWorkoutService workoutService, UserManager<IdentityUser> userManager)
        {
            _workoutService = workoutService;
            _userManager = userManager;

        }

        public async Task <IActionResult> OnGetAsync()
        {

           
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()

        {
            currentUser = await _userManager.GetUserAsync(User);
           
            var listofworkouts = _workoutService.GetWorkoutsByTitle(workout.Title, currentUser.Id);

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

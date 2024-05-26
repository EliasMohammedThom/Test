using Core.Interfaces.ModelServices;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProfanityFilter.Interfaces;

namespace Web.Pages
{
    public class AddWorkoutModel : PageModel
    {
        private readonly IWorkoutService _workoutService;
        private readonly IProfanityFilter _profanityFilter;

        [BindProperty]
        public Workout workout { get; set; } = default!;

        [BindProperty]
        public string ReplyToUser { get; set; } = default!;

        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser currentUser;

        public AddWorkoutModel(IWorkoutService workoutService, UserManager<IdentityUser> userManager, IProfanityFilter profanityFilter)
        {
            _workoutService = workoutService;
            _userManager = userManager;
            _profanityFilter = profanityFilter;

        }

        public IActionResult OnGet()

        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()

        {
            currentUser = await _userManager.GetUserAsync(User);

            if (_profanityFilter.IsProfanity(workout.Title))
            {
                ReplyToUser = "Profanities are not allowed";
                TempData["ErrorMessage"] = ReplyToUser;
            }

            else if (_workoutService.Exists(workout.Title, currentUser.Id))
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

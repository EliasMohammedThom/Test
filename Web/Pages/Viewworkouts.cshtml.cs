using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Pages
{
	public class View_workoutsModel : PageModel
	{
		private readonly IWorkoutService _workoutService;
		private readonly IExerciseService _exerciseService;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ApplicationDbContext _context;

		[BindProperty]
		public List<Workout>? SortedWorkoutList { get; set; }
		[BindProperty]
		public List<FetchedExercises>? Exercises { get; set; }
		public View_workoutsModel
			(
			IWorkoutService workoutService,
			UserManager<IdentityUser> userManager,
			IExerciseService exerciseService,
			ApplicationDbContext context
			)
		{
			_workoutService = workoutService;
			_userManager = userManager;
			_exerciseService = exerciseService;
			_context = context;
		}

		public async Task<IActionResult> OnGetAsync()
		{
			IdentityUser? identityUser = await _userManager.GetUserAsync(User);
			SortedWorkoutList = _workoutService.GetWorkoutsByUserId(identityUser.Id);
			Exercises = _exerciseService.GetAllExercisesAPIs();

			return Page();
		}

		 public IActionResult OnPost(int ExerciseId, int Sets, int Reps, int Weight)
        {
            // Fetch the exercise from the database using ExerciseId
            var exercise = _context.FetchedExercises.FirstOrDefault(e => e.Id == ExerciseId);

            if (exercise != null)
            {
                // Update the exercise details
                exercise.Sets = Sets;
                exercise.Repetitions = Reps;
                exercise.Weight = Weight;

                // Save changes to the database
                _context.SaveChanges();
            }

            // Redirect to the same page to reflect the changes
            return RedirectToPage();
        }
	
	}
}

using Core.Interfaces.ModelServices;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
	public class View_workoutsModel : PageModel
	{
		private readonly IWorkoutService _workoutService;
		private readonly IExerciseService _exerciseService;
		private readonly UserManager<IdentityUser> _userManager;

		[BindProperty]
		public List<Workout>? SortedWorkoutList { get; set; }
		[BindProperty]
		public List<ExercisesAPI>? Exercises { get; set; }
		public View_workoutsModel(IWorkoutService workoutService, UserManager<IdentityUser> userManager, IExerciseService exerciseService)
		{
			_workoutService = workoutService;
			_userManager = userManager;
			_exerciseService = exerciseService;
		}

		public async Task<IActionResult> OnGetAsync()
		{
			IdentityUser? identityUser = await _userManager.GetUserAsync(User);
			SortedWorkoutList = _workoutService.GetWorkoutsByUserId(identityUser.Id);
			Exercises = _exerciseService.GetAllExercisesAPIs();

			return Page();
		}
	}
}

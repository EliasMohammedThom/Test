using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Infrastructure.Services;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Core.Interfaces.ModelServices;

namespace Web.Pages
{
	public class EditScheduleModel : PageModel
	{
		private readonly IWorkoutService _workoutService;
		private readonly IScheduleService _scheduleService;

		[BindProperty]
		public List<Workout> WorkoutList { get; set; }

		[BindProperty]
		public DateOnly SelectedDate { get; set; }

		[BindProperty]
		public string SelectedItem { get; set; }

		[BindProperty]
		public string Description { get; set; }

		[BindProperty]
		public Workout Workout { get; set; }
		private readonly UserManager<IdentityUser> _userManager;
		private IdentityUser currentUser;

		public EditScheduleModel(IWorkoutService workoutService, IScheduleService scheduleService, UserManager<IdentityUser> userManager)
		{
			_workoutService = workoutService;
			_scheduleService = scheduleService;
			_userManager = userManager;
		}

		public async Task OnGetAsync()
		{
			IdentityUser? identityUser = await _userManager.GetUserAsync(User);

			currentUser = await _userManager.GetUserAsync(User);

			WorkoutList = _workoutService.GetAllWorkouts().Where(X => X.UserId == identityUser.Id && X.ScheduleId == null).ToList();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			IdentityUser identityUser = await _userManager.GetUserAsync(User);

            Workout = _workoutService.GetWorkoutByTitle(SelectedItem, identityUser.Id);
            Workout.ScheduleId = _scheduleService.GetScheduleByUserId(identityUser.Id).Id;
            Workout.Date = SelectedDate;
            Workout.Description = Description;

            _workoutService.UpdateWorkout(Workout);
            

            return Redirect("/EditSchedule");


        }
    }
		}
	}
}

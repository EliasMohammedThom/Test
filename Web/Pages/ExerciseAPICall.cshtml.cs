using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using Core;
using Newtonsoft.Json;
using Core.Models;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Services;

namespace Web.Pages
{
    public class ExerciseAPICallModel : PageModel
    {
        private readonly IWorkoutService _workoutService;
        private readonly IExerciseService _exerciseService;
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser currentUser;

        [BindProperty]
        public List<ExercisesAPI> Exercises { get; set; }
        [BindProperty]
        public string SelectedItemExerciseName { get; set; }

        [BindProperty]

        public ExercisesAPI SelectedItemExercise { get; set; }

        [BindProperty]
        public string SelectedItemWorkout { get; set; }
        [BindProperty]
        public Workout Workout { get; set; }
        [BindProperty]
        public ExercisesAPI ExercisesAPI { get; set; }
        [BindProperty]
        public List<Workout> WorkoutList { get; set; }

        public ExerciseAPICallModel(IWorkoutService workoutService, UserManager<IdentityUser> userManager, IExerciseService exercisesAPI)
        {
            _workoutService = workoutService;
            _userManager = userManager;
            _exerciseService = exercisesAPI;
        }

        public async Task OnGetAsync()
        {
            var  response =  APICalls.GetAPICall();
            string result = await response.Result.Content.ReadAsStringAsync();
            List<ExercisesAPI> exercises = JsonConvert.DeserializeObject<List<ExercisesAPI>>(result);
            Exercises  = JsonConvert.DeserializeObject <List<ExercisesAPI>> (result);

            currentUser = await _userManager.GetUserAsync(User);
            WorkoutList = _workoutService.GetAllWorkouts().Where(X => X.UserId == currentUser.Id).ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var response = APICalls.GetAPICall();
            string result = await response.Result.Content.ReadAsStringAsync();
            List<ExercisesAPI> exercises = JsonConvert.DeserializeObject<List<ExercisesAPI>>(result);
            Exercises = JsonConvert.DeserializeObject<List<ExercisesAPI>>(result);


            ExercisesAPI = Exercises.Where(X=>X.Name == SelectedItemExerciseName).Single();

            Workout = _workoutService.GetWorkoutByTitle(SelectedItemWorkout);

            ExercisesAPI.WorkoutId = Workout.Id;
            ExercisesAPI.Sets = SelectedItemExercise.Sets;
            ExercisesAPI.Repetitions = SelectedItemExercise.Repetitions;

            _exerciseService.AddExercise(ExercisesAPI);
           
            

            return Page();
        }
    }
}

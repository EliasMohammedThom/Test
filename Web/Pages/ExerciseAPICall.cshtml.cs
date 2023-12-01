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
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Pages
{
    public class ExerciseAPICallModel : PageModel
    {
        private readonly IWorkoutService _workoutService;
        private readonly IExerciseService _exerciseService;
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser currentUser;

        [BindProperty]
        public List<ExercisesAPI>? Exercises { get; set; }
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

        [BindProperty]
        public List<string> ExerciseTypes { get; set; }

        [BindProperty]
        public List<string> MuscleCategories { get; set; }

        [BindProperty] 
        public  List<string>  DifficultyCategory { get; set; }

        [BindProperty] 
        public ExerciseSelecter ExerciseSelecter { get; set; }

        public ExerciseAPICallModel(IWorkoutService workoutService, UserManager<IdentityUser> userManager, IExerciseService exercisesAPI)
        {
            _workoutService = workoutService;
            _userManager = userManager;
            _exerciseService = exercisesAPI;
        }

        public async Task<IActionResult> OnGetAsync()
        {
         
            currentUser = await _userManager.GetUserAsync(User);
            WorkoutList = _workoutService.GetAllWorkouts().Where(X => X.UserId == currentUser.Id).ToList();


            ExerciseTypes = new List<string> {
                "cardio",
                "olympic_weightlifting",
                "plyometrics",
                "powerlifting",
                "strength",
                "stretching",
                "strongman"
            };

            MuscleCategories = new List<string> {
                "abdominals",
                "abductors",
                "adductors",
                "biceps",
                "calves",
                "chest",
                "forearms",
                "glutes",
                "hamstrings",
                "lats",
                "lower_back",
                "middle_back",
                "neck",
                "quadriceps",
                "traps",
                "triceps"  
            };

            DifficultyCategory = new List<string>
            {
                "beginner",
                "intermediate",
                "expert"
            };

            return Page();


        }



        public async Task<IActionResult> OnPostChooseExerciseAsync()
        {

            var response = APICalls.GetAPICall(ExerciseSelecter.Type, ExerciseSelecter.Muscle, ExerciseSelecter.Difficulty);
            string result = await response.Result.Content.ReadAsStringAsync();
           
            Exercises = JsonConvert.DeserializeObject<List<ExercisesAPI>>(result);

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {

           


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

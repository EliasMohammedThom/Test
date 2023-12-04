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
        private readonly IExerciseListService _exerciseListService;
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser currentUser;

        [BindProperty]
        public List<ExerciseList>? Exercises { get; set; }

        [BindProperty]
        public ExerciseList SelectedExercise { get; set; }

        [BindProperty]
        public string SelectedExerciseName { get; set; }

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

        public ExerciseAPICallModel(IWorkoutService workoutService, UserManager<IdentityUser> userManager, IExerciseService exercisesAPI, IExerciseListService exerciseList)
        {
            _workoutService = workoutService;
            _userManager = userManager;
            _exerciseService = exercisesAPI;
            _exerciseListService = exerciseList;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            currentUser = await _userManager.GetUserAsync(User);
            WorkoutList = _workoutService.GetAllWorkouts().Where(X => X.UserId == currentUser.Id).ToList();

            Exercises =  _exerciseListService.GetAllExerciseLists();
        
            return Page();
        }
            
        public async Task<IActionResult> OnPostAsync()
        {
            Workout = _workoutService.GetWorkoutByTitle(SelectedItemWorkout);
            Exercises = _exerciseListService.GetAllExerciseLists();
            SelectedExercise = Exercises.Where(X => X.Name == SelectedExerciseName).SingleOrDefault();

            ExercisesAPI.WorkoutId = Workout.Id;
            ExercisesAPI.Name = SelectedExercise.Name;
            ExercisesAPI.Instructions = SelectedExercise.Instructions;
            ExercisesAPI.Equipment = SelectedExercise.Equipment;
            ExercisesAPI.Type = SelectedExercise.Type;
            ExercisesAPI.Difficulty = SelectedExercise.Difficulty;
            ExercisesAPI.Muscle = SelectedExercise.Muscle;
            ExercisesAPI.Sets = SelectedItemExercise.Sets;
            ExercisesAPI.Repetitions = SelectedItemExercise.Repetitions;

            _exerciseService.AddExercise(ExercisesAPI);

            return Redirect("/AddExercise");
        }
    }
}

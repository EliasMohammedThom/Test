using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using Core;
using Newtonsoft.Json;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Core.Commands.Exercises;

using Microsoft.AspNetCore.Http.HttpResults;
using Core.Interfaces.ModelServices;
using Core.Interfaces.Commands.Exercises;

namespace Web.Pages
{
    public class ExerciseAPICallModel : PageModel
    {
        private readonly IWorkoutService _workoutService;
        private readonly IExerciseService _exerciseService;
        private readonly IExerciseListService _exerciseListService;
        private readonly IImportValues _importValues;
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser? currentUser;

        
        [BindProperty]
        public List<ExerciseList>? Exercises { get; set; }

        [BindProperty]
        public ExerciseList? SelectedExercise { get; set; }

        [BindProperty]
        public string SelectedExerciseName { get; set; }

        [BindProperty]
        public ExercisesAPI SetsAndReps { get; set; }
        [BindProperty]
        public string SelectedItemWorkout { get; set; }
        [BindProperty]
        public Workout ChosenWorkout { get; set; }
        [BindProperty]
        public ExercisesAPI ExerciseToAdd { get; set; }

        [BindProperty]
        public List<Workout>? WorkoutList { get; set; }

        public ExerciseAPICallModel(IWorkoutService workoutService, UserManager<IdentityUser> userManager, IExerciseService exercisesAPI, IExerciseListService exerciseList, IImportValues importValues)
        {
            _workoutService = workoutService;
            _userManager = userManager;
            _exerciseService = exercisesAPI;
            _exerciseListService = exerciseList;
            _importValues = importValues;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            currentUser = await _userManager.GetUserAsync(User);
           
            WorkoutList = _workoutService.GetWorkoutsByUserId(currentUser.Id);
            
            Exercises =  _exerciseListService.GetAllExerciseLists();
        
            return Page();
        }
            
        public async Task<IActionResult> OnPostAsync()
        {
            ChosenWorkout = _workoutService.GetWorkoutByTitle(SelectedItemWorkout);
            Exercises = _exerciseListService.GetAllExerciseLists();
            SelectedExercise = Exercises.Where(X => X.Name == SelectedExerciseName).SingleOrDefault();
            //SelectedExercise = _exerciseListService.GetExerciseListByName(SelectedExerciseName, SelectedExercise);
            ExerciseToAdd = _importValues.AssignValuesToNewExercise(ExerciseToAdd, SelectedExercise, ChosenWorkout);

            _exerciseService.AddExercise(ExerciseToAdd);

            return Redirect("/AddExercise");
        }

     
    }
}

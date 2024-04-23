
using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection.PortableExecutable;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Pages
{
    public class WorkoutGeneratorModel : PageModel
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        private readonly IScheduleService _scheduleService;
        private readonly IGeneratorService _generatorService;
        private readonly UserManager<IdentityUser> _userManager;

        #region Properties
        [BindProperty]
        public List<string> DifficultyCategory { get; set; }

        [BindProperty]
        public List<string> WorkoutEquipment { get; set; }

        [BindProperty]
        public List<string> WorkoutType { get; set; }

        [BindProperty]
        public List<string> MuscleCategories { get; set; }

        [BindProperty]
        public List<int> AmountOfWorkouts { get; set; }
        [BindProperty]
        public List<int> AmountOfExercises { get; set; }

        public List<FetchedExercises> GeneratedExercises { get; set; } = default!;

        [BindProperty]
        public InputValues InputValues { get; set; }

        public ExerciseList ExerciseList { get; set; }
        public Schedule Schedule { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public Workout Workout { get; set; }

        public List<Workout> WorkoutList { get; set; }

        public ListValue Listvalues { get; set; }

        [BindProperty]
        public string WorkoutTitle { get; set; }
        #endregion

        public WorkoutGeneratorModel(ApplicationDbContext applicationDbContext, IScheduleService scheduleService, UserManager<IdentityUser> userManager, IGeneratorService generatorService)
        {
            _ApplicationDbContext = applicationDbContext;
            _scheduleService = scheduleService;
            _userManager = userManager;
            _generatorService = generatorService;
            InputValues = new();
            GeneratedExercises = new();
            Listvalues = new();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {

            IdentityUser? identityUser = await _userManager.GetUserAsync(User);
            List<ExerciseList>? sortedExercises = _generatorService.FilterExercises(InputValues);

            var doesScheduleExists = _scheduleService.GetScheduleByUserId(identityUser.Id);
            var findScheduleId = _scheduleService.GetScheduleByUserId(identityUser.Id).Id;

            for (int i = 0; i < InputValues.AmountOfWorkouts; i++)
            {

                var newWorkout = _generatorService.CreateNewWorkout(findScheduleId, InputValues, identityUser.Id);

                if (sortedExercises.Count > 0)
                {
                    var workoutList = _ApplicationDbContext.Workouts.ToList();

                    _generatorService.FindEmptyWorkoutDaysInSchedule(workoutList, newWorkout);

                    _ApplicationDbContext.Workouts.Add(newWorkout);

                    _ApplicationDbContext.SaveChanges();

                    foreach (var exercise in sortedExercises)
                    {
                        var fetchedExercise = new FetchedExercises
                        {
                            Difficulty = exercise.Difficulty,
                            Equipment = exercise.Equipment,
                            Muscle = exercise.Muscle,
                            Type = exercise.Type,
                            Instructions = exercise.Instructions,
                            Name = exercise.Name,
                            UserId = identityUser.Id
                        };

                        GeneratedExercises.Add(fetchedExercise);

                        _ApplicationDbContext.FetchedExercises.Add(fetchedExercise);

                    }

                    _generatorService.AddExercisesToWorkout(InputValues, GeneratedExercises, newWorkout);
                }
            }

            _generatorService.ReturnErrorMessage(sortedExercises, ErrorMessage);

            CheckIfUserHasSchedule(doesScheduleExists);

            if (sortedExercises.Count != 0)
                _ApplicationDbContext.InputValues.Add(InputValues);

            var exerciseswithoutworkout = _ApplicationDbContext.FetchedExercises.Where(X => X.WorkoutId == null).ToList();
            _ApplicationDbContext.FetchedExercises.RemoveRange(exerciseswithoutworkout);

            _ApplicationDbContext.SaveChanges();

            return RedirectToPage("/ShowSchedule");

        }


        public void CheckIfUserHasSchedule(Schedule? doesScheduleExists)
        {
            if (doesScheduleExists == null)
            {
                _scheduleService.AddSchedule(Schedule);
            }
        }  
    }
}

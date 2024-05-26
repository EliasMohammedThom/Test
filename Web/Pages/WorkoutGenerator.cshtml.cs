using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public string? ErrorMessage { get; set; }

        public Workout Workout { get; set; }

        public List<Workout> WorkoutList { get; set; }

        public ListValue Listvalues { get; set; }



        public Schedule UserSchedule { get; set; }
        public IdentityUser? IdentityUser { get; set; }
        #endregion

        public WorkoutGeneratorModel
            (
            ApplicationDbContext applicationDbContext,
            IScheduleService scheduleService,
            UserManager<IdentityUser> userManager,
            IGeneratorService generatorService
            )

        {
            _ApplicationDbContext = applicationDbContext;
            _scheduleService = scheduleService;
            _userManager = userManager;
            _generatorService = generatorService;
            InputValues = new();
            GeneratedExercises = [];
            Listvalues = new();
            IdentityUser = new();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            IdentityUser = await _userManager.GetUserAsync(User);

            UserSchedule = _scheduleService.GetScheduleByUserId(IdentityUser.Id);

            if (UserSchedule == null)
            {
                Schedule newlyCreatedSchedule = _scheduleService.CreateIfScheduleIfUserHasNone(UserSchedule, Schedule, IdentityUser.Id);
                UserSchedule = newlyCreatedSchedule;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ModelState.IsValid)
            {
                IdentityUser = await _userManager.GetUserAsync(User);
                UserSchedule = _scheduleService.GetScheduleByUserId(IdentityUser.Id);
                List<ExerciseList>? sortedExercises = _generatorService.FilterExercises(InputValues);
                ErrorMessage = _generatorService.ReturnErrorMessage(sortedExercises, ErrorMessage);
                if (ErrorMessage != null)
                {
                    return Page();
                }


                for (int i = 0; i < InputValues.AmountOfWorkouts; i++)
                {
                    Workout? newWorkout = _generatorService.CreateNewWorkout(UserSchedule.Id, InputValues, IdentityUser.Id);

                    using Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _ApplicationDbContext.Database.BeginTransaction();
                    try
                    {
                        if (sortedExercises.Count > 0)
                        {
                            List<Workout> workoutList = _ApplicationDbContext.Workouts.ToList();

                            _generatorService.FindEmptyWorkoutDaysInSchedule(workoutList, newWorkout, UserSchedule.Id);

                            _ = _ApplicationDbContext.Workouts.Add(newWorkout);
                            _ = _ApplicationDbContext.SaveChanges();

                            foreach (ExerciseList exercise in sortedExercises)
                            {
                                FetchedExercises fetchedExercise = new()
                                {
                                    Difficulty = exercise.Difficulty,
                                    Equipment = exercise.Equipment,
                                    Muscle = exercise.Muscle,
                                    Type = exercise.Type,
                                    Instructions = exercise.Instructions,
                                    Name = exercise.Name,
                                    UserId = IdentityUser.Id,
                                    Sets = InputValues.AmountOfSets,
                                    Repetitions = InputValues.AmountOfRepetitions,
                                    Date = newWorkout.Date,
                                    Weight = 1
                                };

                                GeneratedExercises.Add(fetchedExercise);

                                _ = _ApplicationDbContext.FetchedExercises.Add(fetchedExercise);
                                _ = _ApplicationDbContext.SaveChanges();
                            }

                            _generatorService.AddExercisesToWorkout(InputValues, GeneratedExercises, newWorkout);
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                    }
                }

                _ = _ApplicationDbContext.SaveChanges();

                List<FetchedExercises> exerciseswithoutworkout = _ApplicationDbContext.FetchedExercises.Where(X => X.WorkoutId == null).ToList();
                _ApplicationDbContext.FetchedExercises.RemoveRange(exerciseswithoutworkout);

                _ = _ApplicationDbContext.SaveChanges();

                return RedirectToPage("/ShowSchedule");


            }

            else
            {
                return Page();
            }
        }
    }
}

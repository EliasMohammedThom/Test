using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Web.Pages
{
    public class PowerliftingProgression : PageModel
    {
        private ApplicationDbContext ApplicationDbContext { get; set; }
        public List<Workout>? Workouts { get; set; }
        public IWorkoutService _WorkoutService { get; set; }
        public IScheduleService _scheduleservice { get; set; }
        public IdentityUser? IdentityUser { get; set; }
        private readonly UserManager<IdentityUser>? _userManager;
        public List<FetchedExercises>? ExerciseList { get; set; }
        public TypeList? Powerlifting { get; set; } = new TypeList { Name = "powerlifting" };
        public List<TypeList>? Types { get; set; }

        public PowerliftingProgression
            (
            ApplicationDbContext applicationDbContext,
            IWorkoutService workoutService,
            UserManager<IdentityUser> userManager,
            IScheduleService scheduleService
            )
        {
            ApplicationDbContext = applicationDbContext;
            _WorkoutService = workoutService;
            _userManager = userManager;
            _scheduleservice = scheduleService;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            ExerciseList = await ApplicationDbContext.FetchedExercises.ToListAsync();
            IdentityUser = await _userManager.GetUserAsync(User);
            int CurrentUserScheduleId = _scheduleservice.GetScheduleByUserId(IdentityUser.Id).Id;

            Workouts = _WorkoutService.GetWorkoutsByScheduleId(CurrentUserScheduleId);

            List<int?> workoutIds = Workouts.Select(workout => workout.Id).ToList();

            List<FetchedExercises> filteredExercises = ExerciseList.Where(exercise => workoutIds.Contains(exercise.WorkoutId)).ToList();

            Powerlifting.Exercises = filteredExercises.Where(X => X.Type == "powerlifting").ToList();

            foreach (FetchedExercises exercise in Powerlifting.Exercises)
            {
                // Check if a TableList already exists for this exercise
                TableList existingTableList = Powerlifting.TableLists.FirstOrDefault(tl => tl.ExerciseName == exercise.Name);

                if (existingTableList == null)
                {
                    // If no TableList exists for this exercise, create a new one
                    TableList newTableList = new()
                    {
                        ExerciseName = exercise.Name
                    };
                    newTableList.TableValues.Add((int)exercise.Weight);

                    Powerlifting.TableLists.Add(newTableList);
                }
                else
                {
                    // If a TableList already exists for this exercise, add weight to its TableValues
                    existingTableList.TableValues.Add((int)exercise.Weight);
                }
            }

            return Page();
        }
    }
}

using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Web.Pages
{
    public class StrengthProgression : PageModel
    {
        ApplicationDbContext ApplicationDbContext { get; set; }
        public List<Workout>? Workouts { get; set; }
        public IWorkoutService _WorkoutService { get; set; }
        public IScheduleService _scheduleservice { get; set; }
        public IdentityUser? IdentityUser { get; set; }
        private readonly UserManager<IdentityUser>? _userManager;
        public List<FetchedExercises>? ExerciseList { get; set; }
        public TypeList? Strength { get; set; } = new TypeList{Name="Strength"};
        public List<TypeList>? Types { get; set; }

        public StrengthProgression
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
            var CurrentUserScheduleId = _scheduleservice.GetScheduleByUserId(IdentityUser.Id).Id;

            Workouts = _WorkoutService.GetWorkoutsByScheduleId(CurrentUserScheduleId);

            var workoutIds = Workouts.Select(workout => workout.Id).ToList();

            var filteredExercises = ExerciseList.Where(exercise => workoutIds.Contains(exercise.WorkoutId)).ToList();

            Strength.Exercises = filteredExercises.Where(X=>X.Type == "strength").ToList();

              foreach(var exercise in Strength.Exercises)
           {
                // Check if a TableList already exists for this exercise
                TableList existingTableList = Strength.TableLists.FirstOrDefault(tl => tl.ExerciseName == exercise.Name);
    
                if(existingTableList == null)
                {
                    // If no TableList exists for this exercise, create a new one
                    TableList newTableList = new TableList();
                    newTableList.ExerciseName = exercise.Name;
                    newTableList.TableValues.Add((int)exercise.Weight);
        
                    Strength.TableLists.Add(newTableList);
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

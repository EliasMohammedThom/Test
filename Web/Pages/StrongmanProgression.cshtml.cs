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
    public class StrongmanProgressionModel : PageModel
    {
        ApplicationDbContext ApplicationDbContext { get; set; }
        public List<Workout>? Workouts { get; set; }
        public IWorkoutService _WorkoutService { get; set; }
        public IScheduleService _scheduleservice { get; set; }
        public IdentityUser? IdentityUser { get; set; }

        private readonly UserManager<IdentityUser>? _userManager;
        public List<FetchedExercises>? ExerciseList { get; set; }
        public TypeList? Cardio { get; set; } = new TypeList{Name="Cardio"};
        public TypeList? Olympic { get; set; } = new TypeList{Name="Olympic"};
        public TypeList? Plyometrics { get; set; } = new TypeList{Name="Plyometrics"};
        public TypeList? Powerlifting { get; set; } = new TypeList{Name="PowerLifting"};
        public TypeList? Strength { get; set; } = new TypeList{Name="Strength"};
        public TypeList? Stretching { get; set; } = new TypeList{Name="Stretching"};
        public TypeList? Strongman { get; set; } = new TypeList{Name="Strongman"};
        public List<TypeList>? Types { get; set; }

        public StrongmanProgressionModel
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

            Cardio.Exercises = filteredExercises.Where(X=>X.Type == "cardio").ToList();
            Olympic.Exercises = filteredExercises.Where(X=>X.Type == "olympic_weightlifting").ToList();
            Plyometrics.Exercises = filteredExercises.Where(X=>X.Type == "plyometrics").ToList();
            Powerlifting.Exercises = filteredExercises.Where(X=>X.Type == "powerlifting").ToList();
            Strength.Exercises = filteredExercises.Where(X=>X.Type == "strength").ToList();
            Stretching.Exercises = filteredExercises.Where(X=>X.Type == "stretching").ToList();
            Strongman.Exercises = filteredExercises.Where(X=>X.Type == "strongman").ToList();

              foreach(var exercise in Strongman.Exercises)
           {
                // Check if a TableList already exists for this exercise
                TableList existingTableList = Strongman.TableLists.FirstOrDefault(tl => tl.ExerciseName == exercise.Name);
    
                if(existingTableList == null)
                {
                    // If no TableList exists for this exercise, create a new one
                    TableList newTableList = new TableList();
                    newTableList.ExerciseName = exercise.Name;
                    newTableList.TableValues.Add((int)exercise.Weight);
        
                    Strongman.TableLists.Add(newTableList);
                }
                else
                {
                    // If a TableList already exists for this exercise, add weight to its TableValues
                    existingTableList.TableValues.Add((int)exercise.Weight);
                }


           }


              foreach(var exercise in Powerlifting.Exercises)
            {

                Tablevalues tablevalues = new();

               
                tablevalues.Weight = (int)exercise.Weight;
                
                Powerlifting.Tablevalues.Add(tablevalues);
            }

               foreach(var exercise in Strength.Exercises)
               {
                Tablevalues tablevalues = new();

               
                tablevalues.Weight = (int)exercise.Weight;
                
                Strength.Tablevalues.Add(tablevalues);
               }

            


            return Page();

            //hämta alla workouts 
            //Dela upp exercises baserat på deras type
            
            
        }
    }
}

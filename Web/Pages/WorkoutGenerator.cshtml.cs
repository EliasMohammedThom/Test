
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
        private readonly UserManager<IdentityUser> _userManager;


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
        public InputValues Placeholder { get; set; }

        public ExerciseList ExerciseList { get; set; }

        //public IdentityUser? IdentityUser { get; set; }
        public Schedule Schedule { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public Workout Workout { get; set; }

        public List<Workout> WorkoutList { get; set; }

        public ListValue Listvalues { get; set; }

        public WorkoutGeneratorModel(ApplicationDbContext applicationDbContext, IScheduleService scheduleService, UserManager<IdentityUser> userManager)
        {
            _ApplicationDbContext = applicationDbContext;
            _scheduleService = scheduleService;
            _userManager = userManager;

            Placeholder = new();

            //WorkoutList = GenerateWorkouts(Placeholder.AmountOfWorkouts);
            

            GeneratedExercises = new();
        
            

            Listvalues = new();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public List<Workout> GenerateWorkouts(int workoutsPerWeek)
        {
            List<Workout> workoutList = new List<Workout>();

            for (int i = 0; i <= workoutsPerWeek; i++)
            {
                Workout workout = new Workout();
                workoutList.Append(workout);
            }

            return workoutList;
        }

        public async Task OnPost()
        {

            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            var doesScheduleExists = _scheduleService.GetScheduleByUserId(identityUser.Id);
            List<ExerciseList>? sortedExercises = FilterExercises();

            for (int i = 0; i < Placeholder.AmountOfWorkouts; i++)
            {
                 Workout = new Workout();
                 Workout.UserId = identityUser.Id;
                 Workout.ScheduleId = _scheduleService.GetScheduleByUserId(identityUser.Id).Id;


                if (sortedExercises.Count > 0)
                {
                    var date = new DateOnly(DateTime.Now.Year ,DateTime.Now.Month, DateTime.Now.Day);
                    
                    
                    var workoutsOnday = _ApplicationDbContext.Workouts.Where(X=>X.Date.Day  == date.Day  && X.Date.Month == date.Month);
                    
                    while (workoutsOnday.Count() != 0)
                    {
                        date = date.AddDays(1);
                        workoutsOnday = _ApplicationDbContext.Workouts.Where(X=>X.Date.Day  == date.Day  && X.Date.Month == date.Month);
                        Workout.Date = date;
                    }

                _ApplicationDbContext.Workouts.Add(Workout);

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


                Random random = new Random();

                int j = 1;
                while (j <= Placeholder.AmountOfExercises)
                {

                    var randomnumber = random.Next(0, GeneratedExercises.Count);

                    if (GeneratedExercises[randomnumber].WorkoutId == null)
                    {
                        GeneratedExercises[randomnumber].WorkoutId = Workout.Id;
                        j++;
                    }

                }
                var emptyExercises = GeneratedExercises.Where(X => X.WorkoutId == null)
                    .ToList();

                //foreach (var exercise in emptyExercises)
                //{
                //    _ApplicationDbContext.FetchedExercises.Remove(exercise);

                //}


            }
        }
            

            if (sortedExercises.Count == 0 || sortedExercises == null)
            {
                ErrorMessage = "Can not find exercises with given parameters, try again!";
            }

            if (doesScheduleExists == null)
            {
                _scheduleService.AddSchedule(Schedule);
            }
            else
            {
                Schedule currentUsersSchedule = _scheduleService.GetScheduleByUserId(identityUser.Id);


            }
            if (sortedExercises.Count != 0)
            {
                _ApplicationDbContext.InputValues.Add(Placeholder);

            }



            var exerciseswithoutworkout = _ApplicationDbContext.FetchedExercises.Where(X=>X.WorkoutId == null).ToList();
            _ApplicationDbContext.FetchedExercises.RemoveRange(exerciseswithoutworkout);

            _ApplicationDbContext.SaveChanges();

        }

        private List<ExerciseList> FilterExercises()
        {
            return _ApplicationDbContext.ExerciseLists.Where(
                x =>
                x.Difficulty == Placeholder.DifficultyCategory &&
                x.Equipment == Placeholder.WorkoutEquipment &&
                x.Muscle == Placeholder.MuscleCategories &&
                x.Type == Placeholder.WorkoutType).ToList();
        }
    }
}

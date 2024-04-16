
using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection.PortableExecutable;

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

         public ListValue Listvalues { get; set; }

        public WorkoutGeneratorModel(ApplicationDbContext applicationDbContext, IScheduleService scheduleService, UserManager<IdentityUser> userManager)
        {
            _ApplicationDbContext = applicationDbContext;
            _scheduleService = scheduleService;
            _userManager = userManager;


            Placeholder = new();

            Workout = new Workout();
            GeneratedExercises = new();
        
            Workout.Date = DateOnly.FromDateTime(DateTime.Now);

            Listvalues = new();
        }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
        public async Task OnPost()
        {

            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            var doesScheduleExists = _scheduleService.GetScheduleByUserId(identityUser.Id);

            var sortedExercises =
                _ApplicationDbContext.ExerciseLists.Where(
                x =>
                x.Difficulty == Placeholder.DifficultyCategory &&
                x.Equipment == Placeholder.WorkoutEquipment &&
                x.Muscle == Placeholder.MuscleCategories &&
                x.Type == Placeholder.WorkoutType).ToList();

                if (sortedExercises.Count > 0 )
                {
                Workout.UserId = identityUser.Id;
                Workout.ScheduleId = _scheduleService.GetScheduleByUserId(identityUser.Id).Id;
                _ApplicationDbContext.Workouts.Add(Workout);

                _ApplicationDbContext.SaveChanges();


                foreach ( var exercise in sortedExercises )
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


                foreach(var exercise in GeneratedExercises)
                {
                    exercise.WorkoutId = Workout.Id;
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
            if(sortedExercises.Count != 0)
            {
                _ApplicationDbContext.InputValues.Add(Placeholder);

            }



            _ApplicationDbContext.SaveChanges();

        }
    }
}

using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.PortableExecutable;

namespace Web.Pages
{
    public class WorkoutGeneratorModel : PageModel
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        private readonly IScheduleService _scheduleService;
        private readonly UserManager<IdentityUser> _userManager;


        //[BindProperty]
        //public List<string> DifficultyCategory { get; set; }

        //[BindProperty]
        //public List<string> WorkoutEquipment { get; set; }

        //[BindProperty]
        //public List<string> WorkoutType { get; set; }

        //[BindProperty]
        //public List<string> MuscleCategories { get; set; }

        //[BindProperty]
        //public List<int> AmountOfWorkouts { get; set; }
        //[BindProperty]
        //public List<int> AmountOfExercises { get; set; }


<<<<<<< Updated upstream
        public List<FetchedExercises> GeneratedExercises { get; set; } = default!;

=======
>>>>>>> Stashed changes
        [BindProperty]
        public InputValues Placeholder { get; set; }

        public ExerciseList ExerciseList { get; set; }

        //public IdentityUser? IdentityUser { get; set; }
        public Schedule Schedule { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public ListValue Listvalues { get; set; }

        public WorkoutGeneratorModel(ApplicationDbContext applicationDbContext, IScheduleService scheduleService, UserManager<IdentityUser> userManager)
        {
            _ApplicationDbContext = applicationDbContext;
            _scheduleService = scheduleService;
            _userManager = userManager;


            Placeholder = new();

        }
        public async Task<IActionResult> OnGetAsync()
        {
            Listvalues = new();

            //IdentityUser = await _userManager.GetUserAsync(User);


            return Page();
        }
        public async Task OnPost()
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            var doesScheduleExists = _scheduleService.GetScheduleByUserId(identityUser.Id);

            var sortedTestList =
                _ApplicationDbContext.ExerciseLists.Where(
                x =>
                x.Difficulty == Placeholder.DifficultyCategory &&
                x.Equipment == Placeholder.WorkoutEquipment &&
                x.Muscle == Placeholder.MuscleCategories &&
                x.Type == Placeholder.WorkoutType).ToList();

                if (sortedExercises.Count > 0 )
                {
                Workout.UserId = identityUser.Id;
                _ApplicationDbContext.Workouts.Add(Workout);
                _ApplicationDbContext.SaveChanges();


<<<<<<< Updated upstream
                foreach ( var exercise in sortedExercises )
                {
                    var fetchedExercise = new FetchedExercises
=======
            if (sortedTestList.Count > 0)
            {
>>>>>>> Stashed changes

                foreach (var test in sortedTestList)
                {                   
                    _ApplicationDbContext.GeneratedExercises.Add(new GeneratedExercises
                    {
                        Difficulty = test.Difficulty,
                        Equipment = test.Equipment,
                        Muscle = test.Muscle,
                        Type = test.Type,
                        Instructions = test.Instructions,
                        Name = test.Name,
                        UserId = identityUser.Id
<<<<<<< Updated upstream
                    };

                    GeneratedExercises.Add(fetchedExercise);


                    _ApplicationDbContext.FetchedExercises.Add(fetchedExercise);

                }


                foreach(var exercise in GeneratedExercises)
                {
                    exercise.WorkoutId = Workout.Id;
                }
=======
                        
                    });;
>>>>>>> Stashed changes
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
            if(sortedTestList.Count != 0)
            {
                _ApplicationDbContext.InputValues.Add(Placeholder);

            }



            _ApplicationDbContext.SaveChanges();

        }
    }
}

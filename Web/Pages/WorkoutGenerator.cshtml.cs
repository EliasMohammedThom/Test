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
        public InputValues? Placeholder { get; set; } = default!;   

        public ExerciseList ExerciseList { get; set; }

        //public IdentityUser? IdentityUser { get; set; }
        public Schedule Schedule { get; set; }



        public WorkoutGeneratorModel(ApplicationDbContext applicationDbContext, IScheduleService scheduleService, UserManager<IdentityUser> userManager)
        {
            _ApplicationDbContext = applicationDbContext;
            _scheduleService = scheduleService;
            _userManager = userManager;
               MuscleCategories =  new List<string> {
                        "Abdominals",
                        "Abductors",
                        "Adductors",
                        "Biceps",
                        "Calves",
                        "Chest",
                        "Forearms",
                        "Glutes",
                        "Hamstrings",
                        "Lats",
                        "Lower_back",
                        "Middle_back",
                        "Neck",
                        "Quadriceps",
                        "Traps",
                        "Triceps"
                    };

                WorkoutEquipment = new List<string>
            {
                "Body_only",
                "Barbell",
                "Other",
                "None",
                "Dumbbell",
                "Machine",
                "Cable",
                "Kettlebells",
                "Bands",
                "Foam_roll",
                "Exercise_ball",
                "Medicine_ball",
                "E-z_curl_bar",
            };

                 DifficultyCategory = new List<string>
            {
                    "Beginner",
                    "Intermediate",
                    "Expert"
            };

               WorkoutType = new List<string> {
                        "Cardio",
                        "Olympic_weightlifting",
                        "Plyometrics",
                        "Powerlifting",
                        "Strength",
                        "Stretching",
                        "Strongman"
                    };
        }
    
         public async Task<IActionResult> OnGetAsync()
        {
              MuscleCategories =  new List<string> {
                        "Abdominals",
                        "Abductors",
                        "Adductors",
                        "Biceps",
                        "Calves",
                        "Chest",
                        "Forearms",
                        "Glutes",
                        "Hamstrings",
                        "Lats",
                        "Lower_back",
                        "Middle_back",
                        "Neck",
                        "Quadriceps",
                        "Traps",
                        "Triceps"
                    };

                WorkoutEquipment = new List<string>
            {
                "Body_only",
                "Barbell",
                "Other",
                "None",
                "Dumbbell",
                "Machine",
                "Cable",
                "Kettlebells",
                "Bands",
                "Foam_roll",
                "Exercise_ball",
                "Medicine_ball",
                "E-z_curl_bar",
            };

                 DifficultyCategory = new List<string>
            {
                    "Beginner",
                    "Intermediate",
                    "Expert"
            };

               WorkoutType = new List<string> {
                        "Cardio",
                        "Olympic_weightlifting",
                        "Plyometrics",
                        "Powerlifting",
                        "Strength",
                        "Stretching",
                        "Strongman"
                    };
         

            return Page();

        }
        public async Task OnPost()
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            var doesScheduleExists = _scheduleService.GetScheduleByUserId(identityUser.Id);

            var sortedTestList = 
                _ApplicationDbContext.ExerciseLists.Where(
                x => x.Difficulty == Placeholder.DifficultyCategory &&
                x.Equipment == Placeholder.WorkoutEquipment &&
                x.Muscle == Placeholder.MuscleCategories &&
                x.Type == Placeholder.WorkoutType).ToList();

            //var test =
            //    _ApplicationDbContext.InputValues.Where(
            //        x => x.WorkoutEquipment == ExerciseList.Equipment &&
            //        x.DifficultyCategory == ExerciseList.Difficulty &&
            //        x.MuscleCategories == ExerciseList.Muscle &&
            //        x.WorkoutType == ExerciseList.Type).ToList();

            if(sortedTestList.Count == 0 || sortedTestList == null)
            {
                //WIP
            }

            if(doesScheduleExists == null)
            {
                _scheduleService.AddSchedule(Schedule);
            }
            else
            {
               Schedule currentUsersSchedule = _scheduleService.GetScheduleByUserId(identityUser.Id);

                
            }




            _ApplicationDbContext.InputValues.Add(Placeholder);
            _ApplicationDbContext.SaveChanges();

        }
    }
}

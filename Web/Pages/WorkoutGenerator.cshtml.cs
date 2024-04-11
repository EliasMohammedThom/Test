using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.PortableExecutable;

namespace Web.Pages
{
    public class WorkoutGeneratorModel : PageModel
    {
        private readonly ApplicationDbContext _ApplicationDbContext;


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
        public InputValues Placeholder { get; set; }

        public WorkoutGeneratorModel(ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;


            DifficultyCategory = new List<string>
            {
                    "Beginner",
                    "Intermediate",
                    "Expert"
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

            WorkoutType = new List<string> {
                        "Cardio",
                        "Olympic_weightlifting",
                        "Plyometrics",
                        "Powerlifting",
                        "Strength",
                        "Stretching",
                        "Strongman"
                    };

            MuscleCategories = new List<string> {
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

            AmountOfWorkouts = new List<int>
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14
            };
        }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            _ApplicationDbContext.InputValues.Add(Placeholder);
            _ApplicationDbContext.SaveChanges();
        }
    }
}

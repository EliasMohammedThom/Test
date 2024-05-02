using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ListValue
    {
      
        public static List<string> DifficultyCategories { get; set; }
        public static List<string> WorkoutEquipments { get; set; }
        public static List<string> WorkoutTypes { get; set; }
        public static List<string> MuscleCategories { get; set; }
        public static List<int> AmountOfWorkouts { get; set; }
        public static List<int> AmountOfExercises { get; set; }


        static ListValue()
        {

            DifficultyCategories = new List<string>
                {
                 "Beginner",
                        "Intermediate",
                        "Expert"
            };


            WorkoutEquipments = new List<string>
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
                        "E-z_curl_bar"
                    
            };


            WorkoutTypes = new List<string>
            {
                        "Cardio",
                        "Olympic_weightlifting",
                        "Plyometrics",
                        "Powerlifting",
                        "Strength",
                        "Stretching",
                        "Strongman"
                    
            };


            MuscleCategories = new List<string>
            {
               
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
            AmountOfExercises = new List<int>
            {
                
                         1,2,3,4,5,6,7,8,9,10
                    
                
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ListValue
    {
        public class DifficultyCategory
        {
            public List<string> Difficulty { get; set; }
        }
        public class WorkoutEquipment
        {
            public List<string> Equipment { get; set; }
        }
        public class WorkoutType
        {
            public List<string> Type { get; set; }
        }
        public class MuscleCategory
        {
            public List<string> Muscle { get; set; }
        }
        public class AmountOfWorkout
        {
            public List<int> Amount { get; set; }
        }
        public class AmountOfExercise
        {
            public List<int> Amount { get; set; }
        }


        public static List<DifficultyCategory> DifficultyCategories { get; set; }
        public static List<WorkoutEquipment> WorkoutEquipments { get; set; }
        public static List<WorkoutType> WorkoutTypes { get; set; }
        public static List<MuscleCategory> MuscleCategories { get; set; }
        public static List<AmountOfWorkout> AmountOfWorkouts { get; set; }
        public static List<AmountOfExercise> AmountOfExercises { get; set; }


        static ListValue()
        {

            DifficultyCategories = new List<DifficultyCategory>
            {
                new DifficultyCategory
                {
                    Difficulty = new List<string>
                    {
                        "Beginner",
                        "Intermediate",
                        "Expert"
                    }
                }
            };

            WorkoutEquipments = new List<WorkoutEquipment>
            {
                new WorkoutEquipment
                {
                    Equipment = new List<string>
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
                    }
                }
            };

            WorkoutTypes = new List<WorkoutType>
            {
                new WorkoutType
                {
                    Type = new List<string>
                    {
                        "Cardio",
                        "Olympic_weightlifting",
                        "Plyometrics",
                        "Powerlifting",
                        "Strength",
                        "Stretching",
                        "Strongman"
                    }
                }
            };
            MuscleCategories = new List<MuscleCategory>
            {
                new MuscleCategory
                {
                    Muscle = new List<string>
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
                    }
                }
            };

            AmountOfWorkouts = new List<AmountOfWorkout>
            {
                new AmountOfWorkout
                {
                    Amount = new List<int>
                    {
                        1,2,3,4,5,6,7,8,9,10,11,12,13,14
                    }
                }
            };
            AmountOfExercises = new List<AmountOfExercise>
            {
                new AmountOfExercise
                {
                    Amount = new List<int>
                    {
                         1,2,3,4,5,6,7,8,9,10
                    }
                }
            };
        }
    }
}

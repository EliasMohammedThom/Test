using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class InputValues
    {
        public int Id { get; set; }
        public string DifficultyCategory { get; set; }
        public string WorkoutEquipment { get; set; }
        public string WorkoutType { get; set; }
        public string MuscleCategories { get; set; }
        public int AmountOfWorkouts { get; set; }
        public int AmountOfExercises { get; set; }
        public string WorkoutTitle { get; set; }
        public string WorkoutDescription { get; set;}
    }
}

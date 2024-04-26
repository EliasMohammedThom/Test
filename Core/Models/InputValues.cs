using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]+$", ErrorMessage = "Only letters are allowed for the workout title.")]
        [StringLength(30, ErrorMessage = "The workout title must be between {2} and {1} characters long.", MinimumLength = 2)]

        public string WorkoutTitle { get; set; }

        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]+$", ErrorMessage = "Only letters are allowed for the workout description.")]
        [StringLength(200, ErrorMessage = "The workout description must be between {2} and {1} characters long.", MinimumLength = 10)]

        public string WorkoutDescription { get; set;}
    }
}

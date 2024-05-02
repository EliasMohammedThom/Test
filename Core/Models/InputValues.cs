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
        public int? AmountOfSets { get; set; }
        public int? AmountOfRepetitions { get; set; }

        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\s]+$", ErrorMessage = "Only letters and spaces are allowed for the workout title.")]
        [StringLength(30, ErrorMessage = "The workouttitle can be max 30 letters long") ]
        public string WorkoutTitle { get; set; }

        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\s]+$", ErrorMessage = "Only letters and spaces are allowed for the workout title.")]
        [StringLength(200, ErrorMessage = "The description can be max 200 letters long") ]
        public string WorkoutDescription { get; set;}
    }
}

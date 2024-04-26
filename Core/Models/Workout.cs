using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Models
{
    public class Workout
    {
        [Key]
        public int? Id { get; set; }
        public int? ScheduleId { get; set; }
        public string? UserId { get; set; }
        public DateOnly Date { get; set; }
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]+$")]
        [StringLength(30)]
        public string? Title { get; set; }
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ]+$")]
        [StringLength(200)]
        public string? Description { get; set; }
        public List<FetchedExercises>? Exercises { get; set;}

    }
}

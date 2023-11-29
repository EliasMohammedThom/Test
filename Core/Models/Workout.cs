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
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? ScheduleId { get; set; }

        public ICollection<ExercisesAPI> ExercisesAPIs { get; set; } = null!;
        

    }
}

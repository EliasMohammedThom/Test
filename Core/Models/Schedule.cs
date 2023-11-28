using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public int Week { get; set; }
        public int UserId { get; set; }
        public ICollection<Workout> Workouts { get; set; }
    }
}

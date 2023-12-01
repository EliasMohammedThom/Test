using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IScheduleService
    {
        public List<Schedule> GetAllSchedules();
        public List<Workout> GetWorkoutById();
        public void AddSchedule(Schedule schedule);
        public void UpdateSchedule(Schedule schedule);
        public void RemoveWorkoutFromSchedule(int? ScheduleID);


    }

}

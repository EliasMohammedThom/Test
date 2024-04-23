using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.ModelServices
{
    public interface IScheduleService
    {
        public List<Schedule> GetAllSchedules();
        public void AddSchedule(Schedule schedule);
        public Schedule? GetScheduleById(int? scheduleId);
        public void UpdateSchedule(string oldString, string newString);
        public void DeleteScheduleByScheduleId(int? scheduleId, Schedule? schedule);
        public Schedule? GetScheduleByUserId(string? userId);
        public Schedule CreateIfScheduleIfUserHasNone(Schedule? doesScheduleExists, Schedule schedule);
    }
}

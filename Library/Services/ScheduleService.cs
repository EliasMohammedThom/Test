using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ApplicationDbContext _scheduleContext;

        public ScheduleService(ApplicationDbContext scheduleContext)
        {
            _scheduleContext = scheduleContext;
        }

        public List<Schedule> GetAllSchedules()
            => _scheduleContext.Schedules.OrderBy(s => s.UserId).ToList();

        public List<Workout> GetWorkoutById()
            => _scheduleContext.Workouts.OrderBy(s => s.Id).ToList();

        public void AddSchedule(Schedule schedule)
        {
            _scheduleContext.Schedules.Add(schedule);
            _scheduleContext.SaveChanges();

        }
        public Schedule GetScheduleById(int scheduleId)
            => _scheduleContext.Schedules.Where(s => s.Id == scheduleId).SingleOrDefault();

        public void UpdateSchedule(string oldString, string newString) 
        {
            var scheduleToBeUpdates = _scheduleContext.Schedules.SingleOrDefault(x => x.UserId == oldString);

            if (scheduleToBeUpdates != null)
            {
                scheduleToBeUpdates.UserId = newString;
                _scheduleContext.Schedules.Update(scheduleToBeUpdates);
                _scheduleContext.SaveChanges();
            }
        }
        public void DeleteScheduleByScheduleId(int? scheduleId, Schedule? schedule)
        {
            schedule = _scheduleContext.Schedules.Where(x => x.Id == scheduleId).SingleOrDefault();

            _scheduleContext.Remove(schedule);
            _scheduleContext.SaveChanges();
        }
        public Schedule GetScheduleByUserId(string userId)
        => _scheduleContext.Schedules.Where(s => s.UserId == userId).SingleOrDefault();
    }
}

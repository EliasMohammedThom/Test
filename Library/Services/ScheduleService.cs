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
        public void UpdateSchedule(Schedule schedule) 
        {
            _scheduleContext.Update(schedule);
            _scheduleContext.SaveChanges();
        }



    }

}

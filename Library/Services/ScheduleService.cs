using Core.Interfaces.ModelServices;
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
        private readonly ApplicationDbContext _ApplicationDbContext;


        public ScheduleService(ApplicationDbContext scheduleContext)
        {
            _ApplicationDbContext = scheduleContext;
        }
        public Schedule CreateIfScheduleIfUserHasNone(Schedule? doesScheduleExists, Schedule schedule)
        {
            if (doesScheduleExists == null)
            {
                schedule = new Schedule();
                _ApplicationDbContext.Schedules.Add(schedule);
            }
            return schedule;
        }

        //Testas ej, men används i tester
        public List<Schedule> GetAllSchedules()
            => _ApplicationDbContext.Schedules.OrderBy(s => s.UserId).ToList();

        public void AddSchedule(Schedule schedule)
        {

            if (schedule != null)
            {
                _ApplicationDbContext.Schedules.Add(schedule);
                _ApplicationDbContext.SaveChanges();
            }
          
        }
        public Schedule? GetScheduleById(int? scheduleId)
            => _ApplicationDbContext.Schedules.Where(s => s.Id == scheduleId).SingleOrDefault();

        public void UpdateSchedule(string oldString, string newString) 
        {
            var scheduleToBeUpdates = _ApplicationDbContext.Schedules.FirstOrDefault(x => x.UserId == oldString);

            if (scheduleToBeUpdates != null)
            {
                scheduleToBeUpdates.UserId = newString;
                _ApplicationDbContext.Schedules.Update(scheduleToBeUpdates);
                _ApplicationDbContext.SaveChanges();
            }
        }
        public void DeleteScheduleByScheduleId(int? scheduleId, Schedule? schedule)
        {
            schedule = GetScheduleById(scheduleId);

            _ApplicationDbContext.Remove(schedule);
            _ApplicationDbContext.SaveChanges();
        }

        //Testas ej, men används i tester
        public Schedule? GetScheduleByUserId(string? userId)
        => _ApplicationDbContext.Schedules.Where(s => s.UserId == userId).FirstOrDefault();
    }
}

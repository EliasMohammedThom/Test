using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext _workoutContext;

        public WorkoutService(ApplicationDbContext workoutContext)
        {
            _workoutContext = workoutContext;
        }
        public void AddWorkout(Workout workout)
        {
             
            _workoutContext.Add(workout);
            _workoutContext.SaveChanges();
        }

        public Workout GetWorkout(string name)
        {
            var workout = _workoutContext.Workouts.FirstOrDefault(b => b.Title == name);
            return workout;
        }

        public void UpdateWorkoutName(string newName, string oldName)
        {

          

            var workoutToUpdate = _workoutContext.Workouts.SingleOrDefault(X => X.Title == oldName);

            if (workoutToUpdate != null)
            {
                workoutToUpdate.Title = newName;
                _workoutContext.Workouts.Update(workoutToUpdate);
                _workoutContext.SaveChanges();
            }
        }
        public void UpdateWorkout(Workout workout)
        {
            _workoutContext.Update(workout);
            _workoutContext.SaveChanges();

        }

        public void DeleteEmptyWorkouts()

        {
            var emptyWorkout = _workoutContext.Workouts.Where(X => X.UserId == null);
            _workoutContext.Workouts.RemoveRange(emptyWorkout);
            _workoutContext.SaveChanges();
        }

        public void DeleteWorkout(string name)
        {
            var workouttodelete = _workoutContext.Workouts.Where(x => x.Title == name);
            _workoutContext.Workouts.RemoveRange(workouttodelete);
            _workoutContext.SaveChanges();
        }
        public void DeleteWorkoutByWorkoutId(int? workoutId, Workout workout)
        {
            workout = _workoutContext.Workouts.Where(X => X.Id == workoutId).SingleOrDefault();

            workout.ScheduleId = null;

            _workoutContext.Update(workout);
            _workoutContext.SaveChanges();
        }

        public List<Workout> GetAllWorkouts()
            => _workoutContext.Workouts.OrderBy(b => b.Title).ToList();

        public Workout GetWorkoutById(int workoutid)
           => _workoutContext.Workouts.Where(s => s.Id == workoutid).SingleOrDefault();

        public Workout GetWorkoutByUserId(string userId)
          => _workoutContext.Workouts.Where(s => s.UserId == userId).SingleOrDefault();
        public Workout GetWorkoutByTitle(string title)
        => _workoutContext.Workouts.Where(s => s.Title == title).SingleOrDefault();




        //public void RemoveWorkoutFromSchedule(int ScheduleID, Workout workout)
        //{
        //    workout = _workoutContext.GetAllWorkouts().Where(X => X.ScheduleId == ScheduleID).SingleOrDefault();
        //    workout = _workoutContext.

        //    workout.ScheduleId = null;

        //    _workoutService.UpdateWorkout(workout);


        //    //if(ScheduleID != null)
        //    //{
        //    //    schedule.Id = ScheduleID;
        //    //}
        //    //_scheduleContext.Update(schedule); 
        //    //_scheduleContext.SaveChanges();
        //}
    }
}

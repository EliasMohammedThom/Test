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
            var workout = _workoutContext.Workouts.FirstOrDefault(b => b.Name == name);
            return workout;
        }

        public void UpdateWorkoutName(string newName, string workoutName)
        {
            var workoutToUpdate = _workoutContext.Workouts.SingleOrDefault(X => X.Name == workoutName);
            if (workoutToUpdate != null)
            {
                workoutToUpdate.Name = newName;
                _workoutContext.Workouts.Update(workoutToUpdate);
                _workoutContext.SaveChanges();
            }
        }

        public void DeleteEmptyWorkouts()

        {
            var emptyWorkout = _workoutContext.Workouts.Where(X => X.ScheduleId == null);
            _workoutContext.Workouts.RemoveRange(emptyWorkout);
            _workoutContext.SaveChanges();
        }

        public void DeleteWorkout(string name)
        {
            var workouttodelete = _workoutContext.Workouts.Where(x => x.Name == name);
            _workoutContext.Workouts.RemoveRange(workouttodelete);
            _workoutContext.SaveChanges();
        }
        public List<Workout> GetAllWorkouts()
            => _workoutContext.Workouts.OrderBy(b => b.Name).ToList();

        public List<Workout> GetWorkoutById(int workoutid)
           => _workoutContext.Workouts.OrderBy(s => s.Id == workoutid).ToList();

    }
}

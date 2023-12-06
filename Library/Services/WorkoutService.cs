using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.ModelServices;
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
            if (workout != null)
            {
                _workoutContext.Add(workout);
                _workoutContext.SaveChanges();
            }

        }

        public void UpdateWorkout(Workout workout)
        {
            _workoutContext.Update(workout);
            _workoutContext.SaveChanges();
        }

        public void DeleteEmptyWorkout()

        {
            var emptyWorkout = _workoutContext.Workouts.Where(X => X.UserId == null).First();

            if (emptyWorkout != null)
            {
                _workoutContext.Workouts.Remove(emptyWorkout);
                _workoutContext.SaveChanges();
            }

        }

        public void UpdateWorkoutScheduleIDToNull(int? workoutId, Workout? workout)
        {
            workout = _workoutContext.Workouts.Where(X => X.Id == workoutId).SingleOrDefault();

            if (workout != null)
            {
                workout.ScheduleId = null;

                _workoutContext.Update(workout);
                _workoutContext.SaveChanges();
            }
        }

        public List<Workout> GetAllWorkouts()
            => _workoutContext.Workouts.OrderBy(b => b.Title).ToList();

        public Workout? GetWorkoutByTitle(string title)
        => _workoutContext.Workouts.Where(s => s.Title == title).First();
        public List<Workout>? GetWorkoutsByUserId(string userId) => _workoutContext.Workouts.Where(s => s.UserId == userId).ToList();

        public List<Workout> GetWorkoutsByTitle(string? title, string? userid) => _workoutContext.Workouts.Where(X => X.Title == title && X.UserId == userid).ToList();

        public List<Workout> GetWorkoutsByScheduleId(int? scheduleId)
            => _workoutContext.Workouts.Where(X => X.ScheduleId == scheduleId).OrderBy(X=>X.Date).ToList();

        public Workout? GetWorkoutByTitle(string title, string userid)
             => _workoutContext.Workouts.Where(s => s.Title == title && s.UserId == userid).First();
    }
}

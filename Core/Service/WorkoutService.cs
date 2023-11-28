using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using WorkoutApp.ApplicationLogic.Interfaces;

namespace WorkoutApp.ApplicationLogic
{
    public class WorkoutService : IWorkoutService
    {
        private readonly DbContext _workoutContext;

        public WorkoutService(DbContext workoutContext)
        {
            _workoutContext = workoutContext;
        }
        public void AddWorkout(string name)
        {
            var workout = new Workout { Name = name };
            _workoutContext.Add(workout);
            _workoutContext.SaveChanges();
        }
    }
}

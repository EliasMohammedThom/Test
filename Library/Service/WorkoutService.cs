using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Library.Service;
using WorkoutApp.ApplicationLogic.Interfaces;

namespace WorkoutApp.ApplicationLogic
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ServiceContext _workoutContext;

        public WorkoutService(ServiceContext workoutContext)
        {
            this._workoutContext = workoutContext;
        }
        public void AddWorkout(Workout workout)
        {
         
            _workoutContext.Add(workout);
            _workoutContext.SaveChanges();
        }
    }
}

using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.ModelServices
{
    public interface IGeneratorService
    {
        public string ReturnErrorMessage(List<ExerciseList>? sortedExercises, string ErrorMessage);

        public void FindEmptyWorkoutDaysInSchedule(List<Workout> workoutList, Workout workout);

        public void AddExercisesToWorkout(InputValues inputValues, List<FetchedExercises> generatedexercises, Workout workout);

        public Workout? CreateNewWorkout(int scheduleId, InputValues inputValues, string userId);
        
        public List<ExerciseList> FilterExercises(InputValues inputValues);
    }
}

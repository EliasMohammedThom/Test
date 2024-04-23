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
    public class GeneratorService : IGeneratorService
    {
        public string ReturnErrorMessage(List<ExerciseList>? sortedExercises, string ErrorMessage)
        {
            if (sortedExercises.Count == 0 || sortedExercises == null)
            {
                return ErrorMessage = "Can not find exercises with given parameters, try again!";
            }
            else
            {
                return null;
            }
        }

        public void FindEmptyWorkoutDaysInSchedule(List<Workout> workoutList, Workout workout)
        {
            var date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var workoutsOnday = workoutList.Where(X => X.Date.Day == date.Day && X.Date.Month == date.Month);

            while (workoutsOnday.Count() != 0)
            {
                date = date.AddDays(1);
                workoutsOnday = workoutList.Where(X => X.Date.Day == date.Day && X.Date.Month == date.Month);
                workout.Date = date;
            }
        }

        public void AddExercisesToWorkout(InputValues inputValues, List<FetchedExercises> generatedexercises, Workout workout)
        {
            Random random = new Random();

            int j = 1;
            while (j <= inputValues.AmountOfExercises)
            {
                var randomnumber = random.Next(0, generatedexercises.Count);

                if (generatedexercises[randomnumber].WorkoutId == null)
                {
                    generatedexercises[randomnumber].WorkoutId = workout.Id;
                    j++;
                }

            }
        }

        public Workout CreateNewWorkout(int scheduleId, InputValues inputValues, string userId)
        {

            var workout = new Workout();
            workout.UserId = userId;
            workout.ScheduleId = scheduleId;
            workout.Title = inputValues.WorkoutTitle;
            workout.Description = inputValues.WorkoutDescription;

            return workout;
        }

    }
}

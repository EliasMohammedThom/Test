using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.Commands.Exercises;

namespace Core.Commands.Exercises
{
    public class ImportValues : IImportValues
    {
        public FetchedExercises AssignValuesToNewExercise(FetchedExercises newExercise, ExerciseList exerciseFromList, Workout workout)
        {
            newExercise.WorkoutId = workout.Id;
            newExercise.Name = exerciseFromList.Name;
            newExercise.Instructions = exerciseFromList.Instructions;
            newExercise.Equipment = exerciseFromList.Equipment;
            newExercise.Type = exerciseFromList.Type;
            newExercise.Difficulty = exerciseFromList.Difficulty;
            newExercise.Muscle = exerciseFromList.Muscle;

            return newExercise;
        }
    }

   
}

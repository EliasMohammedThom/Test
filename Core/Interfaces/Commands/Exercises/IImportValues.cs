using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Commands.Exercises
{
    public interface IImportValues
    {
        public  FetchedExercises AssignValuesToNewExercise(FetchedExercises newExercise, ExerciseList exerciseFromList, Workout workout)
        {
            return newExercise;
        }
    }
}

using Core.Models;

namespace Core.Interfaces.ModelServices
{
    public interface IExerciseService
    {
        void AddExercise(ExercisesAPI ExercisesAPI);
        List<ExercisesAPI>? GetAllExercisesAPIs();
        public ExercisesAPI? GetExerciseById(int id);
        public void RemoveExerciseById(int id);
        List<ExercisesAPI>? GetExercisesByWorkoutId(int? id);
    }
}
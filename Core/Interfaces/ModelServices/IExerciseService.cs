using Core.Models;

namespace Core.Interfaces.ModelServices
{
    public interface IExerciseService
    {
        void AddExercise(FetchedExercises ExercisesAPI);
        List<FetchedExercises>? GetAllExercisesAPIs();
        public FetchedExercises? GetExerciseById(int id);
        public void RemoveExerciseById(int id);
        List<FetchedExercises>? GetExercisesByWorkoutId(int? id);
    }
}
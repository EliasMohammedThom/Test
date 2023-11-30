using Core.Models;

namespace Infrastructure.Services
{
    public interface IExerciseService
    {
        void AddExercise(ExercisesAPI ExercisesAPI);
        List<ExercisesAPI> GetAllExercisesAPIs();
        List<ExercisesAPI> GetWorkoutById();
        void UpdateExercisesAPI(ExercisesAPI ExercisesAPI);
    }
}
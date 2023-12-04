using Core.Models;

namespace Core.Interfaces.ModelServices
{
    public interface IExerciseService
    {
        void AddExercise(ExercisesAPI ExercisesAPI);
        List<ExercisesAPI> GetAllExercisesAPIs();
        public ExercisesAPI GetExerciseById(int id);
        void UpdateExercisesAPI(ExercisesAPI ExercisesAPI);
        public void RemoveExerciseById(int id, ExercisesAPI exercise);



    }
}
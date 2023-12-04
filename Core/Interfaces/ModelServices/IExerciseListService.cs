using Core.Models;

namespace Core.Interfaces.ModelServices
{
    public interface IExerciseListService
    {
        List<ExerciseList> GetAllExerciseLists();

        ExerciseList GetExerciseListByName(string exerciseName, ExerciseList exerciseList);
    }
}
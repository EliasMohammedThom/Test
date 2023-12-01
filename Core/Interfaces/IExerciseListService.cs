using Core.Models;

namespace Infrastructure.Services
{
    public interface IExerciseListService
    {
        List<ExerciseList> GetAllExerciseLists();
    }
}
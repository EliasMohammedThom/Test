using Core.Models;

namespace Core.Interfaces
{
    public interface IWorkoutService
    {
        public void AddWorkout(string name);
        public List<Workout> GetAllWorkouts();
    }
}

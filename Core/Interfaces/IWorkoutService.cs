using Core.Models;

namespace Core.Interfaces
{
    public interface IWorkoutService
    {
        public List<Workout> GetAllWorkouts();
        public void AddWorkout(Workout workout);
        public List<Workout> GetWorkoutById(int workoutid);
    }
}

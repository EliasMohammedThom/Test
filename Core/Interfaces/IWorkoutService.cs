using Core.Models;

namespace Core.Interfaces
{
    public interface IWorkoutService
    {
        public List<Workout> GetAllWorkouts();
        public void AddWorkout(Workout workout);
        //public Workout GetWorkoutById(int workoutid);
        public void UpdateWorkout(Workout workout);
        //public Workout GetWorkoutByUserId(string userId);
        public Workout GetWorkoutByTitle(string title);
        public void DeleteWorkoutByWorkoutId(int? workoutId, Workout workout);
        //public void UpdateWorkoutName(string newName, string oldName);
    }
}

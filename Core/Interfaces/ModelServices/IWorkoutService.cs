using Core.Models;

namespace Core.Interfaces.ModelServices
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
        public List<Workout>? GetWorkoutsByUserId(string userId);
        List<Workout> GetWorkoutsByTitle(string? title);
        List<Workout> GetWorkoutsByScheduleId(int? id);
        //public void UpdateWorkoutName(string newName, string oldName);
    }
}

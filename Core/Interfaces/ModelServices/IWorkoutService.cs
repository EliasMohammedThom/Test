using Core.Models;

namespace Core.Interfaces.ModelServices
{
    public interface IWorkoutService
    {
        public List<Workout>? GetAllWorkouts();
        public void AddWorkout(Workout workout);
        public void UpdateWorkout(Workout workout);
        public void UpdateWorkoutScheduleIDToNull(int? workoutId, Workout workout);
        public List<Workout>? GetWorkoutsByUserId(string userId);
        List<Workout> GetWorkoutsByTitle(string? title, string? userid);
        List<Workout> GetWorkoutsByScheduleId(int? id);
        public Workout? GetWorkoutByTitle(string title, string userid);
		bool Exists(string? title, string id);
	}
}

using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext _ExercisesAPIContext;

        public ExerciseService(ApplicationDbContext ExercisesAPIContext)
        {
            _ExercisesAPIContext = ExercisesAPIContext;
        }

        //Testas ej men används i tester
        public List<FetchedExercises>? GetAllExercisesAPIs()
            => _ExercisesAPIContext.FetchedExercises.OrderBy(s => s.Name).ToList();

        //Testas ej men används i tester
        public FetchedExercises? GetExerciseById(int id)
            => _ExercisesAPIContext.FetchedExercises.FirstOrDefault(s => s.Id == id);

        public void AddExercise(FetchedExercises ExercisesAPI)
        {
            _ExercisesAPIContext.FetchedExercises.Add(ExercisesAPI);
            _ExercisesAPIContext.SaveChanges();

        }

		public void RemoveExerciseById(int id)
		{
			var exercise = GetExerciseById(id);

			_ExercisesAPIContext.Remove(exercise);
			_ExercisesAPIContext?.SaveChanges();
		}

		public List<FetchedExercises> GetExercisesByWorkoutId(int? workoutid)
            => _ExercisesAPIContext.FetchedExercises.Where(s => s.WorkoutId == workoutid).ToList();

        public FetchedExercises GetByWorkoutName(string workoutName)
         => _ExercisesAPIContext.FetchedExercises.Where(X=>X.Name == workoutName).First();
        
    }
}

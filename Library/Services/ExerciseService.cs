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
        public List<ExercisesAPI> GetAllExercisesAPIs()
            => _ExercisesAPIContext.ExercisesAPIs.OrderBy(s => s.Name).ToList();

        //Testas ej men används i tester
        public ExercisesAPI GetExerciseById(int id)
            => _ExercisesAPIContext.ExercisesAPIs.SingleOrDefault(s => s.Id == id);

        public void AddExercise(ExercisesAPI ExercisesAPI)
        {
            _ExercisesAPIContext.ExercisesAPIs.Add(ExercisesAPI);
            _ExercisesAPIContext.SaveChanges();

        }

		public void RemoveExerciseById(int id)
		{
			var exercise = GetExerciseById(id);

			_ExercisesAPIContext.Remove(exercise);
			_ExercisesAPIContext?.SaveChanges();
		}

		public List<ExercisesAPI> GetExercisesByWorkoutId(int? workoutid)
            => _ExercisesAPIContext.ExercisesAPIs.Where(s => s.WorkoutId == workoutid).ToList();

        public ExercisesAPI GetByWorkoutName(string workoutName)
         => _ExercisesAPIContext.ExercisesAPIs.Where(X=>X.Name == workoutName).First();
        
    }
}

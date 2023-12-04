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

        public List<ExercisesAPI> GetAllExercisesAPIs()
            => _ExercisesAPIContext.ExercisesAPIs.OrderBy(s => s.Name).ToList();

        public ExercisesAPI GetExerciseById(int id)
            => _ExercisesAPIContext.ExercisesAPIs.SingleOrDefault(s => s.Id == id);

        public void AddExercise(ExercisesAPI ExercisesAPI)
        {
            _ExercisesAPIContext.ExercisesAPIs.Add(ExercisesAPI);
            _ExercisesAPIContext.SaveChanges();

        }
        public void UpdateExercisesAPI(ExercisesAPI ExercisesAPI)
        {
            _ExercisesAPIContext.Update(ExercisesAPI);
            _ExercisesAPIContext.SaveChanges();
        }
        public void RemoveExerciseById(int id, ExercisesAPI exercise)
        {
            exercise = GetExerciseById(id);


            _ExercisesAPIContext.Remove(exercise);
            _ExercisesAPIContext?.SaveChanges();
        }
    }
}

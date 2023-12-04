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
    public class ExerciseListService : IExerciseListService
    {
        private readonly ApplicationDbContext _ExerciseLists;
        public ExerciseListService(ApplicationDbContext ExerciseLists)
        {
            _ExerciseLists = ExerciseLists;
        }

        public List<ExerciseList> GetAllExerciseLists()
            => _ExerciseLists.ExerciseLists.OrderBy(s => s.Name).ToList();

        public ExerciseList GetExerciseListByName(string exerciseName, ExerciseList exerciseList)
        {

            GetAllExerciseLists().Where(x=>x.Name == exerciseName).SingleOrDefault();
            return exerciseList ;
        }
    }
}

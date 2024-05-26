using Core.Models;

using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExerciseListController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public IEnumerable<ExerciseList> Get(string? difficulty, string? type, string? muscle, string? equipment)
        {
            IQueryable<ExerciseList> query = _context.ExerciseLists;


            if (!difficulty.IsNullOrEmpty())
            {
                query = query.Where(o => o.Difficulty == difficulty);
            }

            if (!type.IsNullOrEmpty())
            {
                query = query.Where(o => o.Type == type);
            }
            if (!muscle.IsNullOrEmpty())
            {
                query = query.Where(o => o.Muscle == muscle);
            }
            if (!difficulty.IsNullOrEmpty())
            {
                query = query.Where(o => o.Difficulty == difficulty);
            }

            if (!equipment.IsNullOrEmpty())
            {
                query = query.Where(o => o.Equipment == equipment);
            }

            return query.ToList();
        }
    }
}




using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FetchedExerciseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IScheduleService _scheduleService;
        private readonly IWorkoutService _workoutService;
        // GET: api/<OrderController>
        public FetchedExerciseController(
            ApplicationDbContext applicationDbContext,
            IScheduleService scheduleService,
            IWorkoutService workoutService
            )
        {
            _context = applicationDbContext;
            _scheduleService = scheduleService;
            _workoutService = workoutService;
        }

        [HttpGet]
        public List<int?>? Get(string? exerciseName, string? userId)
        {
            List<Workout> workouts;
            int? scheduleId;

            IQueryable<FetchedExercises> query = _context.FetchedExercises;


            if (!exerciseName.IsNullOrEmpty())
            {
                query = query.Where(o => o.Name == exerciseName);
            }


            if (!userId.IsNullOrEmpty())
            {
                scheduleId = _scheduleService.GetScheduleByUserId(userId).Id;
                workouts = _workoutService.GetWorkoutsByScheduleId(scheduleId);

                var workoutIds = workouts.Select(w => w.Id).ToList();

                query = query.Where(o => workoutIds.Contains(o.WorkoutId));
            }

            List<int?> weightData = new List<int?>();

            foreach (var weights in query)
            {
                weightData.Add(weights.Weight);
            }


            return weightData;
        }
    }
}




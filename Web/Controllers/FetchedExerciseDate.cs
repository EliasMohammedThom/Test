using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FetchedExerciseDateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IScheduleService _scheduleService;
        private readonly IWorkoutService _workoutService;
        public FetchedExerciseDateController(
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
        public List<DateOnly?>? Get(string exerciseName, string? userId)
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

                List<int?> workoutIds = workouts.Select(w => w.Id).ToList();


                query = query.Where(o => workoutIds.Contains(o.WorkoutId));

            }

            List<DateOnly?>? dateData = [];

            foreach (FetchedExercises date in query)
            {
                dateData.Add(date.Date);
            }

            return dateData;
        }
    }
}




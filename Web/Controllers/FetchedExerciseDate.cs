using Core.Interfaces.ModelServices;
using Core.Models;

using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FetchedExerciseDateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IScheduleService _scheduleService;
        private readonly IWorkoutService _workoutService;
        // GET: api/<OrderController>
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
        public List<DateOnly?>? Get(string? exerciseName, string? userId)
        {
            List<Workout> workouts;
            int? scheduleId;
            // Assuming Order is your model/entity class representing orders
            IQueryable<FetchedExercises> query = _context.FetchedExercises;

            // Filter orders based on query parameters if provided
            if (!exerciseName.IsNullOrEmpty())
            {
                query = query.Where(o => o.Name == exerciseName);
            }

            if (!userId.IsNullOrEmpty())
            {
            scheduleId = _scheduleService.GetScheduleByUserId(userId).Id;
            workouts = _workoutService.GetWorkoutsByScheduleId(scheduleId);
            // Extract the WorkoutId values from the workouts list
            var workoutIds = workouts.Select(w => w.Id).ToList();

            // Filter the query based on the extracted WorkoutId values
            query = query.Where(o => workoutIds.Contains(o.WorkoutId));

            }

            List<DateOnly?>? dateData = new List<DateOnly?>();

            foreach (var date in query) 
                {
                dateData.Add(date.Date);
                }


            return dateData;
        }











    }
}




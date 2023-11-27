using System.Data;

using Microsoft.AspNetCore.Mvc;

using Library.Data;
using Library.Models;


namespace Library.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkoutController : ControllerBase
{
    private readonly Service.ServiceContext _context;

    public WorkoutController(Service.ServiceContext context  )
        => _context = context;

    #region GetWorkout
    [HttpGet]
    public ActionResult<Workout> GetWorkout(string name)
    {
        var workout = _context.Workouts.FirstOrDefault(b => b.Name == name);
        return workout is null ? NotFound() : workout;
    }
    #endregion

    [HttpGet]
    public ActionResult<Workout[]> GetAllWorkouts()
        => _context.Workouts.OrderBy(b => b.Name).ToArray();

    #region AddBlog
    [HttpPost]
    public ActionResult AddWorkout(string name)
    {
        _context.Workouts.Add(new Workout { Name = name });
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete]

    public ActionResult DeleteWorkout(string name)
    {
        var workouttodelete = _context.Workouts.Where(x=>x.Name == name);

        _context.Workouts.RemoveRange(workouttodelete);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPut]
    public ActionResult UpdateWorkoutName (string newName, string workoutName)
    {
       var workoutToUpdate = _context.Workouts.SingleOrDefault(X => X.Name == workoutName);

        workoutToUpdate.Name = newName;



        _context.Workouts.Update(workoutToUpdate);

        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete]
    public ActionResult DeleteEmptyWorkouts() 
    
    {
        var emptyWorkout = _context.Workouts.Where(X=>X.ScheduleId == null);

        _context.Workouts.RemoveRange(emptyWorkout);
        _context.SaveChanges();
        return Ok();
    }






    #endregion

   
}
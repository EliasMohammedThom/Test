
using Infrastructure.Services;
using Core.Models;
using Core;
using Newtonsoft.Json;
using Core.Interfaces.ModelServices;
namespace WorkoutApp.Tests;

[TestCaseOrderer(
    ordererTypeName: "WorkoutApp.Tests.AlphabeticalOrderer",
    ordererAssemblyName: "WorkoutApp.Tests")]

public class WorkoutServiceTest : IClassFixture<TestDatabaseFixture>
{
    private readonly Workout _workout = new();
    private WorkoutService _workoutService { get; set; }
    public WorkoutServiceTest(TestDatabaseFixture fixture)
    {
        Fixture = fixture;
        var context = Fixture.CreateContext();

        _workoutService = new WorkoutService(context);
    }
       

    public TestDatabaseFixture Fixture { get; }


    //THIS CODE ADDS ALL THE EXERCISES FROM THE API TO THE DATABASE
    //[Fact]
    //public async Task T0AddAllWorkoutsToList()
    //{
    //    using var context = Fixture.CreateContext();
    //    var service = new WorkoutService(context);
    //    List<string> ExerciseTypes = new List<string> {
    //            "cardio",
    //            "olympic_weightlifting",
    //            "plyometrics",
    //            "powerlifting",
    //            "strength",
    //            "stretching",
    //            "strongman"
    //        };
    //   List<string> MuscleCategories = new List<string> {
    //            "abdominals",
    //            "abductors",
    //            "adductors",
    //            "biceps",
    //            "calves",
    //            "chest",
    //            "forearms",
    //            "glutes",
    //            "hamstrings",
    //            "lats",
    //            "lower_back",
    //            "middle_back",
    //            "neck",
    //            "quadriceps",
    //            "traps",
    //            "triceps"
    //        };
    //   List<string> DifficultyCategory = new List<string>
    //        {
    //            "beginner",
    //            "intermediate",
    //            "expert"
    //        };
    //    List<ExerciseList>? exerciseList = new List<ExerciseList>();
    //    foreach (var type in ExerciseTypes)
    //    {
    //        foreach(var muscle in MuscleCategories)
    //        {
    //            foreach(var difficulty in DifficultyCategory) 
    //            {
    //                var response = APICalls.GetAPICall(type, muscle, difficulty);
    //                string result = await response.Result.Content.ReadAsStringAsync();
    //                exerciseList = JsonConvert.DeserializeObject<List<ExerciseList>>(result);
    //                foreach(var exercise in exerciseList)
    //                {
    //                   if (exercise != null)
    //                    {
    //                        context.ExerciseLists.Add(exercise);
    //                        context.SaveChangesAsync();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    [Fact]
    public void T1AddWorkoutShouldReturnAddedWorkoutTitle()
    {
        //arrange

        //act
        _workout.Title = "WorkoutToBeUpdated";
       
        _workoutService.AddWorkout(_workout);

        var workout = _workoutService.GetWorkoutByTitle("WorkoutToBeUpdated");

        //assert
        Assert.Equal("WorkoutToBeUpdated", workout.Title);
    }

    [Fact]
    public void T2GetWorkoutByTitleShouldReturnWorkoutTitle()
    {
        //arrange
   

        //act
        var workout = _workoutService.GetWorkoutByTitle("WorkoutToBeUpdated");

        //Assert
        Assert.Equal("WorkoutToBeUpdated", workout.Title);
    }

    [Fact]
    public void T3UpdateWorkoutShouldReturnUpdatedWorkoutTitle()
    {
        //arrange
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);
        var updatedName = "UpdatedWorkout";
        var workout = service.GetWorkoutByTitle("WorkoutToBeUpdated");
        workout.Title = updatedName;

        //act
        service.UpdateWorkout(workout);
        var actual = service.GetWorkoutByTitle(updatedName);

        //assert
        Assert.Equal(actual.Title, updatedName);
    }

    [Fact]
    public void T4UpdateWorkoutScheduleIDToNullShouldReturnNullAfterRemoval()
    {
        //arrange
        
        var workout = _workoutService.GetWorkoutByTitle("UpdatedWorkout");

        //act
        _workoutService.UpdateWorkoutScheduleIDToNull(workout.Id, workout);
        var actual = _workoutService.GetWorkoutByTitle("UpdatedWorkout");

        // assert
        Assert.Equal(actual.ScheduleId, null);
    }

    [Fact]
    public void T5DeleteWorkoutByIdShouldRemoveWorkoutFromDatabase()
    {
        //arrange
      
        //act
        var actual = _workoutService.GetAllWorkouts().Where(x => x.Title == "UpdatedWorkout").First();
        int? actualId = actual.Id;

        _workoutService.DeleteWorkoutById(actualId);
      
        var updatedActual = _workoutService.GetWorkoutByID(actualId);

        //Assert
        Assert.Null(updatedActual);
    }
}
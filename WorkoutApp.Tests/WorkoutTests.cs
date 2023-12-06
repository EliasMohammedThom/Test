
using Infrastructure.Services;
using Core.Models;
using Core;
using Newtonsoft.Json;
namespace WorkoutApp.Tests;


[TestCaseOrderer(
    ordererTypeName: "WorkoutApp.Tests.AlphabeticalOrderer",
    ordererAssemblyName: "WorkoutApp.Tests")]


public class WorkoutServiceTest : IClassFixture<TestDatabaseFixture>
{
    private readonly Workout _workout = new();

    public WorkoutServiceTest(TestDatabaseFixture fixture)
        => Fixture = fixture;

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
        using var context = Fixture.CreateContext();

        //act
        _workout.Title = "WorkoutToBeUpdated";
        var service = new WorkoutService(context);
        service.AddWorkout(_workout);
        var workout = context.Workouts.First(b => b.Title == "WorkoutToBeUpdated");

        //assert
        Assert.Equal("WorkoutToBeUpdated", workout.Title);
    }

    [Fact]
    public void T2GetWorkoutByTitleShouldReturnWorkoutTitle()
    {
        //arrange
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);

        //act
        var workout = service.GetWorkoutByTitle("WorkoutToBeUpdated");

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
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);
        var workout = service.GetWorkoutByTitle("UpdatedWorkout");

        //act
        service.UpdateWorkoutScheduleIDToNull(workout.Id, workout);
        var actual = service.GetWorkoutByTitle("UpdatedWorkout");

        // assert
        Assert.Equal(actual.ScheduleId, null);
    }

    [Fact]
    public void T5DeleteWorkoutByIdShouldRemoveWorkoutFromDatabase()
    {
        //arrange
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);

        //act
        var actual = service.GetAllWorkouts().Where(x => x.Title == "UpdatedWorkout").First();
        int? actualId = actual.Id;
        context.Remove(actual);
        context.SaveChanges();
        var updatedActual = service.GetWorkoutByID(actualId);

        //Assert
        Assert.Null(updatedActual);
    }
}

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
    public void T1AddWorkout()
    {
        //arrange
        using var context = Fixture.CreateContext();

        //act
        _workout.Title = "WorkoutToBeUpdated";
        var service = new WorkoutService(context);
        service.AddWorkout(_workout);
        var workout = context.Workouts.SingleOrDefault(b => b.Title == "WorkoutToBeUpdated");

        //assert
        Assert.Equal("WorkoutToBeUpdated", workout.Title);
    }

    [Fact]
    public void T2GetWorkout()
    {
        //arrange
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);

        //act
        var workout = service.GetWorkout(_workout.Id);

        //Assert
        Assert.Equal(_workout.Id, workout.Id);
    }

    [Fact]
    public void T3UpdateWorkout()
    {
        //arrange
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);
        var testWorkout = "UpdatedWorkout";

        //act
        service.UpdateWorkoutName(testWorkout, "WorkoutToBeUpdated");
        var actual = service.GetWorkout(_workout.Id);

        //assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void T4RemoveWorkout()
    {
        //arrange
        Thread.Sleep(1000);
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);
        var testWorkoutId = _workout.Id;
        //act

        service.DeleteWorkoutByWorkoutId(testWorkoutId, _workout);
        var actual = service.GetWorkout(testWorkoutId);
        //var actual = context.Workouts.Single();

        // assert
        Assert.Null(actual);
    }

    [Fact]
    public void T5DeleteEmptyData()
    {
        //arrange
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);

        //act
        service.DeleteEmptyWorkouts();
        var actual = service.GetAllWorkouts().Where(X => X.UserId == null);

        //Assert
        Assert.Empty(actual);
    }
}
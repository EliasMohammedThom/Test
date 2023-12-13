
using Infrastructure.Services;
using Core.Models;
using Core;
using Newtonsoft.Json;
using Core.Interfaces.ModelServices;
namespace WorkoutApp.Tests.Integrationstests;

[TestCaseOrderer(
    ordererTypeName: "WorkoutApp.Tests.AlphabeticalOrderer",
    ordererAssemblyName: "WorkoutApp.Tests")]

public class WorkoutServiceTest : IClassFixture<TestDatabaseFixture>
{
    private Workout _workout = new();
    private WorkoutService _workoutService { get; set; }
    public WorkoutServiceTest(TestDatabaseFixture fixture)
    {
        Fixture = fixture;
        var context = Fixture.CreateContext();

        _workoutService = new WorkoutService(context);
    }

    public TestDatabaseFixture Fixture { get; }

    #region do not touch unless you know what you're doing
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
    //    List<string> MuscleCategories = new List<string> {
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
    //    List<string> DifficultyCategory = new List<string>
    //        {
    //            "beginner",
    //            "intermediate",
    //            "expert"
    //        };
    //    List<ExerciseList>? exerciseList = new List<ExerciseList>();
    //    foreach (var type in ExerciseTypes)
    //    {
    //        foreach (var muscle in MuscleCategories)
    //        {
    //            foreach (var difficulty in DifficultyCategory)
    //            {
    //                var response = APICalls.GetAPICall(type, muscle, difficulty);
    //                string result = await response.Result.Content.ReadAsStringAsync();
    //                exerciseList = JsonConvert.DeserializeObject<List<ExerciseList>>(result);
    //                foreach (var exercise in exerciseList)
    //                {
    //                    if (exercise != null)
    //                    {
    //                        context.ExerciseLists.Add(exercise);
    //                        context.SaveChangesAsync();
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
    #endregion


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
    public void T2ExistsTest()
    {
        //arrange
        _workout = _workoutService.GetWorkoutByTitle("WorkoutToBeUpdated");

        //act
        bool exists = _workoutService.Exists(_workout.Title, _workout.UserId);

        //assert
        Assert.True(exists);
    }
    [Fact]
    public void T3GetWorkoutByTitleShouldReturnWorkoutTitle()
    {
        //arrange

        //act
        var workout = _workoutService.GetWorkoutByTitle("WorkoutToBeUpdated");

        //Assert
        Assert.Equal("WorkoutToBeUpdated", workout.Title);
    }

    [Fact]
    public void T4UpdateWorkoutShouldReturnUpdatedWorkoutTitle()
    {
        //arrange     
        var updatedName = "UpdatedWorkout";
        var workout = _workoutService.GetWorkoutByTitle("WorkoutToBeUpdated");
        workout.Title = updatedName;

        //act
        _workoutService.UpdateWorkout(workout);
        var actual = _workoutService.GetWorkoutByTitle(updatedName);

        //assert
        Assert.Equal(actual.Title, updatedName);
    }

    [Fact]
    public void T5UpdateWorkoutScheduleIDToNullShouldReturnNullAfterRemoval()
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
    public void T6DeleteWorkoutByIdShouldRemoveWorkoutFromDatabase()
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

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
        //act
        using var context = Fixture.CreateContext();


        //arrange

        Workout testworkout = new Workout { Title = "WorkoutToBeUpdated"};
        var service = new WorkoutService(context);
        service.AddWorkout(testworkout);
        var workout = context.Workouts.SingleOrDefault(b => b.Title == "WorkoutToBeUpdated");



        //assert

        Assert.Equal("WorkoutToBeUpdated", workout.Title);
    }


    [Fact]
    public void T2GetWorkout()
    {

        //Act
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);

        //Arrange
        var workout = service.GetWorkout("WorkoutToBeUpdated");


        //Assert
        Assert.Equal("WorkoutToBeUpdated", workout.Title);


    }


    [Fact]
    public void T3UpdateWorkout()
    {

        //act
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);
        var testWorkout = "UpdatedWorkout";

        //arrange
        service.UpdateWorkoutName(testWorkout, "WorkoutToBeUpdated");



        var actual = service.GetWorkout(testWorkout);

        //assert
        Assert.NotNull(actual);


    }


    [Fact]
    public void T4RemoveWorkout()
    {

        //act
        Thread.Sleep(1000);
        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);
        var testWorkout = "UpdatedWorkout";

        //arrange

        service.DeleteWorkout(testWorkout);
        var actual = service.GetWorkout(testWorkout);
        //var actual = context.Workouts.Single();



        // assert
        Assert.Null(actual);


    }



    [Fact]
    public void T5DeleteEmptyData()
    {


        using var context = Fixture.CreateContext();
        var service = new WorkoutService(context);

        service.DeleteEmptyWorkouts();



        var actual = service.GetAllWorkouts().Where(X=>X.UserId == null);

        
        Assert.Empty(actual);


    }

}
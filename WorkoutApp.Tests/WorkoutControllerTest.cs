
using Infrastructure.Services;

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
    //public void T1AddWorkout()
    //{
    //    //act
    //    using var context = Fixture.CreateContext();

    //    //arrange
    //    var service = new WorkoutService(context);
    //    service.AddWorkout("WorkoutToBeUpdated");
    //    var workout = context.Workouts.Single(b => b.Name == "WorkoutToBeUpdated");

    //    //assert

    //    Assert.Equal("WorkoutToBeUpdated", workout.Name);
    //}


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

        var actual = service.GetAllWorkouts();

        Assert.Empty(actual);


    }

}
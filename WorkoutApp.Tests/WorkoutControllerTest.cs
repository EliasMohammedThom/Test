using Library.Service;
using Library.Data;
using Library.Controllers;

namespace WorkoutApp.Tests;


[TestCaseOrderer(
    ordererTypeName: "WorkoutApp.Tests.AlphabeticalOrderer",
    ordererAssemblyName: "WorkoutApp.Tests")]


public class WorkoutControllerTest : IClassFixture<TestDatabaseFixture>
{


    public WorkoutControllerTest(TestDatabaseFixture fixture)
        => Fixture = fixture;

    public TestDatabaseFixture Fixture { get; }






    [Fact]
    public void T1AddWorkout()
    {
        

        //act
        using var context = Fixture.CreateContext();

        //arrange
        var controller = new WorkoutController(context);
        controller.AddWorkout("WorkoutToBeUpdated");
        var workout = context.Workouts.Single(b => b.Name == "WorkoutToBeUpdated");

        //assert

        Assert.Equal("WorkoutToBeUpdated", workout.Name);
       


    }


    [Fact]
    public void T2GetWorkout()
    {
       
        //Act
        using var context = Fixture.CreateContext();
        var controller = new WorkoutController(context);

        //Arrange
        var workout = controller.GetWorkout("WorkoutToBeUpdated").Value;


        //Assert
        Assert.Equal("WorkoutToBeUpdated", workout.Name);
        

    }


    [Fact]
    public void T3UpdateWorkout()
    {
       
        //act
        using var context = Fixture.CreateContext();
        var controller = new WorkoutController(context);
        var testWorkout = "UpdatedWorkout";

        //arrange
        controller.UpdateWorkoutName(testWorkout, "WorkoutToBeUpdated");

        

        var actual = controller.GetWorkout(testWorkout);

        //assert
        Assert.NotNull(actual);
       

    }

  
    [Fact]
    public void T4RemoveWorkout()
    {
      
        //act
        Thread.Sleep(1000); 
        using var context = Fixture.CreateContext();
        var controller = new WorkoutController(context);
        var testWorkout = "UpdatedWorkout";

        //arrange

        controller.DeleteWorkout(testWorkout);
        var actual = controller.GetWorkout(testWorkout).Value;
        //var actual = context.Workouts.Single();

       

        // assert
        Assert.Null(actual);
   

    }



    [Fact]
    public void T5DeleteEmptyData()
    {
      
        
        using var context = Fixture.CreateContext();
        var controller = new WorkoutController(context);

        controller.DeleteEmptyWorkouts();

        var actual = controller.GetAllWorkouts();

        Assert.Empty(actual.Value);
      

    }

}
using Infrastructure.Services;
using Core.Models;
using Core;
using Newtonsoft.Json;
namespace WorkoutApp.Tests;

public class ExerciseTests : IClassFixture<TestDatabaseFixture>
{
    private readonly ExercisesAPI _Exercise = new();
    private ExerciseService _exerciseService {  get; set; }
    public ExerciseTests(TestDatabaseFixture fixture)
    {
        Fixture = fixture;
        var context = Fixture.CreateContext();
        _exerciseService = new ExerciseService(context);
    }

    public TestDatabaseFixture Fixture { get; }

    [Fact]
    public void T1AddExerciseShouldReturnAddedExerciseName()
    {
        //arrange

        //act
        _Exercise.Name = "ExerciseToBeRemoved";

        _exerciseService.AddExercise(_Exercise);
        var exercise = _exerciseService.GetByWorkoutName("ExerciseToBeRemoved");
        
        //assert
        Assert.Equal("ExerciseToBeRemoved", exercise.Name);
    }

    [Fact]
    public void T2GetExerciseByIdShouldReturnNotNullForValidId()
    {
        //arrange
       
        var testexercise = _exerciseService.GetAllExercisesAPIs().First(X => X.Name == "ExerciseToBeRemoved");
        //act
        var exercise = _exerciseService.GetExerciseById(testexercise.Id);

        //Assert
        Assert.NotNull(exercise);
    }

    [Fact]
    public void T3RemoveExerciseByIdFromDatabaseShouldReturnNullAfterRemoval()
    {
        //arrange
      
        var testexercise = _exerciseService.GetAllExercisesAPIs().First(X => X.Name == "ExerciseToBeRemoved");
        //act

        _exerciseService.RemoveExerciseById(testexercise.Id);

        testexercise = _exerciseService.GetExerciseById(testexercise.Id);

        Assert.Null(testexercise);
    }

    //[Fact]
    //public void T4GetExercisesByWorkoutIdShouldReturnNotNullAfterRetrievingExistingExerciseInDataBase()
    //{
    //    //arrange
        
    //    //act 
    //    var testdata = _exerciseService.GetExercisesByWorkoutId(159);

    //    Assert.NotNull(testdata);
    //}
}
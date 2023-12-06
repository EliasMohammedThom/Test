using Infrastructure.Services;
using Core.Models;
using Core;
using Newtonsoft.Json;
namespace WorkoutApp.Tests;

public class ExerciseTests : IClassFixture<TestDatabaseFixture>
{
    private readonly ExercisesAPI _Exercise = new();

    public ExerciseTests(TestDatabaseFixture fixture)
        => Fixture = fixture;

    public TestDatabaseFixture Fixture { get; }

    [Fact]
    public void T1AddExerciseShouldReturnAddedExerciseName()
    {
        //arrange
        using var context = Fixture.CreateContext();

        //act
        _Exercise.Name = "ExerciseToBeRemoved";


        var service = new ExerciseService(context);
        service.AddExercise(_Exercise);
        var exercise = context.ExercisesAPIs.Where(X => X.Name == "ExerciseToBeRemoved").First();
        //assert
        Assert.Equal("ExerciseToBeRemoved", exercise.Name);
    }

    [Fact]
    public void T2GetExerciseByIdShouldReturnNotNullForValidId()
    {
        //arrange
        using var context = Fixture.CreateContext();
        var service = new ExerciseService(context);

        var testexercise = service.GetAllExercisesAPIs().First(X => X.Name == "ExerciseToBeRemoved");
        //act
        var exercise = service.GetExerciseById(testexercise.Id);

        //Assert
        Assert.NotNull(exercise);
    }

    [Fact]
    public void T3RemoveExerciseByIdFromDatabaseShouldReturnNullAfterRemoval()
    {
        //arrange
        using var context = Fixture.CreateContext();
        var service = new ExerciseService(context);

        var testexercise = service.GetAllExercisesAPIs().First(X => X.Name == "ExerciseToBeRemoved");
        //act

        service.RemoveExerciseById(testexercise.Id, testexercise);

        testexercise = service.GetExerciseById(testexercise.Id);

        Assert.Null(testexercise);
    }

    [Fact]
    public void T4GetExercisesByWorkoutIdShouldReturnNotNullAfterRetrievingExistingExerciseInDataBase()
    {
        //arrange
        using var context = Fixture.CreateContext();
        var service = new ExerciseService(context);

        //act 
        var testdata= service.GetExercisesByWorkoutId(159);

        Assert.NotNull(testdata);
    }
}
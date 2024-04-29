using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Web.Controllers;
using Infrastructure.Data;
using Infrastructure.Services;
using WorkoutApp.Tests;

public class ExerciseControllerTests : IClassFixture<TestDatabaseFixture>
{
    private ExerciseListService _exerciseListService { get; set; }
    private ExerciseListController _exerciseController;
    

    public ExerciseControllerTests(TestDatabaseFixture fixture)
    {
        Fixture = fixture;

        var context = Fixture.CreateContext();

        _exerciseListService = new ExerciseListService(context);
        _exerciseController = new(context);
    }

    public TestDatabaseFixture Fixture { get; }
    [Fact]
    public void Get_FilterByDifficulty_ReturnsFilteredExercises()
    {
        // Arrange
   
        List<string> skillLevels =
        [
            
            "beginner",
            "intermediate",
            "expert",
        ];
        
        //Act & Assert
        FilteredExercisesByDifficulty(skillLevels);
    }

    [Fact]
    public void Get_FilterByType_ReturnsFilteredExercises()

    {
          // Arrange
         List<string> types = new List<string>
        {
            "cardio",
            "olympic_weightlifting",
            "plyometrics",
            "powerlifting",
            "strength",
            "stretching",
            "strongman"
        };

        //Act & Assert
        FilteredExercisesByType(types);
       
    }

    [Fact]
    public void Get_FilterByMuscles_ReturnsFilteredExercises()

    {
         // Arrange
         List<string> muscles = new List<string>
        {
            "abdominals",
            "abductors",
            "adductors",
            "biceps",
            "calves",
            "chest",
            "forearms",
            "glutes",
            "hamstrings",
            "lats",
            "lower_back",
            "middle_back",
            "neck",
            "quadriceps",
            "traps",
            "triceps"
        };

        //Act & Assert
        FilteredExercisesByMuscle(muscles);
       
    }

    [Fact]
    public void Get_FilterByEquipment_ReturnsFilteredExercises()

    {
         // Arrange
         List<string> equipment =
        [
            
            "barbell",
            "dumbbell",
            "body_only",
            "other",
            "foam_roll",
            "exercise_ball",
            "e-z_curl_bar",
            "cable",
            "machine",
            "bands",
            "kettlebells",
            "None",
            
        ];

        //Act & Assert
        FilteredExercisesByEquipment(equipment);
       
    }

   private void FilteredExercisesByDifficulty(/*List<ExerciseList> testData,*/ IEnumerable<string> properties)
   {
    foreach (var property in properties)
    {
        var result = _exerciseController.Get(property, null, null, null);
            
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
   }
   private void FilteredExercisesByType(/*List<ExerciseList> testData,*/ IEnumerable<string> properties)
   {
    foreach (var property in properties)
    {
        var result = _exerciseController.Get(null, property, null, null);
            
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
   }
   private void FilteredExercisesByMuscle(/*List<ExerciseList> testData,*/ IEnumerable<string> properties)
   {
    foreach (var property in properties)
    {
        var result = _exerciseController.Get(null, null,property, null);
            
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
   }
   private void FilteredExercisesByEquipment(/*List<ExerciseList> testData,*/ IEnumerable<string> properties)
   {
    foreach (var property in properties)
    {
        var result = _exerciseController.Get(null, null, null, property);
            
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }
   }




   
}

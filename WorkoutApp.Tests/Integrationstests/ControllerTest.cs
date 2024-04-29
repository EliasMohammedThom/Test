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
    private Mock<ApplicationDbContext> _mockDbContext;

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
        
        //var testData = _exerciseListService.GetAllExerciseLists();

        List<string> skillLevels =
        [
            
            "beginner",
            "intermediate",
            "expert",
        ];
        
        FilteredExercisesByDifficulty(skillLevels);
    }

    [Fact]
    public void Get_FilterByType_ReturnsFilteredExercises()

    {
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
         FilteredExercisesByType(types);
       
    }

    [Fact]
    public void Get_FilterByMuscles_ReturnsFilteredExercises()

    {
        
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
        
         FilteredExercisesByMuscle(muscles);
       
    }

    [Fact]
    public void Get_FilterByEquipment_ReturnsFilteredExercises()

    {
         List<string> equipment =
        [
            
            "barbell",
            "dumbell",
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
            "none",
        ];

        FilteredExercisesByEquipment(equipment);
       
    }

   private void FilteredExercisesByDifficulty(/*List<ExerciseList> testData,*/ IEnumerable<string> properties)
{
    foreach (var property in properties)
    {
        var result = _exerciseController.Get(property, null, null, null);
            
        Assert.NotNull(result);
    }
}
   private void FilteredExercisesByType(/*List<ExerciseList> testData,*/ IEnumerable<string> properties)
{
    foreach (var property in properties)
    {
        var result = _exerciseController.Get(null, property, null, null);
            
        Assert.NotNull(result);
    }
}
   private void FilteredExercisesByMuscle(/*List<ExerciseList> testData,*/ IEnumerable<string> properties)
{
    foreach (var property in properties)
    {
        var result = _exerciseController.Get(null, null,property, null);
            
        Assert.NotNull(result);
    }
}
   private void FilteredExercisesByEquipment(/*List<ExerciseList> testData,*/ IEnumerable<string> properties)
{
    foreach (var property in properties)
    {
        var result = _exerciseController.Get(null, null, null, property);
            
        Assert.NotNull(result);
    }
}




   
}

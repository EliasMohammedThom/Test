using Web.Controllers;
using Infrastructure.Services;
using WorkoutApp.Tests;
using Core.Models;

namespace WorkoutApp.Tests.Integrationstests
{
    public class ExerciseControllerTests : IClassFixture<TestDatabaseFixture>
{
    private ExerciseListController _exerciseController;
    public ListValue List { get; set; } = new ListValue();
    public ExerciseControllerTests(TestDatabaseFixture fixture)
    {
        Fixture = fixture;

        var context = Fixture.CreateContext();

        
        _exerciseController = new(context);
    }

    public TestDatabaseFixture Fixture { get; }
    [Fact]
    public void Get_FilterByDifficulty_ReturnsFilteredExercises()
    {
        // Arrange
        List<string> skillLevels = ListValue.DifficultyCategories;
        

        //Act & Assert
        FilteredExercisesByDifficulty(skillLevels);
    }

    [Fact]
    public void Get_FilterByType_ReturnsFilteredExercises()

    {
        // Arrange
        var types = ListValue.WorkoutTypes;

        //Act & Assert
        FilteredExercisesByType(types);

    }

    [Fact]
    public void Get_FilterByMuscles_ReturnsFilteredExercises()

    {
        // Arrange
        var muscles = ListValue.WorkoutTypes;

        //Act & Assert
        FilteredExercisesByMuscle(muscles);

    }

    [Fact]
    public void Get_FilterByEquipment_ReturnsFilteredExercises()

    {
        // Arrange
        var equipment = ListValue.WorkoutEquipments;

        //Act & Assert
        FilteredExercisesByEquipment(equipment);
    }

    private void FilteredExercisesByDifficulty(IEnumerable<string> properties)
    {
        foreach (var property in properties)
        {
            var result = _exerciseController.Get(property, null, null, null);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }




    private void FilteredExercisesByType(IEnumerable<string> properties)
    {
        foreach (var property in properties)
        {
            var result = _exerciseController.Get(null, property, null, null);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
    private void FilteredExercisesByMuscle(IEnumerable<string> properties)
    {
        foreach (var property in properties)
        {
            var result = _exerciseController.Get(null, null, property, null);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
    private void FilteredExercisesByEquipment(IEnumerable<string> properties)
    {
        foreach (var property in properties)
        {
            var result = _exerciseController.Get(null, null, null, property);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}
}



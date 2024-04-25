using Core.Interfaces.ModelServices;
using Core.Models;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Tests.Integrationstests
{
    public class GeneratorTests : IClassFixture<TestDatabaseFixture>
    {
        private GeneratorService _generatorService { get; set; }
        public GeneratorTests(TestDatabaseFixture fixture)
        {
            Fixture = fixture;

            var context = Fixture.CreateContext();

            _generatorService = new GeneratorService(context);
        }

        public TestDatabaseFixture Fixture { get; }

        [Theory]
        [InlineData(1, "test", "test", "test", "test", "test", "test")]
        public void GetAllExerciseListsShouldReturnCorrectAmountOfExercises(
        int id, string name, string type, string muscle, string equipment, string difficulty, string instructions)
       
        {
            var sortedExercises = new List<ExerciseList>();

            var exercise = new ExerciseList
            {
                Id = id,
                Name = name,
                Type = type,
                Muscle = muscle,
                Equipment = equipment,
                Difficulty = difficulty,
                Instructions = instructions
            };
            sortedExercises.Add(exercise);
         
            string errorMessage = "Test Error Message";

            // Act
            var result = _generatorService.ReturnErrorMessage(sortedExercises, errorMessage);

            // Assert
            Assert.Null(result);
        }
    


[Fact]
public void GetExerciseListByNameShouldReturnCorrectExercise()
{
    //// arrange

    //var exerciseNameToFind = "Cocoons";

    //// act
    //var result = _exerciseListService.GetExerciseListByName(exerciseNameToFind);

    //// assert
    //Assert.NotNull(result);
    //Assert.Equal(exerciseNameToFind, result.Name);
}
    }
}

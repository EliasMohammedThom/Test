using Core.Interfaces.ModelServices;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutApp.Tests
{
    public class ExerciseListTests : IClassFixture<TestDatabaseFixture>
    {
        private ExerciseListService _exerciseListService { get; set; }
        public ExerciseListTests(TestDatabaseFixture fixture)
        {
            Fixture = fixture;

            var context = Fixture.CreateContext();

            _exerciseListService = new ExerciseListService(context);
        }       

        public TestDatabaseFixture Fixture { get; }

        [Fact]
        public void GetAllExerciseListsShouldReturnCorrectAmountOfExercises()
        {
            //arrange
           
            //act
            var exerciseList = _exerciseListService.GetAllExerciseLists();

            //Assert
            Assert.Equal(551, exerciseList.Count);
        }
        [Fact]
        public void GetExerciseListByNameShouldReturnCorrectExercise()
        {
            // arrange
           
            var exerciseNameToFind = "Cocoons";

            // act
            var result = _exerciseListService.GetExerciseListByName(exerciseNameToFind);

            // assert
            Assert.NotNull(result);
            Assert.Equal(exerciseNameToFind, result.Name);
        }
    }
}

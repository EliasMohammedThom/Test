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
        public ExerciseListTests(TestDatabaseFixture fixture)
            => Fixture = fixture;

        public TestDatabaseFixture Fixture { get; }

        [Fact]
        public void ExerciseListShouldReturnExercises()
        {
            //arrange
            using var context = Fixture.CreateContext();
            var service = new ExerciseListService(context);

            //act
            var exerciseList = service.GetAllExerciseLists();

            //Assert
            Assert.Equal(550, exerciseList.Count);
        }
        [Fact]
        public void GetExerciseListByNameShouldReturnCorrectExerciseList()
        {
            // arrange
            using var context = Fixture.CreateContext();
            var service = new ExerciseListService(context);
            var exerciseNameToFind = "Cocoons";

            // act
            var result = service.GetExerciseListByName(exerciseNameToFind);

            // assert
            Assert.NotNull(result);
            Assert.Equal(exerciseNameToFind, result.Name);
        }
    }
}

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
        public void GetAllExerciseLists_ShouldReturnErrorMessage_WhenListIsEmpty(
        int id, string name, string type, string muscle, string equipment, string difficulty, string instructions)

        {
            //Arrange
            var sortedExercises = new List<ExerciseList>();
            var emptysortedExersises = new List<ExerciseList>();

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

            string errorMessage = "Can not find exercises with given parameters, try again!";

            // Act
            var result = _generatorService.ReturnErrorMessage(sortedExercises, errorMessage);
            var secondResult = _generatorService.ReturnErrorMessage(emptysortedExersises, errorMessage);

            // Assert
            Assert.Equal(errorMessage, secondResult);
            Assert.Null(result);
            Assert.NotEmpty(secondResult);
        }
        [Fact]
        public void FindEmptyWorkoutDaysInSchedule_ShouldFindEmptyDay()
        {
            // Arrange

            int Month = DateTime.Now.Month;
            var workoutList = new List<Workout>
            {
                new Workout {Date = new DateOnly(2024, Month,25), ScheduleId = 1},
                new Workout {Date = new DateOnly(2024, Month,26), ScheduleId = 1},
                new Workout {Date = new DateOnly(2024, Month,27), ScheduleId = 1}
            };

            var workout = new Workout();
            int scheduleid = 1;

            // Act
            _generatorService.FindEmptyWorkoutDaysInSchedule(workoutList, workout, scheduleid);

            // Assert
            Assert.Equal(new DateOnly(2024, Month,28), workout.Date);
            

        }


    }
}

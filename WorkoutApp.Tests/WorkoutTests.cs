namespace WorkoutApp.Tests
{
    public class WorkoutTests
    {
        [Fact]
        public void CanCreateWorkoutAndSaveToDatabase()
        {
            // Arrange
            //var inMemoryContext = new WorkoutContext();

            //var addworkouttodatabase = new WorkoutService(inMemoryContext);
            //var workout = new Workout()
            //{
            //    Name = "Legs"
            //};

            ////var moqDB = new Mock<WorkoutService>();
            ////moqDB.Setup(db => db.AddWorkout(It.IsAny<Workout>()));

            //// Act



            //addworkouttodatabase.AddWorkout(workout);

            // Assert
            //moqDB.Verify(db => db.AddWorkout(It.IsAny<Workout>()), Times.Once);

            // nu ska vi kolla att vår inmemorycontext innehåller workout


        }


        [Fact]
        public void CanAddExerciesToWorkout()
        {
            // Arrange

            // Act

            // Assert
        }
        [Fact]
        public void CanAddWorkoutsToSchedule()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}

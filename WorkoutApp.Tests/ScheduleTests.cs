using Core.Models;
using Infrastructure.Services;

namespace WorkoutApp.Tests
{
    [TestCaseOrderer(
    ordererTypeName: "WorkoutApp.Tests.AlphabeticalOrderer",
    ordererAssemblyName: "WorkoutApp.Tests")] 

    public class ScheduleTests : IClassFixture<TestDatabaseFixture>
    {
        private Schedule _schedule { get; set; }
        public ScheduleTests(TestDatabaseFixture fixture)
        {
            Fixture = fixture;
            _schedule = new Schedule
            {
                UserId = "test"
            };
        }
        public TestDatabaseFixture Fixture { get; }

        [Fact]
        public void T1AddScheduleShouldReturnAddedScheduleId()
        {
            //arrange
            using var context = Fixture.CreateContext();

            //act
            var service = new ScheduleService(context);
            service.AddSchedule(_schedule);
            var schedule = context.Schedules.First(b => b.Id == _schedule.Id);

            //assert
            Assert.Equal(_schedule.Id, schedule.Id);
        }
        [Fact]
        public void T2GetLastScheduleInDatabaseShouldReturnTestUserId()
        {
            //arrange
            using var context = Fixture.CreateContext();
            var service = new ScheduleService(context);

            //act
            _schedule = service.GetAllSchedules().LastOrDefault();

            //Assert
            Assert.Equal(_schedule.UserId, "test");
        }
        [Fact]
        public void T3UpdateScheduleShouldReturnNotNullSchedule()
        {
            //arrange
            using var context = Fixture.CreateContext();
            var service = new ScheduleService(context);
            var testSchedule = _schedule.UserId;

            //act
            service.UpdateSchedule(testSchedule, "updatedSchedule");
            var actual = service.GetScheduleByUserId("updatedSchedule");

            //assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void T4DeleteScheduleByScheduleIdShouldReturnNullAfterDeleted()
        {
            //arrange
            using var context = Fixture.CreateContext();
            var service = new ScheduleService(context);
            //act

            _schedule = service.GetAllSchedules().LastOrDefault();
            service.DeleteScheduleByScheduleId(_schedule.Id, _schedule);
            var actual = service.GetScheduleById(_schedule.Id);

            // assert
            Assert.Null(actual);
        }
    }
}

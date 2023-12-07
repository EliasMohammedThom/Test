using Core.Models;
using Infrastructure.Services;
using Infrastructure.Data;

namespace WorkoutApp.Tests
{
    [TestCaseOrderer(
    ordererTypeName: "WorkoutApp.Tests.AlphabeticalOrderer",
    ordererAssemblyName: "WorkoutApp.Tests")] 

    public class ScheduleTests : IClassFixture<TestDatabaseFixture>
    {
       
        private Schedule _schedule { get; set; }
        private ScheduleService _scheduleService { get; set; }
      
        public ScheduleTests(TestDatabaseFixture fixture)
        {
            Fixture = fixture;
         
            _schedule = new Schedule
            {
                UserId = "test"
            };

            var context = Fixture.CreateContext();
            
            _scheduleService = new ScheduleService(context);
        }
        public TestDatabaseFixture Fixture { get; }

        [Fact]
        public void T1AddScheduleShouldReturnAddedScheduleId()
        {
            //arrange
          

            _scheduleService.AddSchedule(_schedule);
             var schedule = _scheduleService.GetScheduleById(_schedule.Id);
            

            //assert
            Assert.Equal(_schedule.Id, schedule.Id);
        }
        [Fact]
        public void T2GetLastScheduleInDatabaseShouldReturnTestUserId()
        {
            //arrange
       
            //act
            _schedule = _scheduleService.GetScheduleByUserId("test");

            //Assert
            Assert.Equal(_schedule.UserId, "test");
        }
        [Fact]
        public void T3UpdateScheduleShouldReturnNotNullSchedule()
        {
            //arrange
          
            var testSchedule = _schedule.UserId;

            //act
            _scheduleService.UpdateSchedule(testSchedule, "updatedSchedule");
            var actual = _scheduleService.GetScheduleByUserId("updatedSchedule");

            //assert
            Assert.NotNull(actual);
        }
        [Fact]
        public void T4DeleteScheduleByScheduleIdShouldReturnNullAfterDeleted()
        {
            //arrange
            _schedule = _scheduleService.GetAllSchedules().LastOrDefault();
            //act


            _scheduleService.DeleteScheduleByScheduleId(_schedule.Id, _schedule);
            var actual = _scheduleService.GetScheduleById(_schedule.Id);

            // assert
            Assert.Null(actual);
        }
    }
}

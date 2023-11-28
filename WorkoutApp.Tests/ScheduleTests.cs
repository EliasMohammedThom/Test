using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Library.Models;
using Moq;

namespace WorkoutApp.Tests
{
    public class Schedule
    {
        [Fact]
        public void CanCreateScheduleIfTrueReturnSchedule()
        {
            // Arrange
            var schedule = new Library.Models.Schedule();

            // Act

            //Assert

            Assert.NotNull(schedule);
            Assert.Equal(0, schedule.Id); 
            Assert.Null(schedule.Title); 
            Assert.Null(schedule.Description); 
            Assert.Equal(DayOfWeek.Sunday, schedule.WeekDay); 
            Assert.Equal(0, schedule.Week);
            Assert.Equal(0, schedule.UserId);
        }

        [Fact]
        public void CanAddContentToCreatedSchedule()
        {
            // Arrange 
            var sut = new Library.Models.Schedule()
            {
                Id = 1,
                Title = "Test",
                Description = "Testar",
                WeekDay = DayOfWeek.Monday,
                Week = 47,
                UserId = 1
            };

            // Act

            // Assert
            Assert.NotNull(sut);
            Assert.Equal(1, sut.Id);
            Assert.Equal(sut.Title, "Test");
            Assert.Equal(sut.Description, "Testar");
            Assert.Equal(DayOfWeek.Monday, sut.WeekDay);
            Assert.Equal(47, sut.Week);
            Assert.Equal(1, sut.UserId);

        }

        //[Fact]
        //public void CanSaveScheduleToDataBase()
        //{
        //    // Arrange
        //    //var sut = new Domain.Schedule();

        //    //var mockDB = new Mock<WorkoutAppDbContext>();

        //    //var sut = new Domain.Schedule(mockDB.Object);
        //    // Act

            


        //    // Assert
        //}
    }
}

using GoldenSocks.UtkService.ApplicationCore.Entities;
using GoldenSocks.UtkService.ApplicationCore.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.Tests
{
    public class TimeSheetSrviceTests
    {
        [TestCase("Иванов")]
        public void TrackTime_ShouldReturnTrue(string lastName)
        {
            // arrange


            UserSession.Sessions.Add(lastName);

            var timeLog = new TimeLog
            {
                Date = new DateTime(),
                WorkingTimeHours = 1,
                LastName = lastName,
                Comment = Guid.NewGuid().ToString(),
                
            };

            var service = new TimeSheetSrvice();

            // act
            bool result = service.TrackTime(timeLog);

            // assert
            Assert.IsTrue(result);
        }

        // WorkingTimeHours = 25, - should return false 

        [TestCase(-1, "")]
        [TestCase(-1, null)]
        [TestCase(-1, "TestUser")]
        [TestCase(null, "")]
        [TestCase(null, null)]
        [TestCase(null, "TestUser")]
        [TestCase(25, "")]
        [TestCase(25, null)]
        [TestCase(25, "TestUser")]
        [TestCase(1, "")]
        [TestCase(1, null)]
        [TestCase(1, "TestUser")]
        public void TrackTime_ShouldReturnFalse(int hourse, string lastName)
        {
            // arrange

            var timeLog = new TimeLog
            {
                Date = new(),
                WorkingTimeHours = hourse,
                LastName = lastName,
                Comment = Guid.NewGuid().ToString()
            };

            var service = new TimeSheetSrvice();

            // act
            bool result = service.TrackTime(timeLog);

            // assert
            Assert.IsFalse(result);
        }
    }
}


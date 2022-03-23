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
        [TestCase("TestUser")]
        public void TrackTime_ShouldReturnTrue()
        {
            // arrange

            var expectedLastName = "TestUser";

            UserSession.Sessions.Add(expectedLastName);

            var timeLog = new TimeLog
            {
                Date = new DateTime(),
                WorkingTimeHours = 1,
                LastName = expectedLastName
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
                Date = new (),
                WorkingTimeHours = hourse,
                LastName = lastName
            };

            var service = new TimeSheetSrvice();

            // act
            bool result = service.TrackTime(timeLog);

            // assert
            Assert.IsFalse(result);
        }
    }
}


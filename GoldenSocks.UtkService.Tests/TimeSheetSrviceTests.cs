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
        [Test]
        public void TrackTime_ShouldReturnTrue()
        {
            // arrange

            var timeLog = new TimeLog
            {
                Date = new DateTime(),
                WorkingTimeHours = 1,
                LastName = "Иванов"
            };

            var service = new TimeSheetSrvice();

            // act
            bool result = service.TrackTime(timeLog);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TrackTime_ShouldReturnFalse()
        {
            // arrange

            var timeLog = new TimeLog
            {
                Date = DateTime.Today.AddDays(1),
                WorkingTimeHours = 1,
                LastName = "Иванов"
            };

            var service = new TimeSheetSrvice();

            // act
            bool result = service.TrackTime(timeLog);

            // assert
            Assert.IsFalse(result);
        }
    }
}


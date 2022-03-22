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

            // act
            bool result = service.TrackTime();

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TrackTime_ShouldReturnFalse()
        {
            // arrange

            var period = new DateTime();
            var workingTimeHours = 1;
            var lastName = "";

            var service = new TimeSheetSrvice();

            // act
            bool result = service.TrackTime();

            // assert
            Assert.IsFalse(result);
        }
    }
}


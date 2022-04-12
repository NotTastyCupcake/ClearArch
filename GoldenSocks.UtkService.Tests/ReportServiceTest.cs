using GoldenSocks.UtkService.ApplicationCore.Entities;
using GoldenSocks.UtkService.ApplicationCore.Interfaces;
using GoldenSocks.UtkService.ApplicationCore.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.Tests
{
    class ReportServiceTest
    {

        //(8+8+4)/160 * 70000

        [TestCase("Иванов2", 8750)]
        public void GetEmploeeReport_ShouldReturnReport(string lastName, decimal total)
        {
            //arrange
            var timeSheetRepositoryMock = new Mock<ITimeSheetRepository>();
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();


            timeSheetRepositoryMock.Setup(x => x.GetTimeLogs(It.Is<string>(y => y == lastName)))
                .Returns(() => new[]
                {
                    new TimeLog
                    {
                        LastName = lastName,
                        Date = DateTime.Now.AddDays(-2),
                        WorkingTimeHours = 8,
                        Comment = Guid.NewGuid().ToString()
                    },
                    new TimeLog
                    {
                        LastName = lastName,
                        Date = DateTime.Now.AddDays(-1),
                        WorkingTimeHours = 8,
                        Comment = Guid.NewGuid().ToString()
                    },
                    new TimeLog
                    {
                        LastName = lastName,
                        Date = DateTime.Now,
                        WorkingTimeHours = 4,
                        Comment = Guid.NewGuid().ToString()
                    }


                });

            employeeRepositoryMock.Setup(x => x.GetEmployee(It.Is<string>(y => y == lastName)))
                .Returns(() => new StaffEmployee { LastName = lastName, Salary =  70000});


            ReportService service = new ReportService(timeSheetRepositoryMock.Object, employeeRepositoryMock.Object);

            //act
            var result = service.GetEmployeeReport(lastName);

            //assert
            //timeSheetRepositoryMock.VerifyAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(lastName, result.LastName);

            Assert.IsNotNull(result.TimeLogs);
            Assert.IsNotEmpty(result.TimeLogs);

            Assert.AreEqual(total, result.Bill);
        }

    }
}

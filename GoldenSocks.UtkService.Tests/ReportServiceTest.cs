using GoldenSocks.UtkService.ApplicationCore.Services;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.Tests
{
    class ReportServiceTest
    {
        [TestCase("Иванов", 100)]
        public void GetEmploeeReport_ShouldReturnReport(string lastName, decimal total)
        {
            //arrange

            ReportService service = new ReportService();

            //act
            var result = service.GetEmployeeReport(lastName);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(lastName, result.LastName);

            Assert.IsNotNull(result.TimeLogs);
            Assert.IsNotEmpty(result.TimeLogs);

            Assert.AreEqual(total, result.Bill);
        }

    }

    class Report
    {


    }
}

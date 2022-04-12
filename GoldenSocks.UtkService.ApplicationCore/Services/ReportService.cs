using GoldenSocks.UtkService.ApplicationCore.Entities;
using GoldenSocks.UtkService.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.ApplicationCore.Services
{
    public class ReportService
    {
        private const decimal MAX_WORKING_HOURS_PER_MOUTH = 160m;

        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ReportService(ITimeSheetRepository timeSheetRepository, IEmployeeRepository employeeRepository)
        {
            _timeSheetRepository = timeSheetRepository;
            _employeeRepository = employeeRepository;
        }
            

        public EmployeeReport GetEmployeeReport(string lastName)
        {
            var employee = _employeeRepository.GetEmployee(lastName);
            var timeLogs = _timeSheetRepository.GetTimeLogs(employee.LastName);

            var hours = timeLogs.Sum(x => x.WorkingTimeHours);
            var bill = (hours / MAX_WORKING_HOURS_PER_MOUTH) * employee.Salary;

            return new EmployeeReport
            {
                LastName = employee.LastName,
                TimeLogs = timeLogs.ToList(),
                Bill = bill
            };
        }
    }
}

using GoldenSocks.UtkService.ApplicationCore.Entities;

namespace GoldenSocks.UtkService.ApplicationCore.Interfaces
{
    public interface IEmployeeRepository
    {
        StaffEmployee GetEmployee(string lastName);
    }
}

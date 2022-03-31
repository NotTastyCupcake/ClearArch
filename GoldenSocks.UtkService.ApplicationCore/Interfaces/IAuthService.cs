using System.Collections.Generic;

namespace GoldenSocks.UtkService.ApplicationCore.Interfaces
{
    public interface IAuthService
    {
        List<string> Employees { get; }

        bool Login(string lastName);
    }
}
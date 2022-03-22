using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.ApplicationCore.Services
{
    public class AuthService
    {
        public AuthService()
        {
            Employees = new List<string>
            {
                "Иванов","Петров", "Сидоров"
            };
        }

        public List<string> Employees { get; private set; }

        public bool Login(string lastName)
        {
            if(string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }

            bool isEmployeesExist = Employees.Contains(lastName);

            if(isEmployeesExist)
            {
                UserSession.Sessions.Add(lastName);
            }

            return isEmployeesExist;
        }
    }
    public static class UserSession
    {
        static UserSession() => Sessions = new HashSet<string>();
        public static HashSet<string> Sessions { get; set; }
    }
}

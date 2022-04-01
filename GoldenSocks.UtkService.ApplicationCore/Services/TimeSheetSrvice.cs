using GoldenSocks.UtkService.ApplicationCore.Entities;
using GoldenSocks.UtkService.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.ApplicationCore.Services
{
    public class TimeSheetSrvice : ITimeSheetSrvice
    {
        public bool TrackTime(TimeLog timeLog)
        {
            bool isValidWorkingTimeHours = timeLog.WorkingTimeHours > 0 && timeLog.WorkingTimeHours <= 24;
            bool isValidLastName = !string.IsNullOrWhiteSpace(timeLog.LastName) && UserSession.Sessions.Contains(timeLog.LastName);
            bool isValidData = timeLog.Date < DateTime.Now;


            if (isValidWorkingTimeHours && isValidLastName && isValidData)
            { TimeSheetSrviceSession.Sessions.Add(timeLog); return true; }
            else
            { return false; }
        }
    }

    public static class TimeSheetSrviceSession
    {
        public static List<TimeLog> Sessions { get; set; } = new List<TimeLog>();
    }

}

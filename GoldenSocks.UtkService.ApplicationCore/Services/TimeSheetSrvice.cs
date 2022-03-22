using GoldenSocks.UtkService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.ApplicationCore.Services
{
    public class TimeSheetSrvice
    {
        public bool TrackTime(TimeLog timeLog)
        {
            if (string.IsNullOrWhiteSpace(timeLog.LastName) 
                || timeLog.Date > DateTime.Now )
                return false;

            TimeSheetSrviceSession.Sessions.Add(timeLog);

            return true;
        }
    }

    public static class TimeSheetSrviceSession
    {
        public static List<TimeLog> Sessions { get; set; } = new List<TimeLog>();
    }

}

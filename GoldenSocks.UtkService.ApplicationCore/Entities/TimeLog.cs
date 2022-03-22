using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.ApplicationCore.Entities
{
    public class TimeLog
    {
        public DateTime Date { get; set; }
        public int WorkingTimeHours { get; set; }

        public string LastName { get; set; }
    }
}

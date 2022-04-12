using GoldenSocks.UtkService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.ApplicationCore.Interfaces
{
    public interface ITimeSheetRepository
    {
        TimeLog[] GetTimeLogs(string lastName);
    }
}

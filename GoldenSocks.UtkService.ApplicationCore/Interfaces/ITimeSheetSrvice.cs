using GoldenSocks.UtkService.ApplicationCore.Entities;

namespace GoldenSocks.UtkService.ApplicationCore.Interfaces
{
    public interface ITimeSheetSrvice
    {
        bool TrackTime(TimeLog timeLog);
    }
}
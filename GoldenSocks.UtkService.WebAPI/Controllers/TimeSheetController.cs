using GoldenSocks.UtkService.ApplicationCore.Entities;
using GoldenSocks.UtkService.ApplicationCore.Interfaces;
using GoldenSocks.UtkService.WebAPI.ResourceModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSheetController : ControllerBase
    {
        private readonly ITimeSheetSrvice _timeSheet;

        public TimeSheetController(ITimeSheetSrvice timeSheet)
        {
            this._timeSheet = timeSheet;
        }

        public IActionResult Index(TimeLog timeLog)
        {
            return Ok(_timeSheet.TrackTime(timeLog));
        }
    }
}

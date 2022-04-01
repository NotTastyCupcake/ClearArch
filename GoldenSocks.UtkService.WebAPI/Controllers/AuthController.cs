using GoldenSocks.UtkService.ApplicationCore.Entities;
using GoldenSocks.UtkService.ApplicationCore.Interfaces;
using GoldenSocks.UtkService.ApplicationCore.Services;
using GoldenSocks.UtkService.WebAPI.ResourceModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenSocks.UtkService.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest person)
        {
            //var authService = new AuthService();

            if(person == null)
            {
                return NotFound();
            }

            return Ok(_authService.Login(person.LastName));
        }


    }
}

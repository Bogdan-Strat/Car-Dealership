using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Managers;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private /*readonly*/ IAuthentificationManager authentificationManager;

        public AuthentificationController(IAuthentificationManager authentificationManager)
        {
            this.authentificationManager = authentificationManager;
        }

        [HttpPost("Sign-up")]

        public async Task<IActionResult> SignUp([FromBody] RegisterModel registerModel)
        {
            try
            {
                await authentificationManager.SignUp(registerModel);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest("Something failed");
            }
            
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {

                var tokens = await authentificationManager.Login(loginModel);

                if (tokens != null)
                {
                    return Ok(tokens);
                }
                else
                {
                    return BadRequest("Failed to login.");
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Exception caught");
            }
            
        }
    }
}

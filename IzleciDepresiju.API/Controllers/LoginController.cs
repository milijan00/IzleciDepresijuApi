using IzleciDepresiju.Api.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IzleciDepresiju.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private JwtManager _manager;

        public LoginController(JwtManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]LoginRequest request)
        {
             try
            {
                var token = _manager.MakeToken(request.Email, request.Password);

                return Ok(new { token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (System.Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
    public class LoginRequest 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}

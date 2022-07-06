using IzleciDepresiju.API.Extensions;
using IzleciDepresiju.Application.UseCases.Queries;
using IzleciDepresiju.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzleciDepresiju.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private UseCaseHandler _handler;

        public UsersController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromServices] IGetUsersQuery query)
        {
            return this.HandleUseCase(() =>
            {
                return Ok(this._handler.HandleQuery(query));
            });
        }
    }
}

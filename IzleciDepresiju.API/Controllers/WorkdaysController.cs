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
    public class WorkdaysController : ControllerBase
    {
        private UseCaseHandler _handler;

        public WorkdaysController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromServices] IGetWorkdaysQuery query)
        {
            return this.HandleUseCase(() => {
                return Ok(this._handler.HandleQuery(query)); 
            });
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id, [FromServices] IGetWorkdaysOfTherapistQuery query)
        {
            return this.HandleUseCase(() => {
                return Ok(this._handler.HandleQuery(query, id)); 
            });
        }

    }
}

using IzleciDepresiju.API.Extensions;
using IzleciDepresiju.Application.UseCases.Dto.searches;
using IzleciDepresiju.Application.UseCases.Queries;
using IzleciDepresiju.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzleciDepresiju.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private UseCaseHandler _handler;

        public TimesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromServices] IGetTimesQuery query)
        {
            return this.HandleUseCase(() =>
            {
                return Ok(this._handler.HandleQuery(query));
            });
        }
        //[Route("api/times/u/{uid}/w/{wid}")]
        [HttpGet("{uid}/{wid}")]
        [Authorize]
        public IActionResult Get(int uid, int wid,  [FromServices] IGetTimesFromAvailableAppointmentsQuery query)
        {
            return this.HandleUseCase(() =>
            {
                return Ok(this._handler.HandleQuery(query, new SearchTimeDto
                {
                    UserId = uid,
                    WorkdayId = wid
                }));
                //return Ok(this._handler.HandleQuery(query, dto));
            });
        }
    }
}

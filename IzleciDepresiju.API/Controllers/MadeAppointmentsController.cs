using IzleciDepresiju.API.Extensions;
using IzleciDepresiju.Application.UseCases.Commands;
using IzleciDepresiju.Application.UseCases.Dto;
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
    public class MadeAppointmentsController : ControllerBase
    {
        private UseCaseHandler _handler;

        public MadeAppointmentsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromServices] IGetMadeAppointmentsQuery query)
        {
            return this.HandleUseCase(() =>
            {
                return Ok(this._handler.HandleQuery(query));
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetSpecificMadeAppointmentsQuery query)
        {
            return this.HandleUseCase(() =>
            {
                return Ok(this._handler.HandleQuery(query, id));
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateMadeAppointmentDto dto, [FromServices] ICreateMadeAppointmentCommand command)
        {
            return this.HandleUseCase(() =>
            {
                this._handler.HandleCommand(command, dto);
                return StatusCode(201);
            });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteMadeAppoointmentCommand command)
        {
            return this.HandleUseCase(() =>
            {
                this._handler.HandleCommand(command, id);
                return NoContent();
            });
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateMadeAppointmentDto dto, [FromServices] IUpdateMadeAppointmentCommand command)
        {
            return this.HandleUseCase(() =>
            {
                this._handler.HandleCommand(command, dto);
                return NoContent();
            });
        }
    }
}

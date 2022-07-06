using IzleciDepresiju.API.Extensions;
using IzleciDepresiju.Application.UseCases.Commands;
using IzleciDepresiju.Application.UseCases.Dto;
using IzleciDepresiju.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzleciDepresiju.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UseCaseController : ControllerBase
    {
        private UseCaseHandler _handler;

        public UseCaseController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUseCaseDto dto, [FromServices] ICreateUseCaseCommand command)
        {
            return this.HandleUseCase(() =>
            {
                this._handler.HandleCommand(command, dto);
                return StatusCode(201);
            });
        }
    }
}

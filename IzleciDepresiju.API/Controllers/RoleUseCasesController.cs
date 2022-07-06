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
    public class RoleUseCasesController : ControllerBase
    {
        private UseCaseHandler _handler;

        public RoleUseCasesController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] UpdateRoleUseCasesDto dto, [FromServices] IUpdateRoleUseCasesCommand command)
        {
            return this.HandleUseCase(() =>
            {
                this._handler.HandleCommand(command, dto);
                return NoContent();
            });
        }
    }
}

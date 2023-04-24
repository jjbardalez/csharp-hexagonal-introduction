using MediatR;
using Caba.Application.Commands.User.CreateUser;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Caba.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(template: "users")]
        [SwaggerResponse(200, "Retorna ID de Usuario creado")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request) {
            var result = await _mediator.Send(request);
            return Ok($"Se creó el usuario con el Id: {result}");
        }
    }
}

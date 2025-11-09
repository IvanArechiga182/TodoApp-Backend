using Microsoft.AspNetCore.Mvc;
using MediatR;
using TodoApp.Application.Features.Users.Login;
using TodoApp.Application.Features.Users.Register;
namespace TodoApp.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;
        public AuthController(ILogger<AuthController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
                var result = await _mediator.Send(request);
                return StatusCode(result.Status, result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(result.Status, result);
        }

       

    }
}

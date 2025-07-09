using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Users.Commands;
using MyApp.Application.Users.Queries;
using MyApp.Domain.UnitOfWork;
using System.Security.Claims;

namespace MyApp.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var token = await _mediator.Send(command);
            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet("secure-data")]
        public IActionResult SecureData()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.Identity.Name;

            return Ok(new { Message = "Token is valid!", UserId = userId, UserName = userName });
        }


        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(new { Id = userId });
        }

        [HttpGet]
        public async Task<IActionResult> SearchUsers([FromQuery] string userName)
        {
            var users = await _mediator.Send(new SearchUsersQuery(userName));
            return Ok(users);
        }
    }
}
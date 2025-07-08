using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Users.Commands;
using MyApp.Application.Users.Queries;
using MyApp.Domain.UnitOfWork;

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

        [HttpPost]
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
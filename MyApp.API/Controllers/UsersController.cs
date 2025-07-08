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
            private readonly IUnitOfWork _unitOfWork;

            public UsersController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            [HttpPost]
            public IActionResult AddUser([FromBody] AddUserCommand command)
            {
                var handler = new AddUserCommandHandler(_unitOfWork);
                handler.Handle(command);
                return Ok(new { message = "User added successfully." });
            }

            [HttpGet]
            public IActionResult SearchUser([FromQuery] string userName)
            {
                var handler = new SearchUsersQueryHandler(_unitOfWork);
                var users = handler.Handle(new SearchUsersQuery { UserName = userName });
                return Ok(users);
            }
        }
}

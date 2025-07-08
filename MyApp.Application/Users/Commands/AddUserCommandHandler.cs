using MyApp.Domain.Entities;
using MyApp.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Users.Commands
{
    public class AddUserCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(AddUserCommand command)
        {
            var user = new User(command.UserName, command.FirstName, command.LastName);
            _unitOfWork.Repository<User>().Add(user);
            _unitOfWork.Commit();
        }
    }
}

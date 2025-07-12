using MediatR;
using MyApp.Domain.Entities;
using MyApp.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Users.Commands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(request.UserName, request.Password, request.RoleId);
            _unitOfWork.Repository<User>().Add(user);
            _unitOfWork.Commit();
            return Task.FromResult(user.Id);
        }
    }
}

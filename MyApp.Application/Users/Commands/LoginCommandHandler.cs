using MediatR;
using MyApp.Application.Services;
using MyApp.Domain.Entities;
using MyApp.Domain.Specifications.Users;
using MyApp.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;  
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Application.Users.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public LoginCommandHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator tokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Repository<User>()
                .Find(new UserByNameSpecification(request.UserName))
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null || !user.VerifyPassword(request.Password))
                throw new UnauthorizedAccessException("Invalid username or password");

            var token = _tokenGenerator.GenerateToken(user);
            return token;
        }
    }
}

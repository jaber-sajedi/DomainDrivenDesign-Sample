using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Users.Commands
{
    public record AddUserCommand(string UserName, string FirstName, string LastName) : IRequest<Guid>;
}

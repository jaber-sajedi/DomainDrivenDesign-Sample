using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Users.Commands
{
    public record LoginCommand(string UserName, string Password) : IRequest<string>;
}

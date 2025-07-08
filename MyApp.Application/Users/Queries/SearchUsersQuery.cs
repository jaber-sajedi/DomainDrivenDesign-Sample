using AutoMapper;
using MediatR;
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;
using MyApp.Domain.Specifications.Users;
using MyApp.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Users.Queries
{
    public record SearchUsersQuery(string UserName) : IRequest<List<UserDto>>;
}

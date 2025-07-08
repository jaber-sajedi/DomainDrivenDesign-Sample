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
    public class SearchUsersQueryHandler : IRequestHandler<SearchUsersQuery, List<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<UserDto>> Handle(SearchUsersQuery request, CancellationToken cancellationToken)
        {
            var spec = new UserByNameSpecification(request.UserName);
            var users = _unitOfWork.Repository<User>().Find(spec);
            var dtos = _mapper.Map<List<UserDto>>(users);
            return Task.FromResult(dtos);
        }
    }
}

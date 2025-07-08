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
    public class SearchUsersQueryHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> Handle(SearchUsersQuery query)
        {
            var spec = new UserByNameSpecification(query.UserName);
            return _unitOfWork.Repository<User>().Find(spec);
        }
    }
}

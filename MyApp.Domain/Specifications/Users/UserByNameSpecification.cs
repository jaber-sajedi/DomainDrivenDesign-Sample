using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Specifications.Users
{
    public class UserByNameSpecification : BaseSpecification<User>
    {
        public UserByNameSpecification(string userName)
            : base(x => string.IsNullOrEmpty(userName) || x.UserName.Contains(userName))
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        // EF Core نیاز به سازنده بدون پارامتر دارد
        protected User() { }

        private User(Guid id, string userName, string firstName, string lastName)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }

        public static User Create(string userName, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("UserName is required.");

            return new User(Guid.NewGuid(), userName, firstName, lastName);
        }
    }

}

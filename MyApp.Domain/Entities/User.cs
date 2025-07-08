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

        // فقط داخل کلاس اجازه تغییر هست
        public User(string userName, string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }

        // متد مخصوص تغییر داخل کلاس
        public void UpdateName(string newName)
        {
            UserName = newName;
        }
    }
}

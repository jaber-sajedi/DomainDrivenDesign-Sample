using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;

        // افزودن اطلاعات مربوط به نقش
        public Guid RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }

}

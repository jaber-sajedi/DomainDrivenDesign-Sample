using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class User
{
    public Guid Id { get; private set; }

    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public Guid RoleId { get; private set; }
    public virtual Role Role { get; private set; } = null!;

    private User(Guid id, string userName, string passwordHash, Guid roleId)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        RoleId = roleId;
    }

    public static User Create(string userName, string password, Guid roleId)
    {
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("UserName and Password are required.");

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        return new User(Guid.NewGuid(), userName, passwordHash, roleId);
    }

    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    }
}


 

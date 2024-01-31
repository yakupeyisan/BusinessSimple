using System;
using Core.Repository;

namespace Core.Entities;

public class User:Entity
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public short BirthYear { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string IdentificationNumber { get; set; }
    public virtual ICollection<UserClaim> UserClaims { get; set; }
    public User()
    {
        UserClaims = new HashSet<UserClaim>();
    }
}

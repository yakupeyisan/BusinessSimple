using System;
namespace Entities.DTOs;

public class UserForLoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class UserForRegisterDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentificationNumber { get; set; }
    public short BirthYear { get; set; }
}

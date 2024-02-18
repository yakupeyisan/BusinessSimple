using System;
using Core.Entities;

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

public class AddUserDto
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentificationNumber { get; set; }
    public short BirthYear { get; set; }

    public User GetUser()
    {
        return new()
        {
            BirthYear = BirthYear,
            FirstName = FirstName,
            LastName = LastName,
            UserName = UserName,
            IdentificationNumber = IdentificationNumber,
        };
    }
}

public class ViewUserDto
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string IdentificationNumber { get; set; }
    public short BirthYear { get; set; }

    public ViewUserDto(User user)
    {
        UserName=user.UserName;
        FirstName=user.FirstName;
        LastName=user.LastName;
        IdentificationNumber=user.IdentificationNumber;
        BirthYear=user.BirthYear;
    }
}
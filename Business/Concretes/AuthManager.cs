using Business.Abstracts;
using Business.Validations;
using Core.Entities;
using Core.Utilities.Security.Helper;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.Models;
using Entities.DTOs;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly AuthValidations _authValidations;
    public AuthManager(IUserService userService,ITokenHelper tokenHelper, AuthValidations authValidations)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _authValidations = authValidations;
    }

    public TokenModel Register(UserForRegisterDto userForRegisterDto)
    {
        var user= new User();
        user.IdentificationNumber = userForRegisterDto.IdentificationNumber;
        user.FirstName = userForRegisterDto.FirstName;
        user.LastName = userForRegisterDto.LastName;
        user.BirthYear = userForRegisterDto.BirthYear;
        user.UserName = userForRegisterDto.UserName;
        byte[] passwordHash;
        byte[] passwordSalt;
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out passwordHash, out passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        _userService.Add(user);
        return _tokenHelper.CreateToken(user);
    }

    public TokenModel SignIn(UserForLoginDto userForLoginDto)
    {
        var user = _userService.GetByUserNameWithClaims(userForLoginDto.UserName);
        _authValidations.UserMustNotBeEmpty(user).Wait();
        _authValidations.UserClaimMustNotBeEmpty(user).Wait();
        _authValidations.PasswordValidate(user, userForLoginDto.Password).Wait();
        return _tokenHelper.CreateToken(user);

    }
}
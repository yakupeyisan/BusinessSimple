using System;
using Business.Tools.Exceptions;
using Core.Entities;
using Core.Utilities.Security.Helper;

namespace Business.Validations;

	public class AuthValidations
{
    public async Task UserMustNotBeEmpty(User? user)
    {
        if (user == null)
        {
            throw new ValidationException("Username or password does not match.");
        }
        await Task.CompletedTask;
    }
    public async Task UserClaimMustNotBeEmpty(User user)
    {
        return;

        if(user.UserClaims.Count==0)
            throw new ValidationException("User has not any 'Claim'. Please contact to system manager.");
    }
    public async Task PasswordValidate(User user,string password)
    {
        var result=HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
        if(!result)
            throw new ValidationException("Username or password does not match.");
    }
}


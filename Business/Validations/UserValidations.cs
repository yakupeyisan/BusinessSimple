using System;
using Business.Tools.Exceptions;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using DataAccess.Abstracts;

namespace Business.Validations;

public class UserValidations : BaseValidation
{
    protected readonly IUserRepository _userRepository;
    public UserValidations(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task UserMustNotBeEmpty(User? user)
    {
        if (user == null)
        {
            throw new ValidationException("User must not be empty.", 400);
        }
        await Task.CompletedTask;
    }

    public async Task UserNameControl(User? user)
    {
        if (user.UserName == "string")
        {
            throw new ValidationException("Username must not be string.", 400);
        }
    }
    public async Task FirstNameControl(User? user)
    {
        if (user.FirstName == "string")
        {
            throw new ValidationException("Firstname must not be string.", 400);
        }
    }
}

public class AddUserValidation : UserValidations
{
    public AddUserValidation(IUserRepository userRepository) : base(userRepository)
    {
    }

}
public class UpdateUserValidation : UserValidations
{
    public UpdateUserValidation(IUserRepository userRepository) : base(userRepository)
    {
    }

}
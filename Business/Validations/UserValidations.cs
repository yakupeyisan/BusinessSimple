using System;
using Business.Tools.Exceptions;
using Core.Entities;

namespace Business.Validations;

public class UserValidations
{
    public async Task UserMustNotBeEmpty(User? user)
    {
        if (user == null)
        {
            throw new ValidationException("User must not be empty.",500);
        }
        await Task.CompletedTask;
    }
}

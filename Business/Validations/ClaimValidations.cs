using Business.Tools.Exceptions;
using Core.Entities;

namespace Business.Validations;

public class ClaimValidations
{
    public async Task ClaimMustNotBeEmpty(Claim? claim)
    {
        if (claim == null)
        {
            throw new ValidationException("Claim must not be empty.", 500);
        }
        await Task.CompletedTask;
    }
}
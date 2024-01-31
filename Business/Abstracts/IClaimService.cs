
using Core.Entities;

namespace Business.Abstracts;

public interface IClaimService
{
    Claim? GetById(Guid id);
    Task<Claim?> GetByIdAsync(Guid id);
    IList<Claim> GetAll();
    Task<IList<Claim>> GetAllAsync();
    IList<Claim> GetAllByUserId(Guid userId);
    Task<IList<Claim>> GetAllByUserIdAsync(Guid userId);
    Claim Add(Claim claim);
    Claim Update(Claim claim);
    void DeleteById(Guid id);
    Task<Claim> AddAsync(Claim claim);
    Task<Claim> UpdateAsync(Claim claim);
    Task DeleteByIdAsync(Guid id);
}


using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ClaimManager : IClaimService
{
    private readonly IClaimRepository _claimRepository;
    private readonly ClaimValidations _claimValidations;
    public ClaimManager(IClaimRepository claimRepository,ClaimValidations claimValidations)
    {
        _claimRepository = claimRepository;
        _claimValidations = claimValidations;
    }

    public Claim Add(Claim claim)
    {
        return _claimRepository.Add(claim);
    }

    public async Task<Claim> AddAsync(Claim claim)
    {
        return await _claimRepository.AddAsync(claim);
    }

    public void DeleteById(Guid id)
    {
        var claim = _claimRepository.Get(c=>c.Id==id);
        _claimValidations.ClaimMustNotBeEmpty(claim).Wait();
        _claimRepository.Delete(claim);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var claim = _claimRepository.Get(c => c.Id == id);
        await _claimValidations.ClaimMustNotBeEmpty(claim);
        await _claimRepository.DeleteAsync(claim);
    }

    public IList<Claim> GetAll()
    {
        return _claimRepository.GetAll().ToList();
    }

    public async Task<IList<Claim>> GetAllAsync()
    {
        var result= await _claimRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<Claim> GetAllByUserId(Guid userId)
    {
        return _claimRepository.GetAll(c => c.UserClaim.UserId == userId, include: claim => claim.Include(c => c.UserClaim)).ToList();
    }

    public async Task<IList<Claim>> GetAllByUserIdAsync(Guid userId)
    {
        var result = await _claimRepository.GetAllAsync(c => c.UserClaim.UserId == userId, include: claim => claim.Include(c => c.UserClaim));
        return result.ToList();
    }

    public Claim? GetById(Guid id)
    {
        return _claimRepository.Get(c=>c.Id==id);
    }

    public async Task<Claim?> GetByIdAsync(Guid id)
    {
        return await _claimRepository.GetAsync(c => c.Id == id);
    }

    public Claim Update(Claim claim)
    {
        return _claimRepository.Update(claim);
    }

    public async Task<Claim> UpdateAsync(Claim claim)
    {
        return await _claimRepository.UpdateAsync(claim);
    }
}
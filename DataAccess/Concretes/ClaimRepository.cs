using Core.Entities;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class ClaimRepository : Repository<Claim>, IClaimRepository
{
    public ClaimRepository(BusinessDbContext context) : base(context)
    {
    }
}


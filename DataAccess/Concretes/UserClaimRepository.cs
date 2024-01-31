using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Core.Entities;

namespace DataAccess.Concretes;

public class UserClaimRepository : Repository<UserClaim>, IUserClaimRepository
{
    public UserClaimRepository(BusinessDbContext context) : base(context)
    {
    }
}


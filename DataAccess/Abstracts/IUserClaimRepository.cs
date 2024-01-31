using Core.Repository;
using Core.Entities;

namespace DataAccess.Abstracts;

public interface IUserClaimRepository : IAsyncRepository<UserClaim>, IRepository<UserClaim>
{
}


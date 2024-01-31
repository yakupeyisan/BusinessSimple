using Core.Entities;
using Core.Repository;

namespace DataAccess.Abstracts;

public interface IClaimRepository : IAsyncRepository<Claim>, IRepository<Claim>
{
}


using System;
using Core.Repository;
using Core.Entities;

namespace DataAccess.Abstracts;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
}


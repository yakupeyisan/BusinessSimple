using System;
using Core.Repository;
using Entities.Models;

namespace DataAccess.Abstracts;

public interface IUserRepository:IAsyncRepository<User>,IRepository<User>
{
}


using System;
using Core.Entities;
using Core.Repository;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Models;

namespace DataAccess.Concretes;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(BusinessDbContext context) : base(context)
    {
    }
}


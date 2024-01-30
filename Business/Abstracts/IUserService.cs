using System;
using Entities.Models;

namespace Business.Abstracts;

public interface IUserService
{
    User? GetById(Guid id);
    Task<User?> GetByIdAsync(Guid id);
    IList<User> GetAll();
    Task<IList<User>> GetAllAsync();
    IList<User> GetAllByFirstName(string firstName);
    IList<User> GetAllByLastName(string lastName);
    IList<User> GetAllByBirthDate(short birthDate);
    IList<User> GetAllByBirthDateGratherThan(short birthDate);
    IList<User> GetAllByBirthDateLessThan(short birthDate);
    IList<User> GetAllByFirstNameContains(string firstName);
    User Add(User user);
    User Update(User user);
    void DeleteById(Guid id);
    Task<User> AddAsync(User user);
    Task<User> UpdateAsync(User user);
    Task DeleteByIdAsync(Guid id);
}


using System;
using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class UserManager : IUserService
{
    public readonly IUserRepository _userRepository;
    private readonly UserValidations _userValidations;
    public UserManager(IUserRepository userRepository,UserValidations userValidations)
    {
        _userRepository = userRepository;
        _userValidations = userValidations;
    }
    public User Add(User user)
    {
        return _userRepository.Add(user);
    }

    public async Task<User> AddAsync(User user)
    {
        return await _userRepository.AddAsync(user);
    }

    public void DeleteById(Guid id)
    {
        var user=_userRepository.Get(u=>u.Id==id);
        _userValidations.UserMustNotBeEmpty(user).Wait();
        _userRepository.Delete(user);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var user = _userRepository.Get(u => u.Id == id);
        await _userValidations.UserMustNotBeEmpty(user);
        await _userRepository.DeleteAsync(user);
    }

    public IList<User> GetAll()
    {
        return _userRepository.GetAll().ToList();
    }

    public async Task<IList<User>> GetAllAsync()
    {
        var result= await _userRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<User> GetAllByBirthDate(short birthDate)
    {
        return _userRepository.GetAll(u=>u.BirthYear==birthDate).ToList();
    }

    public IList<User> GetAllByBirthDateGratherThan(short birthDate)
    {
        return _userRepository.GetAll(u => u.BirthYear > birthDate).ToList();
    }

    public IList<User> GetAllByBirthDateLessThan(short birthDate)
    {
        return _userRepository.GetAll(u => u.BirthYear < birthDate).ToList();

    }

    public IList<User> GetAllByFirstName(string firstName)
    {
        return _userRepository.GetAll(u => u.FirstName == firstName).ToList();

    }

    public IList<User> GetAllByFirstNameContains(string firstName)
    {
        return _userRepository.GetAll(u => u.FirstName.Contains(firstName)).ToList();
    }

    public IList<User> GetAllByLastName(string lastName)
    {
        return _userRepository.GetAll(u => u.LastName == lastName).ToList();
    }


    public User? GetById(Guid id)
    {
        return _userRepository.Get(u=>u.Id==id);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _userRepository.GetAsync(u => u.Id == id);
    }

    public User Update(User user)
    {
        return _userRepository.Update(user);
    }

    public async Task<User> UpdateAsync(User user)
    {
       return await _userRepository.UpdateAsync(user);
    }

    public User? GetByUserNameWithClaims(string userName)
    {
       return _userRepository.Get(u => u.UserName == userName, include: user => user.Include(u => u.UserClaims).ThenInclude(uc => uc.Claim));
    }
    public async Task<User?> GetByUserNameWithClaimsAsync(string userName)
    {
        return await _userRepository.GetAsync(u => u.UserName == userName, include: user => user.Include(u => u.UserClaims).ThenInclude(uc => uc.Claim));
    }
}

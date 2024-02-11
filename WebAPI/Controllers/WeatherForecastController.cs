using System.Text.Json;
using Core.Entities;
using DataAccess.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public WeatherForecastController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("TestGetUsers")]
    public IActionResult ListUsers()
    {
        return Ok(_userRepository.GetAll());
    }
    [HttpGet("TestAddUser")]
    public IActionResult Add(User user)
    {
        //yetki kontrolü
            _userRepository.Add(user);
            return Ok();
    }
    [HttpGet("TestUpdateUser")]
    public IActionResult Update(User user)
    {
        _userRepository.Update(user);
        return Ok();
    }
}
//Kod okunabiliği arttı (Readabilty )
//Kodun modularitesi arttı 
//Temiz kod yazdık (Clean Coding)
//Kodun kullanılabilirliği arttı (Reusability)
//Tekrar eden kodlardan kurtulduk. (DRY--- Do not repeat yourself)
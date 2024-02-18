using Business.Abstracts;
using Core.Entities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(
        IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        
        return Ok(users.Select(user=>new ViewUserDto(user)));
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddUserDto userDto)
    {;
        return Ok(await _userService.AddAsync(userDto.GetUser()));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] User user)
    {
        user.PasswordHash = new byte[] { 0x0f };
        user.PasswordSalt = new byte[] { 0x0f };
        return Ok(await _userService.UpdateAsync(user));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.DeleteByIdAsync(id);
        return Ok();
    }
}



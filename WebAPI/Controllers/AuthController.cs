using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("SignIn")]
    public IActionResult SignIn([FromBody] UserForLoginDto userForLoginDto)
    {
        return Ok(_authService.SignIn(userForLoginDto));
    }
    [HttpPost("Register")]
    public IActionResult Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        return Ok(_authService.Register(userForRegisterDto));
    }

}


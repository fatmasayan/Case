﻿using Case.DTOs;
using Case.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Case.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        if(id==null ||  id<=0) return NotFound();

        return Ok(await _userService.GetUserAsync(id));
    }


    [HttpPost("CreateUser")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser([FromBody] CreateUser createUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(await _userService.CreateUserAsync(createUser));
    }


    [HttpPut("UpdateUser")]
    
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUser updateUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(await _userService.UpdateUserAsync(updateUser));
    }


}

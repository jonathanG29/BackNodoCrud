using AztroWebApplication1.Models;
using AztroWebApplication1.Data;
using AztroWebApplication1.Services;
using Microsoft.AspNetCore.Mvc;
// using AztroWebApplication1.Repositories;

namespace AztroWebApplication1.Controllers;


// public interface IUser
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public string Email { get; set; }
//     public int Age { get; set; }
// }

[ApiController]
[Route("api/[controller]")]
public class UserController(ApplicationDbContext context) : ControllerBase
{
    private readonly UserService userService = new(context);


    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users =await userService.GetAllUsers();

        return Ok(users);
    }
    
    // New endpoint to get a user by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userService.GetUserById(id);

        if (user == null)
        {
            return NotFound(new ErrorResponse {Message = "User not found", StatusCode = 404});
        }

        return Ok(user);  
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        var createUser = await userService.CreateUser(user);
        return Created(nameof(CreateUser), createUser);
    }

}

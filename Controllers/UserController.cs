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
public class UserController : ControllerBase
{
    private readonly UserService userService;

    public UserController(ApplicationDbContext context)
    {
        userService = new UserService(context);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users =await userService.GetAllUsers();

        return Ok(users);
    }
    
    // New endpoint to get a user by ID
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = userService.GetUserById(id);

        if (user == null)
        {
            return NotFound(new ErrorResponse {Message = "User not found", StatusCode = 404});
        }

        return Ok(user);  
    }

    [HttpPost]
    public IActionResult CreateUser()
    {
        var user = userService.CreateUser();

        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id)
    {
        var user = userService.UpdateUser(id);

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = userService.DeleteUser(id);

        return Ok(user);
    }

}

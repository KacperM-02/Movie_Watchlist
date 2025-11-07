using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(MongoDbService mongoDbService) : ControllerBase
{
    [HttpGet]
    public async Task<List<User>> Get()
    {
        return await mongoDbService.GetAllUsersAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        await mongoDbService.InsertUserAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }
}
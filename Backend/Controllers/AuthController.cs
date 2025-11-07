using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(MongoDbService mongoDbService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken);
            var existingUser = await mongoDbService.GetUserByEmailAsync(payload.Email);

            if (existingUser != null)
            {
                return Ok(new
                {
                    existingUser.Email,
                    existingUser.Name,
                    existingUser.Picture
                });
            }

            var newUser = new User
            {
                Email = payload.Email,
                Name = payload.Name,
                Picture = payload.Picture,
            };

            await mongoDbService.InsertUserAsync(newUser);
            existingUser = newUser;

            return Ok(new
            {
                existingUser.Email,
                existingUser.Name,
                existingUser.Picture
            });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = "Invalid Google token", error = ex.Message });
        }
    }
}

public class LoginRequest
{
    public string IdToken { get; set; } = null!;
}

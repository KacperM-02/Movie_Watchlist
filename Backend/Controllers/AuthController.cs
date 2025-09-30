using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken);
            
            return Ok(new
            {
                payload.Email,
                payload.Name,
                payload.Picture
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

using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Controller]
[Route("api/[controller]")]
public class MovieController : Controller
{
    private readonly MongoDBService _mongoDbService;
    
}
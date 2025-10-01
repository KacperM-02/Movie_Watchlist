using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController(MongoDbService mongoDbService) : ControllerBase
{
    [HttpGet]
    public async Task<List<Movie>> Get()
    {
        return await mongoDbService.GetAllMoviesAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Movie movie)
    {
        await mongoDbService.InsertMovieAsync(movie);
        return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
    }
}
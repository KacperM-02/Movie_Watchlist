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
        return await mongoDbService.GetAllAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Movie movie)
    {
        await mongoDbService.InsertAsync(movie);
        return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] string title)
    {
        await mongoDbService.AddToMoviesAsync(id, title);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await mongoDbService.DeleteAsync(id);
        return NoContent();
    }
}
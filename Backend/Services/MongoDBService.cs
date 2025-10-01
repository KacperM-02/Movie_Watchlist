using Backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.Services;

public class MongoDbService
{
    private readonly IMongoCollection<Movie> _moviesCol;
    private readonly IMongoCollection<User> _usersCol;

    public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.Value.ConnectionUri);
        var database = client.GetDatabase(mongoDbSettings.Value.DataBaseName);
        _moviesCol = database.GetCollection<Movie>(mongoDbSettings.Value.MoviesColName);
        _usersCol = database.GetCollection<User>(mongoDbSettings.Value.UsersColName);
    }
    
    // Movies collection
    public async Task InsertMovieAsync(Movie movie)
    {
        await _moviesCol.InsertOneAsync(movie);
    }

    public async Task<List<Movie>> GetAllMoviesAsync()
    {
        return await _moviesCol.Find(new BsonDocument()).ToListAsync();
    }

    
    // Users collection
    public async Task InsertUserAsync(User user)
    {
        await _usersCol.InsertOneAsync(user);
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _usersCol.Find(new BsonDocument()).ToListAsync();
    }
}
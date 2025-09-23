using Backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.Services;

public class MongoDbService
{
    private readonly IMongoCollection<Movie> _moviesCollection;

    public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.Value.ConnectionUri);
        var database = client.GetDatabase(mongoDbSettings.Value.DataBaseName);
        _moviesCollection = database.GetCollection<Movie>(mongoDbSettings.Value.CollectionName);
    }

    public async Task InsertAsync(Movie movie)
    {
        await _moviesCollection.InsertOneAsync(movie);
    }

    public async Task<List<Movie>> GetAllAsync()
    {
        return await _moviesCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddToMoviesAsync(string id, string movieId)
    {
        var filter = Builders<Movie>.Filter.Eq("Id", id);
        var update = Builders<Movie>.Update.AddToSet("movieId", movieId);
        await _moviesCollection.UpdateOneAsync(filter, update);
    }

    public async Task DeleteAsync(string id)
    {
        var filter = Builders<Movie>.Filter.Eq("Id", id);
        await _moviesCollection.DeleteOneAsync(filter);
    }
}
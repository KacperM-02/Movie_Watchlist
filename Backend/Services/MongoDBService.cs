using Backend.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Backend.Services;

public class MongoDBService
{
    private readonly IMongoCollection<Movie> _moviesCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        var client = new MongoClient(mongoDBSettings.Value.ConnectionUri);
        var database = client.GetDatabase(mongoDBSettings.Value.DataBaseName);
        var _movieCollection = database.GetCollection<Movie>(mongoDBSettings.Value.CollectionName);
    }
}
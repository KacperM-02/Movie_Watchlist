namespace Backend.Models;

public class MongoDbSettings
{
    public string ConnectionUri { get; set; } = null!;
    public string DataBaseName { get; set; } = null!;
    public string MovieCollectionName { get; set; } = null!;
}
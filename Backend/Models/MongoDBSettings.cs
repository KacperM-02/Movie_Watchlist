namespace Backend.Models;

public class MongoDBSettings
{
    public string ConnectionUri { get; set; } = null!;
    public string DataBaseName { get; set; } = null!;
    public string CollectionName { get; set; } = null!;
}
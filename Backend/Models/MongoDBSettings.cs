namespace Backend.Models;

public class MongoDbSettings
{
    public string ConnectionUri { get; set; } = null!;
    public string DataBaseName { get; set; } = null!;
    public string MoviesColName { get; set; } = null!;
    public string UserMoviesColName { get; set; } = null!;
    public string UsersColName { get; set; } = null!;
}
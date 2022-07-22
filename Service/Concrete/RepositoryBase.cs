using DotnetConsoleAddMongo.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DotnetConsoleAddMongo.Service.Concrete;

public class RepositoryBase<T>
{
    private readonly IMongoDatabase _database;
    protected readonly IMongoCollection<T> Collection;
    public RepositoryBase(IConnection connection)
    {
        _database = new MongoClient(connection.ConnectionString).GetDatabase(connection.DatabaseName);
        Collection = _database.GetCollection<T>(typeof(T).Name);
    }
}
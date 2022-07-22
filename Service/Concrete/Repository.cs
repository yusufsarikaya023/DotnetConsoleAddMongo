using DotnetConsoleAddMongo.Model;
using DotnetConsoleAddMongo.Service.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DotnetConsoleAddMongo.Service.Concrete;

public class Repository<T> : RepositoryBase<T>, IRepository<T>
{

    public Repository(IConnection connection) : base(connection)
    {
    }

    public virtual T Add(T entity)
    {
        Collection.InsertOne(entity);
        return entity;
    }

    public T[] AddRange(T[] entities)
    {
        Collection.InsertMany(entities);
        Console.WriteLine("Inserted Range");
        return entities;
    }

    public void RemoveAll()
    {
        Collection.DeleteMany(new BsonDocument());
    }

}
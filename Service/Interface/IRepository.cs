namespace DotnetConsoleAddMongo.Service.Interface;

public interface IRepository<T>
{
    T Add(T entity);
    void RemoveAll();
}
namespace DotnetConsoleAddMongo.Model;

public interface IConnection
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}
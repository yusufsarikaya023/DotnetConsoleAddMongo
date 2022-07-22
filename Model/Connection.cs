namespace DotnetConsoleAddMongo.Model;

public class Connection : IConnection
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}
using DotnetConsoleAddMongo.Model;
using DotnetConsoleAddMongo.Service.Interface;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DotnetConsoleAddMongo.Service.Concrete;

public class CountryService : Repository<City>, ICountryService
{
    public CountryService(IConnection connection) : base(connection)
    {
    }

}
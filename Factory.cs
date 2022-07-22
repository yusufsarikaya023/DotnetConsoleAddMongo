using DotnetConsoleAddMongo.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

public class Factory
{
    private readonly IServiceProvider serviceProvider;
    private readonly ICountryService countryService;
    public Factory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.countryService = serviceProvider.GetRequiredService<ICountryService>();
    }

    public string CreateCountry()
    {
        using (var reader = new StreamReader(@"./lib/country.json"))
        {
            ICountryService countryService = serviceProvider.GetRequiredService<ICountryService>();
            while (!reader.EndOfStream)
            {
                var countriesJson = reader.ReadToEnd();
                List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(countriesJson)!;
                countries.ForEach(x => countryService.Add(x));
            }
        }
        return "Country added";
    }
    public string RemoveAllCountry()
    {
        countryService.RemoveAll();
        return "All country removed";
    }
}
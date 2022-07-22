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

    public void CreateCountry()
    {
        using (var reader = new StreamReader(@"./lib/country.json"))
        {
            ICountryService countryService = serviceProvider.GetRequiredService<ICountryService>();
            while (!reader.EndOfStream)
            {
                var countriesJson = reader.ReadToEnd();
                List<City> countries = JsonConvert.DeserializeObject<List<City>>(countriesJson)!;
                countryService.AddRange(countries.ToArray());
            }
        }
    }
    public void RemoveAllCountry()
    {
        countryService.RemoveAll();
    }

    public void CreateCountries()
    {
        using (var reader = new StreamReader(@"./lib/country.json"))
        {
            ICountryService countryService = serviceProvider.GetRequiredService<ICountryService>();
            while (!reader.EndOfStream)
            {
                var countriesJson = reader.ReadToEnd();
                List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(countriesJson)!;
                countryService.AddRange(countries.ToArray());
            }
        }
    }
}
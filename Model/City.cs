using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

public class City
{
    [BsonElement("id")]
    [BsonId]
    public Guid Id { get; set; }

    [BsonElement("countryId")]
    [JsonProperty("country_id")]
    public string CountryId { get; set; } = string.Empty;

    [BsonElement("cityName")]
    [JsonProperty("city_name")]
    public string? CityName { get; set; }
}

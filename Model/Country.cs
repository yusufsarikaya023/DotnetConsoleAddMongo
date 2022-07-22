using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

public class Country
{
    [BsonElement("id")]
    public Guid Id { get; set; }

    [BsonElement("countryName")]
    public string CountryName { get; set; } = string.Empty;

    [BsonElement("iso2")]
    public string? Iso2 { get; set; }

    [BsonElement("iso3")]
    public string? Iso3 { get; set; }

    [BsonElement("phoneCode")]
    [JsonProperty("phone_code")]
    public string? PhoneCode { get; set; }

    [BsonElement("addressFormat")]
    [JsonProperty("address_format")]
    public string? AddressFormat { get; set; }

    [BsonElement("capital")]
    public string? Capital { get; set; }

    [BsonElement("currency")]
    public string? Currency { get; set; }
}

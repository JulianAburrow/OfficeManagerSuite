namespace OfficeManagerUI.Services;

public class LocationIQGeocodingService(HttpClient http, IConfiguration configuration) : IGeocodingService
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;

    public async Task<(decimal lat, decimal lng)> GeocodeAsync(string address)
    {
        var apiKey = _configuration["Geocoding:LocationIQ:ApiKey"];
        var url = $"https://eu1.locationiq.com/v1/search?key={apiKey}&q={Uri.EscapeDataString(address)}&countrycodes=gb&format=json";

        var results = await _http.GetFromJsonAsync<List<LocationIqResult>>(url);

        if (results is null || results.Count == 0)
            throw new Exception($"Unable to geocode address: {address}");

        var loc = results[0];
        return (loc.Lat, loc.Lon);
    }
}

public class LocationIqResult
{
    public decimal Lat { get; set; }
    public decimal Lon { get; set; }
}
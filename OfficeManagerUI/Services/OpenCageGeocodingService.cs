namespace OfficeManagerUI.Services;

public class OpenCageGeocodingService(HttpClient http, IConfiguration configuration) : IGeocodingService
{
    private readonly HttpClient _http = http;
    private readonly IConfiguration _configuration = configuration;

    public async Task<(decimal lat, decimal lng)> GeocodeAsync(string address)
    {
        var apiKey = _configuration["Geocoding:OpenCage:ApiKey"];
        var encoded = Uri.EscapeDataString(address);
        var url = $"https://api.opencagedata.com/geocode/v1/json?key={apiKey}&q={encoded}&limit=1&no_annotations=1";

        var response = await _http.GetFromJsonAsync<OpenCageResponse>(url);

        var first = response?.Results?.FirstOrDefault();
        if (first is null)
            throw new Exception($"Unable to geocode address: {address}");

        return (first.Geometry.Lat, first.Geometry.Lng);
    }
}

public class OpenCageResponse
{
    public List<OpenCageResult> Results { get; set; }
}

public class OpenCageResult
{
    public OpenCageGeometry Geometry { get; set; }
}

public class OpenCageGeometry
{
    public decimal Lat { get; set; }
    public decimal Lng { get; set; }
}

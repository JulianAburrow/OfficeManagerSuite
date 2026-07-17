namespace OfficeManagerUI.Services;

public class OSPlacesGeocodingService : IGeocodingService
{
    public Task<(decimal lat, decimal lng)> GeocodeAsync(string address)
    {
        throw new NotImplementedException();
    }
}

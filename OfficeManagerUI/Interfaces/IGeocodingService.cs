namespace OfficeManagerUI.Interfaces;

public interface IGeocodingService
{
    Task<(decimal lat, decimal lng)> GeocodeAsync(string address);
}

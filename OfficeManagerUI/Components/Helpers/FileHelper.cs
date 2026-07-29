namespace OfficeManagerUI.Components.Helpers;

public static class FileHelper
{
    public static string ToDataUri(byte[] content, string mimeType)
    {
        return $"data:{mimeType};base64,{Convert.ToBase64String(content)}";
    }

    public static async Task<MemoryStream> ToMemoryStream(Stream stream)
    {
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);
        return memoryStream;
    }
}

using Microsoft.EntityFrameworkCore.Storage.Json;

namespace OfficeManagerUI.Components.Shared.BasePageClasses;

public class BasePageClass : ComponentBase
{
    [Inject] protected ISnackbar Snackbar { get; set; } = null!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;

    [CascadingParameter] public MainLayout MainLayout { get; set; } = null!;

    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue(string.Empty);
    }

    protected BreadcrumbItem GetHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new("Home", "#", isDisabled, icon: Icons.Material.Filled.Home);
    }

    protected BreadcrumbItem GetCustomBreadcrumbItem(string text)
    {
        return new(text, null, true);
    }

    protected string CreateTextForBreadcrumb = "Create";

    protected string DeleteTextForBreadcrumb = "Delete";

    protected string EditTextForBreadcrumb = "Edit";

    protected string ViewTextForBreadcrumb = "View";

    protected string PleaseSelectText = "Please Select";

    protected int PleaseSelectValue = -1;

    protected string NotStatedText = "Not Stated";

    protected int NotStatedValue = 0;

    protected bool OkToEditOrDelete { get; set; }

    protected string? ImageName = null;

    protected string? ImageMimeType = null;

    protected string? PronunciationName = null;

    protected string? PronunciationMimeType = null;

    protected byte[]? ImageForDisplay = null;

    protected byte[]? PronunciationForDisplay = null;

    protected long MaxFileSize = 1024 * 1024 * 3;

    protected async Task GlobalUploadImage(IBrowserFile? file)
    {
        if (file is null)
        {
            return;
        }

        if (!file.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase))
        {
            Snackbar.Add("Only image files are allowed.", Severity.Warning);
            return;
        }

        try
        {
            ImageName = file.Name;
            ImageMimeType = file.ContentType;
            var imageMemoryStream = await FileHelper.ToMemoryStream(file.OpenReadStream(MaxFileSize));
            ImageForDisplay = imageMemoryStream.ToArray();
            Snackbar.Add($"{ImageName} successfully uploaded.", Severity.Success);
        }
        catch
        {
            Snackbar.Add($"An error occurred uploading {ImageName}. Please try again.", Severity.Error);
        }
    }

    protected async Task GlobalUploadPronunciation(IBrowserFile? file)
    {
        if (file is null)
        {
            return;
        }

        if (!file.ContentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase))
        {
            Snackbar.Add("Only audio files are allowed.", Severity.Warning);
            return;
        }

        try
        {
            PronunciationName = file.Name;
            PronunciationMimeType = file.ContentType;
            var pronunciationMemoryStream = await FileHelper.ToMemoryStream(file.OpenReadStream(MaxFileSize));
            PronunciationForDisplay = pronunciationMemoryStream.ToArray();
            Snackbar.Add($"{PronunciationForDisplay} successfully uploaded.", Severity.Success);
        }
        catch
        {
            Snackbar.Add($"An error occurred uploading {PronunciationForDisplay}. Please try again.", Severity.Error);
        }   
    }

    protected void GlobalRemoveImage()
    {
        Snackbar.Add($"{ImageName} successfully removed.", Severity.Success);
        ImageForDisplay = null;
        ImageName = null;
        StateHasChanged();
    }

    protected void GlobalRemovePronunciation()
    {
        Snackbar.Add($"{PronunciationName} successfully removed.", Severity.Success);
        PronunciationForDisplay = null;
        PronunciationName = null;
        StateHasChanged();
    }
}

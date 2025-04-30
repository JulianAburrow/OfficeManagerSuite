namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Genders;

public partial class Index
{
    private List<GenderModel> Genders = null!;

    protected override async Task OnInitializedAsync()
    {
        Genders = await GenderHandler.GetGendersAsync();
        Snackbar.Add($"{Genders.Count} item(s) found", Genders.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue(GenderPlural);
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetGenderHomeBreadcrumbItem(true),
        ]);
    }
}

namespace OfficeManagerUI.Components.Pages.PersonManager.People;

public partial class Index
{
    private List<PersonModel> People = null!;

    protected override async Task OnInitializedAsync()
    {
        People = await PersonHandler.GetAllPeopleAsync();
        Snackbar.Add($"{People.Count} item(s) found.", People.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue(PersonPlural);
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetPersonHomeBreadcrumbItem(true),
        ]);
    }
}

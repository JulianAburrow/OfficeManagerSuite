namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.PersonalPronouns;

public partial class Index
{
    private List<PersonalPronounsModel> PersonalPronouns = null!;

    protected override async Task OnInitializedAsync()
    {
        PersonalPronouns = await PersonalPronounsHandler.GetPersonalPronounsAsync();
        Snackbar.Add($"{PersonalPronouns.Count} item(s) found.", PersonalPronouns.Count > 0 ? Severity.Info : Severity.Warning);
        MainLayout.SetHeaderValue(PersonalPronounsPlural);
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetPersonalPronounsHomeBreadcrumbItem(true),
        ]);
    }
}

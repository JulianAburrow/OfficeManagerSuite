namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.PersonalPronouns;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        PersonalPronounsModel = await PersonalPronounsHandler.GetPersonalPronounAsync(PersonalPronounsId);
        MainLayout.SetHeaderValue("View Personal Pronouns");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetPersonalPronounsHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        ]);
    }
}

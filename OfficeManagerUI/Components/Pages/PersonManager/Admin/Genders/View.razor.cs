namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Genders;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        GenderModel = await GenderHandler.GetGenderAsync(GenderId);
        MainLayout.SetHeaderValue("View Gender");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetGenderHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        ]);
    }
}

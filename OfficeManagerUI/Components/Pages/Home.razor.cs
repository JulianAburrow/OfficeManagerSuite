namespace OfficeManagerUI.Components.Pages;

public partial class Home
{
    protected override async Task OnInitializedAsync()
    {
        MainLayout.SetHeaderValue("Home");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(true),
        ]);
    }
}

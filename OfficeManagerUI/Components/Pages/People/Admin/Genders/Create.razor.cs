namespace OfficeManagerUI.Components.Pages.People.Admin.Genders;

public partial class Create
{
    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue("Create Gender");
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetGenderHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async void CreateGender()
    {
        try
        {
            CopyDisplayModelToModel();
            await GenderHandler.CreateGenderAsync(GenderModel);
            Snackbar.Add($"Gender {GenderModel.GenderName} successfully created", Severity.Success);
            NavigationManager.NavigateTo("/genders/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {GenderModel.GenderName}. Please try again.", Severity.Error);
        }
    }
}

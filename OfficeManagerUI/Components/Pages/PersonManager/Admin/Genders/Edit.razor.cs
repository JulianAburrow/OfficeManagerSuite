namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Genders;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        GenderModel = await GenderHandler.GetGenderByIdAsync(GenderId);
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Gender");
    }

    protected void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetGenderHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private async Task UpdateGender()
    {
        try
        {
            CopyDisplayModelToModel();
            await GenderHandler.UpdateGenderAsync(GenderModel);
            Snackbar.Add($"Gender {GenderModel.GenderName} successfully updated", Severity.Success);
            NavigationManager.NavigateTo("/genders/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {GenderModel.GenderName}. Please try again.", Severity.Error);
        }
    }
}

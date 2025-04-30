namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.Genders;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        GenderModel = await GenderHandler.GetGenderAsync(GenderId);
        MainLayout.SetHeaderValue("Delete Gender");
        OkToDelete = GenderModel.Persons != null && GenderModel.Persons.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetGenderHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        ]);
    }

    private async Task DeleteGender()
	{	        
	    try
        {
            await GenderHandler.DeleteGenderAsync(GenderId);
            Snackbar.Add($"Gender {GenderModel.GenderName} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo("/genders/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {GenderModel.GenderName}. Please try again.", Severity.Error);
        }
	}
}
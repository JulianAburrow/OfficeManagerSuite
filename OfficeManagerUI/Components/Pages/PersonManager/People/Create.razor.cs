namespace OfficeManagerUI.Components.Pages.PersonManager.People;

public partial class Create
{
    protected override void OnInitialized()
    {
        PersonDisplayModel.GenderId = PleaseSelectValue;
        PersonDisplayModel.PersonalPronounsId = PleaseSelectValue;
        PersonDisplayModel.EmploymentStatusId = PleaseSelectValue;
        MainLayout.SetHeaderValue("Create Person");
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetPersonHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async Task CreatePerson()
    {
        try
        {
            CopyDisplayModelToModel();
            await PersonHandler.CreatePersonAsync(PersonModel);
            Snackbar.Add($"Person {PersonModel.FirstName} {PersonModel.LastName} successfully created", Severity.Success);
            NavigationManager.NavigateTo("/people/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {PersonModel.FirstName} {PersonModel.LastName}. Please try again.", Severity.Error);
        }
    }
}

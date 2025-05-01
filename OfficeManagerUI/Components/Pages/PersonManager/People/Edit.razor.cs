namespace OfficeManagerUI.Components.Pages.PersonManager.People;

public partial class Edit
{

    protected override async Task OnInitializedAsync()
    {
        PersonModel = await PersonHandler.GetPersonByIdAsync(PersonId);
        CopyModelToDisplayModel();
        EmploymentStatuses = await EmploymentStatusHandler.GetAllEmploymentStatusesAsync();
        PersonalPronouns = await PersonalPronounsHandler.GetAllPersonalPronounsAsync();
        AddPersonalPronounsNotStated();
        if (PersonModel.PersonalPronounsId == null)
        {            
            PersonModel.PersonalPronounsId = NotStatedValue;
        }
        Genders = await GenderHandler.GetAllGendersAsync();
        AddGenderNotStated();
        if (PersonModel.GenderId == null)
        {            
            PersonModel.GenderId = NotStatedValue;
        }
        MainLayout.SetHeaderValue("Edit Person");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetPersonHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private async Task UpdatePerson()
    {
        try
        {
            CopyDisplayModelToModel();
            await PersonHandler.UpdatePersonAsync(PersonModel);
            Snackbar.Add($"Person {PersonModel.FirstName} {PersonModel.LastName} successfully updated", Severity.Success);
            NavigationManager.NavigateTo("/people/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {PersonModel.FirstName} {PersonModel.LastName}. Please try again.", Severity.Error);
        }
    }
}

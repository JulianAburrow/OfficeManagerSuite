namespace OfficeManagerUI.Components.Pages.PersonManager.People;

public partial class Edit
{

    protected override async Task OnInitializedAsync()
    {
        PersonModel = await PersonHandler.GetPersonAsync(PersonId);
        CopyModelToDisplayModel();
        EmploymentStatuses = await EmploymentStatusHandler.GetEmploymentStatusesAsync();
        PersonalPronouns = await PersonalPronounsHandler.GetPersonalPronounsAsync();
        AddPersonalPronounsNotStated();
        if (PersonModel.PersonalPronounsId == null)
        {            
            PersonModel.PersonalPronounsId = NotStatedValue;
        }
        Genders = await GenderHandler.GetGendersAsync();
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

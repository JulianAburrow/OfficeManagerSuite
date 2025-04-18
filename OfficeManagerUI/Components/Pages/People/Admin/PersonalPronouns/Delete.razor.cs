namespace OfficeManagerUI.Components.Pages.People.Admin.PersonalPronouns;

public partial class Delete
{
    protected override async Task OnInitializedAsync()
    {
        PersonalPronounsModel = await PersonalPronounsHandler.GetPersonalPronounAsync(PersonalPronounsId);
        MainLayout.SetHeaderValue("Delete Personal Pronouns");
        OkToDelete = PersonalPronounsModel.Persons != null && PersonalPronounsModel.Persons.Count == 0;
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetPersonalPronounsHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(DeleteTextForBreadcrumb),
        ]);
    }

    private async Task DeletePersonalPronouns()
    {
        try
        {
            await PersonalPronounsHandler.DeletePersonalPronounsAsync(PersonalPronounsId);
            Snackbar.Add($"Personal Pronouns {PersonalPronounsModel.PronounNames} successfully deleted", Severity.Success);
            NavigationManager.NavigateTo("/personalpronouns/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred deleting {PersonalPronounsModel.PronounNames}. Please try again.", Severity.Error);
        }
    }
}
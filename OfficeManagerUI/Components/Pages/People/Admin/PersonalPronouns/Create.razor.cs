namespace OfficeManagerUI.Components.Pages.People.Admin.PersonalPronouns;

public partial class Create
{
    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue("Create Personal Pronoun");
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetPersonalPronounsHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(CreateTextForBreadcrumb),
        ]);
    }

    private async void CreatePersonalPronouns()
    {
        try
        {
            CopyDisplayModelToModel();
            await PersonalPronounsHandler.CreatePersonalPronounsAsync(PersonalPronounsModel);
            Snackbar.Add($"Personal Pronoun {PersonalPronounsModel.PronounNames} successfully created", Severity.Success);
            NavigationManager.NavigateTo("/personalpronouns/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred creating {PersonalPronounsModel.PronounNames}. Please try again.", Severity.Error);
        }
    }
}

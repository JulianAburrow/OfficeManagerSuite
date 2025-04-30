namespace OfficeManagerUI.Components.Pages.PersonManager.Admin.PersonalPronouns;

public partial class Edit
{
    protected override async Task OnInitializedAsync()
    {
        PersonalPronounsModel = await PersonalPronounsHandler.GetPersonalPronounAsync(PersonalPronounsId);
        CopyModelToDisplayModel();
        MainLayout.SetHeaderValue("Edit Personal Pronouns");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetPersonalPronounsHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(EditTextForBreadcrumb),
        ]);
    }

    private async Task UpdatePersonalPronouns()
    {
        try
        {
            CopyDisplayModelToModel();
            await PersonalPronounsHandler.UpdatePersonalPronounsAsync(PersonalPronounsModel);
            Snackbar.Add($"Personal Pronouns {PersonalPronounsModel.PronounNames} successfully updated", Severity.Success);
            NavigationManager.NavigateTo("/personalpronouns/index");
        }
        catch
        {
            Snackbar.Add($"An error occurred updating {PersonalPronounsModel.PronounNames}. Please try again.", Severity.Error);
        }
    }
}

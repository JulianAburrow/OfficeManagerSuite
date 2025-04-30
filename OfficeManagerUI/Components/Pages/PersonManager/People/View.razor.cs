namespace OfficeManagerUI.Components.Pages.PersonManager.People;

public partial class View
{
    protected override async Task OnInitializedAsync()
    {
        PersonModel = await PersonHandler.GetPersonAsync(PersonId);
        if (PersonModel.Gender is null)
            PersonModel.Gender = new GenderModel {  GenderName = NotStatedText };
        if (PersonModel.PersonalPronouns is null)
            PersonModel.PersonalPronouns = new PersonalPronounsModel { PronounNames = NotStatedText };
        MainLayout.SetHeaderValue("View Person");
    }

    protected override void OnInitialized()
    {
        MainLayout.SetBreadcrumbs(
        [
            GetHomeBreadcrumbItem(),
            GetPersonHomeBreadcrumbItem(),
            GetCustomBreadcrumbItem(ViewTextForBreadcrumb),
        ]);
    }
}

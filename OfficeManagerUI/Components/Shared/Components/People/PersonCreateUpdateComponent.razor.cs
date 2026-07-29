namespace OfficeManagerUI.Components.Shared.Components.People;

public partial class PersonCreateUpdateComponent
{
    [Parameter] public new PersonDisplayModel PersonDisplayModel { get; set; } = null!;

    [Parameter] public new List<EmploymentStatusModel> EmploymentStatuses { get; set; } = null!;

    [Parameter] public new List<PersonalPronounsModel> PersonalPronouns { get; set; } = null!;

    [Parameter] public new List<GenderModel> Genders { get; set; } = null!;
    
    protected async Task LocalUploadImage(IBrowserFile file)
    {
        await GlobalUploadImage(file);
        PersonDisplayModel.Photo = ImageForDisplay;
        PersonDisplayModel.PhotoMimeType = ImageMimeType;
    }

    protected void LocalRemoveImage()
    {
        GlobalRemoveImage();
        PersonDisplayModel.Photo = ImageForDisplay;
    }

    protected async Task LocalUploadPronunciation(IBrowserFile file)
    {
        await GlobalUploadPronunciation(file);
        PersonDisplayModel.Pronunciation = PronunciationForDisplay;
        PersonDisplayModel.PronunciationMimeType = PronunciationMimeType;
    }

    protected void LocalRemovePronunciation()
    {
        GlobalRemovePronunciation();
        PersonDisplayModel.Pronunciation = PronunciationForDisplay;
    }
}

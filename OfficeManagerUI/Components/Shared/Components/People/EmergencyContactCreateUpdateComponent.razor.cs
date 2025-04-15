namespace OfficeManagerUI.Components.Shared.Components.People;

public partial class EmergencyContactCreateUpdateComponent
{
    [Parameter] public EmergencyContactDisplayModel EmergencyContactDisplayModel { get; set; } = null!;

    [Parameter] public List<PersonModel> People { get; set; } = null!;
}

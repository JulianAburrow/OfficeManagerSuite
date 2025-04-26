namespace OfficeManagerUI.Components.Shared.Components.People;

public partial class EmergencyContactGridviewComponent
{
    [Parameter] public List<EmergencyContactModel> EmergencyContacts { get; set; } = null!;

    [Parameter] public bool ShowStaffMember { get; set; }
}

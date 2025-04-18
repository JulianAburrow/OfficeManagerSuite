namespace OfficeManagerUI.Components.Shared.Components.People;

public partial class PersonGridviewComponent
{
    [Parameter] public List<PersonModel> People { get; set; } = null!;
}

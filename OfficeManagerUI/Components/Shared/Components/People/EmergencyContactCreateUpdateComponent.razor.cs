namespace OfficeManagerUI.Components.Shared.Components.People;

public partial class EmergencyContactCreateUpdateComponent
{
    [Parameter] public EmergencyContactDisplayModel EmergencyContactDisplayModel { get; set; } = null!;

    [Parameter] public List<PersonModel> People { get; set; } = null!;

    [Parameter] public bool DisablePeopleDropDownList { get; set; } = false;

    [Parameter] public List<string> Relationships { get;set;} = [];

    private async Task<IEnumerable<string>> GetRelationships(string value, CancellationToken token)
    {
        if (value is null)
        {
            return Relationships;
        }

        return await Task.FromResult(Relationships.Where(r => r.StartsWith(value, StringComparison.OrdinalIgnoreCase)).ToList());
    }

    private void PopulateRelationship(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return;
        };

        EmergencyContactDisplayModel.Relationship = value.Trim();
    }
}

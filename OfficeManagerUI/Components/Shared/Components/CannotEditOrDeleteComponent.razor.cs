namespace OfficeManagerUI.Components.Shared.Components;

public partial class CannotEditOrDeleteComponent
{
    [Parameter]
    public string ObjectType { get; set; } = default!;

    [Parameter]
    public string ObjectName { get; set; } = default!;

    [Parameter] public string WhichManager { get; set; } = default!;

    [Parameter]
    public int ObjectCount { get; set; }

    private string CancelURL => CreateCancelUrl();

    private string CreateCancelUrl()
    {
        var objectTypeCorrected = ObjectType.Replace(" ", "").ToLower();
        return $"{WhichManager}manager/{objectTypeCorrected}/index";
    }
}

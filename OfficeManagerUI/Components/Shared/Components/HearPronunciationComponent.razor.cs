namespace OfficeManagerUI.Components.Shared.Components;

public partial class HearPronunciationComponent
{
    [Parameter] public byte[]? PronunciationData { get; set; }

    [Parameter] public string PronunciationTitle { get; set; } = string.Empty;

    [Parameter] public string PronunciationMimeType { get; set; } = string.Empty;
}

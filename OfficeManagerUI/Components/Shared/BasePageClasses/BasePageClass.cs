namespace OfficeManagerUI.Components.Shared.BasePageClasses;

public class BasePageClass : ComponentBase
{
    [Inject] protected ISnackbar Snackbar { get; set; } = null!;

    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;

    [CascadingParameter] public MainLayout MainLayout { get; set; } = null!;

    protected override void OnInitialized()
    {
        MainLayout.SetHeaderValue(string.Empty);
    }

    protected BreadcrumbItem GetHomeBreadcrumbItem(bool isDisabled = false)
    {
        return new("Home", "#", isDisabled, icon: Icons.Material.Filled.Home);
    }

    protected BreadcrumbItem GetCustomBreadcrumbItem(string text)
    {
        return new(text, null, true);
    }

    protected string CreateTextForBreadcrumb = "Create";

    protected string DeleteTextForBreadcrumb = "Delete";

    protected string EditTextForBreadcrumb = "Edit";

    protected string ViewTextForBreadcrumb = "View";

    protected string PleaseSelectText = "Please Select";

    protected int PleaseSelectValue = -1;

    protected string NotStatedText = "Not Stated";

    protected int NotStatedValue = 0;

    protected bool OkToDelete { get; set; }
}

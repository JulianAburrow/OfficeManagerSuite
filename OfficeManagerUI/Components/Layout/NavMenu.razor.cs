namespace OfficeManagerUI.Components.Layout;

public partial class NavMenu(NavigationManager NavigationManager)
{
    private NavigationManager navigationManager = NavigationManager;

    private void GoToEmergencyContacts()
    {
        navigationManager.NavigateTo("/personmanager/emergencycontacts/index/0", true);
    }
}

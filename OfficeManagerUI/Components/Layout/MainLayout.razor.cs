﻿namespace OfficeManagerUI.Components.Layout;

public partial class MainLayout
{
    bool _drawerOpen = true;

    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    private List<BreadcrumbItem> BreadCrumbs = [];

    private string HeaderText { get; set; } = null!;

    public void SetHeaderValue(string headerText)
    {
        HeaderText = headerText;
        StateHasChanged();
    }

    public void SetBreadCrumbs(List<BreadcrumbItem> breadcrumbs)
    {
        BreadCrumbs.Clear();
        BreadCrumbs.AddRange(breadcrumbs);
    }
}

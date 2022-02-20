using MauiMobileAppTest.Data;

namespace MauiMobileAppTest;

public partial class MainPage : ContentPage
{
    private AppDatabaseContext _appDatabaseContext { get; set; }

    public MainPage(AppDatabaseContext appDatabaseContext)
    {
        InitializeComponent();
        _appDatabaseContext = appDatabaseContext;
    }
}

using MauiMobileAppTest.Data;
using MauiMobileAppTest.Views;

namespace MauiMobileAppTest;

public partial class App : Application
{
    public App(AppDatabaseContext appDatabaseContext)
    {
        InitializeComponent();
        //MainPage = new MainPage(appDatabaseContext);
        MainPage = new NavigationPage(new TodoListPage(appDatabaseContext));
    }
}

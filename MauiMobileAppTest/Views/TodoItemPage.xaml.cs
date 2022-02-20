using MauiMobileAppTest.Data;
using MauiMobileAppTest.Models;

namespace MauiMobileAppTest.Views
{
    public partial class TodoItemPage : ContentPage
    {
        private AppDatabaseContext _appDatabaseContext { get; set; }

        public TodoItemPage(AppDatabaseContext appDatabaseContext)
        {
            InitializeComponent();
            _appDatabaseContext = appDatabaseContext;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            _appDatabaseContext.TodoItems.Add(todoItem);
            await _appDatabaseContext.SaveChangesAsync();
            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            _appDatabaseContext.TodoItems.Remove(todoItem);
            await _appDatabaseContext.SaveChangesAsync();
            await Navigation.PopAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

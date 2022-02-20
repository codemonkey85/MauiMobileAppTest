using MauiMobileAppTest.Data;
using MauiMobileAppTest.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiMobileAppTest.Views
{
    public partial class TodoListPage : ContentPage
    {
        private AppDatabaseContext _appDatabaseContext { get; set; }

        public TodoListPage(AppDatabaseContext appDatabaseContext)
        {
            InitializeComponent();
            _appDatabaseContext = appDatabaseContext;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await _appDatabaseContext.TodoItems.ToListAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage(_appDatabaseContext)
            {
                BindingContext = new TodoItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage(_appDatabaseContext)
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }
    }
}

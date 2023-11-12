using MyCoffeeApp.Shared.Models;
using MyCoffeeApp.ViewModels;

namespace MyCoffeeApp.Views;
public partial class CoffeeEquipmentCVPage : ContentPage
{
    public CoffeeEquipmentCVPage(CoffeeEquipmentViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void SwipeItem_Invoked(object sender, EventArgs e)
    {
        var item = sender as SwipeItem;
        if (item is null)
            return;

        var coffee = item.BindingContext as Coffee;
        if (coffee is null)
            return;

        await Shell.Current.DisplayAlert("Coffee Favorited",
            coffee.Name, "OK");
    }

    private async void MenuFlyoutItem_Clicked(object sender, EventArgs e)
    {
        var item = sender as MenuFlyoutItem;
        if (item is null)
            return;

        var coffee = item.BindingContext as Coffee;
        if (coffee is null)
            return;

        await Shell.Current.DisplayAlert("Coffee Favorited",
            coffee.Name, "OK");
    }

    private async void MenuFlyoutItem_Clicked_1Async(object sender, EventArgs e)
    {
        await Shell.Current.DisplayAlert("Menu item clicked!", "You did it!", "OK");
    }
}
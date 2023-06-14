using MyCoffeeApp.Services;

namespace MyCoffeeApp.ViewModels;

[QueryProperty(nameof(Name), nameof(Name))]
public partial class AddMyCoffeeViewModel : ViewModelBase
{

    [ObservableProperty]
    string name;

    [ObservableProperty]
    string roaster;

    ICoffeeService coffeeService;
    public AddMyCoffeeViewModel(ICoffeeService coffeeService)
    {
        Title = "Add Coffee";
        this.coffeeService = coffeeService;
    }

    [RelayCommand]
    async Task Save()
    {
        if(string.IsNullOrWhiteSpace(Name) ||
            string.IsNullOrWhiteSpace(Roaster))
        {
            return;
        }

        await coffeeService.AddCoffee(Name, Roaster);

        await Shell.Current.GoToAsync("..");
    }
}

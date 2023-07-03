using CommunityToolkit.Mvvm.Input;
using SQLite;
using System;

namespace MyCoffeeApp.Shared.Models;

public partial class Coffee
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Roaster { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }

    [RelayCommand]
    void Test()
    {
        Console.Write("Test");
    }
}

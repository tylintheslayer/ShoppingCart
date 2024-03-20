using ShoppingCart.Databaseservices;
using SQLite;
using ShoppingCart.DataBaseItems;
using System.Collections.ObjectModel;
using System.Transactions;

namespace ShoppingCart.Models;

public partial class ProfilePage : ContentPage
{
    private ShoppingDatabase _database;

    private Client _currentClient;

    public Client CurrentClient
    {
        get { return _currentClient; }
        set
        {
            _currentClient = value;

            OnPropertyChanged();
        }
    }
    public ProfilePage()
    {
       InitializeComponent();
       _database = new ShoppingDatabase();

       BindingContext = this;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadData();
    }
    private void SaveBtn_Clicked(object sender, EventArgs e) 
    {
        _database.UpdateClient(CurrentClient);
    }

   private void LoadBtn_Clicked(Object sender, EventArgs e) 
    {
        LoadData();
    }

    private void LoadData()
    {
        Client client = _database.GetClientById(1);

        CurrentClient = client;
    }
}
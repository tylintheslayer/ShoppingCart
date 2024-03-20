using Microsoft.Maui.Controls;
using ShoppingCart.Models;

namespace ShoppingCart.Models
{
    public partial class CartPage : ContentPage
    {
        public CartPage()
        {
            InitializeComponent();
            BindingContext = new ShoeCatalogue();
        }
    }
}

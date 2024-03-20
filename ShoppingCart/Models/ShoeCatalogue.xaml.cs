using Microsoft.Maui.Controls;
using ShoppingCart.DataBaseItems; // Import the correct namespace where your ShoeViewModel is located

namespace ShoppingCart.Models 
{
    public partial class ShoeCatalogue : ContentPage
    {
        public ShoeCatalogue()
        {
            InitializeComponent();
            BindingContext = new Shoes();
        }
    }
}

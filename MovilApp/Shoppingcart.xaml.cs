
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovilApp.Models;

namespace MovilApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shoppingcart : ContentPage
    {

        public Shoppingcart()
        {
            InitializeComponent();

            carrito.ItemsSource = Products.carrito;


            Btnsalir.Clicked += Btnsalir_Clicked;

            BindingContext = this;
        }



        private void Btnsalir_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new DeBanco());
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


            Products selectedItem = e.SelectedItem as Products;


            var action = await DisplayAlert("Carrito de Compras", "¿Quiere Eliminar el Producto del Carrito?", "Si", "No");
            if (action)
            {

                Products carrito = new Products();
                carrito.removerItem(Products.carrito.IndexOf(selectedItem));
            }

        }


        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Products tappedItem = e.Item as Products;
        }


    }
}



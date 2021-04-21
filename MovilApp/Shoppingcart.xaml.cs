
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

            btnSiguiente.Clicked += BtnSiguiente_Clicked;

            BindingContext = this;
        }

        private void BtnSiguiente_Clicked(object sender, EventArgs e)
        {
            if ((carrito.ItemsSource as List<Products>).Count == 0)
            {
                DisplayAlert("Carrito","No hay ningun producto en el carrito","Volver");
            }
            else
            {
            ((NavigationPage)this.Parent).PushAsync(new Cuota());

            }

        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


            Products selectedItem = e.SelectedItem as Products;


            var action = await DisplayAlert("Carrito de Compras", "¿Quiere Eliminar el Producto del Carrito?", "Si", "No");
            if (action)
            {

                Products carrito = new Products();
                carrito.removerItem(Products.carrito.IndexOf(selectedItem));
                refresh();

            }

        }


        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Products tappedItem = e.Item as Products;
        }

        private void refresh()
        {
            var vUpdatedPage = new Shoppingcart(); Navigation.InsertPageBefore(vUpdatedPage, this); Navigation.PopAsync();
        }


    }
}



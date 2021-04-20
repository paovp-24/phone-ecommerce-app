using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovilApp.Models;

namespace MovilApp
{
  
    public partial class Individual : ContentPage
    {
        public Individual( string Name, string price, string img)
        {
            InitializeComponent();

            img_producto.Source = img;

            LabelName.Text = Name;

            LabelPrice.Text = price;

            BtnAgregar.Clicked += BtnAgregar_Clicked;

        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {

            Shoppingcart Shop = new Shoppingcart();
            Shop.LoadProducts(LabelName.Text, "https://thumbs.dreamstime.com/z/item-del-nuevo-producto-en-almac%C3%A9n-25048588.jpg", Decimal.Parse(LabelPrice.Text));
            DisplayAlert("Compra", "Producto Agregado al Carrito", "Aceptar");
            ((NavigationPage)this.Parent).PushAsync(new Celulares());

        }
    }
}
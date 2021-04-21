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
        Products phone = new Products();

        public Individual(Products item)
        {
            InitializeComponent();

            phone.PRODUCTO_ID = item.PRODUCTO_ID;
            phone.NOMBRE = item.NOMBRE;
            phone.DETALLES = item.DETALLES;
            phone.IMAGEN = item.IMAGEN;
            phone.GARANTIA = item.GARANTIA;
            phone.PRECIO = item.PRECIO;
            phone.STOCK = item.STOCK;


            img_producto.Source = item.IMAGEN;

            LabelName.Text = item.NOMBRE;

            LabelPrice.Text = item.PRECIO.ToString();

            BtnAgregar.Clicked += BtnAgregar_Clicked;

        }


        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {

            Products carrito = new Products();
            carrito.agregarItem(phone);

            // Verificacion y redirrecion

            DisplayAlert("Compra", "Producto Agregado al Carrito", "Aceptar");
            ((NavigationPage)this.Parent).PushAsync(new Celulares());

        }
    }
}
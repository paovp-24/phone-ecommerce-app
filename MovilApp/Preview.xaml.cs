
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
    public partial class Preview : ContentPage
    {
        Products products = new Products();
        Cuot miCuota = new Cuot();


        public Preview(Cuot cuot)
        {
            InitializeComponent();

            lstPreview.ItemsSource = Products.carrito;

            miCuota.TIPO_CUOTA = cuot.TIPO_CUOTA;
            miCuota.TASA_INTERES = cuot.TASA_INTERES;

            labelTipoPlan.Text = $" Tipo de Plan: {cuot.TIPO_CUOTA}";
            labelInteres.Text = $" Tasa de Interés: {cuot.TASA_INTERES.ToString()}";

            labelTotal.Text = $"Precio total de los productos: {products.devolverPrecio()}";

            labelTotalInteres.Text = $"Total: {calcularPrecioFinal(products.devolverPrecio(),cuot.TASA_INTERES)}";
           

            btnTerminar.Clicked += btnTerminar_Clicked;

            BindingContext = this;

            //calcularPrecioFinal();
        }

        private void btnTerminar_Clicked(object sender, EventArgs e)
        {
            //Generar el envio por correo

        }

        private decimal calcularPrecioFinal(decimal totalPrecio, decimal tasaInteres)
        {
            decimal precioFinal = totalPrecio + (totalPrecio * tasaInteres);

            return precioFinal;
        }


    }
}



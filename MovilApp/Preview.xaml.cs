
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovilApp.Models;
using MovilApp.Controllers;

namespace MovilApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preview : ContentPage
    {

        MainPage mainPage = new MainPage();

        FacturaManager facturaManager = new FacturaManager();
        Compra_productoManager compra_productoManager = new Compra_productoManager();
        Products products = new Products();
        Cuot miCuota = new Cuot();

        decimal Monto;

        public Preview(Cuot cuot)
        {
            InitializeComponent();

            lstPreview.ItemsSource = Products.carrito;

            miCuota.TIPO_CUOTA = cuot.TIPO_CUOTA;
            miCuota.TASA_INTERES = cuot.TASA_INTERES;

            labelTipoPlan.Text = $" Tipo de Plan: {cuot.TIPO_CUOTA}";
            labelInteres.Text = $" Tasa de Interés: {cuot.TASA_INTERES.ToString()}";

            labelTotal.Text = $"Precio total de los productos: {products.devolverPrecio()}";

            miCuota = cuot;

            Monto = calcularPrecioFinal(products.devolverPrecio(), cuot.TASA_INTERES);

            labelTotalInteres.Text = $"Total: {Monto}";
           
          
            btnTerminar.Clicked += btnTerminar_Clicked;

            BindingContext = this;

            //calcularPrecioFinal();
        }





        private void btnTerminar_Clicked(object sender, EventArgs e)
        {

            try
            {
                Factura factura = new Factura()
                {

                    USUARIO_ID = App.usuarioSesionID,
                    PLAN_ID = miCuota.CUOTA_ID,
                    MONTO_FACTURA = Monto,
                    CANT_PRODUCTOS = Products.carrito.Count,
                    ESTADO = "1"
                };
                generarFactura(factura);
              


                foreach (Products item in Products.carrito)
                {
                    agregarProductosACompra(3, item.PRODUCTO_ID);
                }

                
            }
            catch (Exception ex)
            {
                 DisplayAlert("Proceso de Compra", "Error en la Compra del Carrito, intente denuevo", "Aceptar");
            }
        }


        private async Task<Compra_producto> agregarProductosACompra(int FACTURA_ID, int PRODUCTO_ID)
        {
            Compra_producto compra_producto = new Compra_producto()
            {
                FACTURA_ID = FACTURA_ID,
                PRODUCTO_ID = PRODUCTO_ID

            };

            await compra_productoManager.Ingresar(compra_producto);
            return compra_producto;
        }


        private async Task<Factura> generarFactura(Factura factura)
        {
            return await facturaManager.Ingresar(factura);
        }






        //Generar el envio por correo

    

        private decimal calcularPrecioFinal(decimal totalPrecio, decimal tasaInteres)
        {
            decimal precioFinal = totalPrecio + (totalPrecio * tasaInteres);

            return precioFinal;
        }


    }
}



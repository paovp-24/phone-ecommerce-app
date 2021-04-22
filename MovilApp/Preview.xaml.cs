
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






        private async void btnTerminar_Clicked(object sender, EventArgs e)
        {

            try
            {

                //Genera los datos de la factura
                FacturaManager facturaManager = new FacturaManager();
                Factura facturaIngresado = new Factura();
                Factura factura = new Factura()

                {

                    USUARIO_ID = App.usuarioSesionID,
                    PLAN_ID = miCuota.CUOTA_ID,
                    MONTO_FACTURA = Monto,
                    CANT_PRODUCTOS = Products.carrito.Count,
                    ESTADO = "1"

                };

                //Ingresa la factura a la base de datos
                facturaIngresado = await facturaManager.Ingresar(factura);

                App.facturaSesionID = await facturaManager.obtenerUltimoID();


                //Genera los datos de compra_producto
                Compra_productoManager compra_productoManager = new Compra_productoManager();
                Compra_producto compra_productoIngresado = new Compra_producto();


                foreach (Products product in Products.carrito)
                {
                    Compra_producto compra_producto = new Compra_producto()

                    {
                        FACTURA_ID = App.facturaSesionID,
                        PRODUCTO_ID = product.PRODUCTO_ID

                    };

                    //Ingresa la compra_producto a la base de datos
                    compra_productoIngresado = await compra_productoManager.Ingresar(compra_producto);

                }






                if (facturaIngresado != null && compra_productoIngresado != null)
                {
                    await DisplayAlert("Proceso de Compra", "Compra del Carrito realizado con exito", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Proceso de Compra", "Error en la Compra del Carrito, intente denuevo", "Aceptar");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Proceso de Compra", "Error en la Compra del Carrito, intente denuevo", "Aceptar");
            }
        }






        //Generar el envio por correo



        private decimal calcularPrecioFinal(decimal totalPrecio, decimal tasaInteres)
        {
            decimal precioFinal = totalPrecio + (totalPrecio * tasaInteres);

            return precioFinal;
        }


    }
}


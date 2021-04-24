using MovilApp.Controllers;
using MovilApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class verFactura : ContentPage
    {
        int meses;
        Factura miFactura = new Factura();
        FacturaManager facturaManager = new FacturaManager();

        public verFactura()
        {
            InitializeComponent();
            inicializarControles();


        }


        async private void inicializarControles()
        {
            IEnumerable<Factura> facturas = new ObservableCollection<Factura>();

            miFactura.USUARIO_ID = App.usuarioSesionID;

            facturas = await facturaManager.ObtenerFactura(miFactura);
            listaFactura.ItemsSource = facturas;
        }


        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Factura selectedItem = e.SelectedItem as Factura;


            var action = await DisplayAlert("Pago de la Factura", "¿Quiere pagar la mensualidad de este plan?", "Pagar", "Cancelar");
            if (action)
            {
                //Actualiza el plan mensual
                selectedItem.MONTO_FACTURA = selectedItem.MONTO_FACTURA - selectedItem.PAGO_MENSUAL;

                await facturaManager.actualizarMontoTotal(selectedItem);

                if (selectedItem.MONTO_FACTURA == 0 || selectedItem.MONTO_FACTURA < 1)
                {
                    await facturaManager.actualizarEstadoPagado(selectedItem);

                    await DisplayAlert("Proceso de Abono realizado", "Redireccionando al correo para finalizar la factura", "Aceptar");
                    await Launcher.OpenAsync(new Uri($"mailto:{App.usuarioSesionEmail}?subject=MovilApp-Actualización del estado del plan&body=La factura fue cancelado con el pago mensual y está pagado"));
                    refresh();
                }
            else
            {
                    switch (selectedItem.PLAN_ID)
                    {
                        case 1:
                            meses = 3;
                            break;

                        case 2:
                            meses = 6;
                            break;
                        case 3:
                            meses = 9;
                            break;
                    }

                    //Envio del correo
                    await Launcher.OpenAsync(new Uri($"mailto:{App.usuarioSesionEmail}?subject=MovilApp-Actualización del estado del plan&body=Detalles de la factura\n" +
                $"ID de Factura: {App.facturaSesionID}\n" +
                $"ID Plan: {selectedItem.PLAN_ID}\n" +
                $"Nuevo Monto de la factura: {selectedItem.MONTO_FACTURA}\n" +
                $"Cantidad de productos: {Products.carrito.Count}\n" +
                $"Pago mensual: {selectedItem.MONTO_FACTURA / meses}"));
                refresh();


                }
               
            }
           
        }

     

        private void refresh()
        {
            var vUpdatedPage = new verFactura(); Navigation.InsertPageBefore(vUpdatedPage, this); Navigation.PopAsync();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Cuot tappedItem = e.Item as Cuot;
        }

    }
}
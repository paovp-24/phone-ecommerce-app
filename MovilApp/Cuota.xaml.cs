using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovilApp.Controllers;
using MovilApp.Models;
using System.Collections.ObjectModel;

namespace MovilApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cuota : ContentPage
    {
        public string planSeleccionado;
        
        
            
        public Cuota()
        {
            InitializeComponent();

            initControllers();


            
        }

        async private void initControllers()
        {
            CuotaManager miCuota  = new CuotaManager();
            IEnumerable<Cuot> cuotas = new ObservableCollection<Cuot>();
            cuotas = await miCuota.ObtenerCuota();
            listaPlan.ItemsSource = cuotas;
        }



        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cuot selectedItem = e.SelectedItem as Cuot;

            var action = await DisplayAlert("Planeamiento de finanzas", "¿Quiere seleccionar este plan para su facturación?", "Si", "No");
            if (action)
            {
                await ((NavigationPage)this.Parent).PushAsync(new Preview());

            }
            else
            {
                await DisplayAlert("Plan", "Seleccione un plan", "Aceptar");
            }


        }


        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Products tappedItem = e.Item as Products;
        }

    }
}
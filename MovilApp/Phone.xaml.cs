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
    public partial class Celulares : ContentPage
    {


        public Celulares()
        {
            InitializeComponent();


            InicializarControles();


            BuyCar.Clicked += BuyCar_Clicked;

        }

        private void BuyCar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Shoppingcart());
        }

        async private void InicializarControles()
        {
            ProductsManager ProductManager = new ProductsManager();
            IEnumerable<Products> products = new ObservableCollection<Products>();
            products = await ProductManager.ObtenerUsuarios();
            lstProducts.ItemsSource = products;
        }



        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Products selectedItem = e.SelectedItem as Products;

            ((ListView)sender).SelectedItem = null;

            if (e.SelectedItem == null) return;
            {
                //DisplayAlert("Proximamente", selectedItem.Name, "Muchas Gracias");
            }


            Individual indiv = new Individual(selectedItem); 

            indiv.Title = (selectedItem.NOMBRE); 

            Navigation.PushAsync(indiv);

        }


        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Products tappedItem = e.Item as Products;
        }

    }
}
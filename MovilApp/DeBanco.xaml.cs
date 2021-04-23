using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeBanco : ContentPage
    {
        public DeBanco()
        {
            InitializeComponent();


            Btnsalir.Clicked += Btnsalir_Clicked;

            BtnCompra.Clicked += BtnCompra_Clicked;

            btnVerFactura.Clicked += BtnVerFactura_Clicked;

            BuyCar.Clicked += BuyCar_Clicked;

        }

        private void BtnVerFactura_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new verFactura());

        }

        private void BuyCar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Shoppingcart());
        }


        private void BtnCompra_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Celulares());
        }

        private void Btnsalir_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }
    }
}
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

        public List<Proform> Shopping { get; set; }


        public Shoppingcart()
        {
            InitializeComponent();
            Shopping = new List<Proform>();
            LoadProductsG();



            BindingContext = this;


            Btnsalir.Clicked += Btnsalir_Clicked;
        }




        public void LoadProductsG()
        {

            Shopping = new List<Proform>();

            Shopping.Add(new Proform
            {
                NOMBR = "Samsung",
                IMAGE = "https://images.samsung.com/is/image/samsung/latin-galaxy-s20-plus-g985-bts-sm-g985fzpjgto-frontbpurple-thumb-261222598",
                PRECI = 5

            });

        }


        public void LoadProducts(string Name, string Image, decimal Price)
        {


            Shopping.Add(new Proform
            {
                NOMBR = Name,
                IMAGE = Image,
                PRECI = Price

            });
        }










        private void Btnsalir_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new DeBanco());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            throw new NotImplementedException();

        }


        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}
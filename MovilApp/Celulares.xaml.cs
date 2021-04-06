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
    public partial class Celulares : ContentPage
    {

        public IList<Producto> Productos
        {
            get;
            private set;
        }



        public Celulares()
        {
            InitializeComponent();



            Btnsalir.Clicked += Btnsalir_Clicked;



            Productos = new List<Producto>();


            Productos.Add(new Producto
            {
                Name = "Samsung Galaxy Note20 Ultra",
                Price = "Precio: ¢53.400/mes",
                Url = "https://images.samsung.com/is/image/samsung/latin-galaxy-note20-ultra-n985-sm-n985fzkkgto-frontmysticblack-320814281?$684_547_PNG$"
            });


            Productos.Add(new Producto
            {
                Name = "Apple iPhone 12 PRO MAX 128GB",
                Price = "Precio: ¢54.500/mes",
                Url = "https://cdn.tmobile.com/content/dam/t-mobile/en-p/cell-phones/apple/Apple-iPhone-12-Pro-Max/Pacific-Blue/Apple-iPhone-12-Pro-Max-Pacific-Blue-frontimage.png"
            });

            Productos.Add(new Producto
            {
                Name = "Huawei P40 PRO",
                Price = "Precio: ¢20.000/mes",
                Url = "https://www.movilzona.es/app/uploads/2020/03/Huawei-P40-Pro-GRANDE-1.png"
            });

            Productos.Add(new Producto
            {
                Name = "Xiaomi Redmi Note 9",
                Price = "Precio: ¢20.000/mes",
                Url = "https://www.amcsolutions.pe/wp-content/uploads/2020/09/Redmi-note-9.png"
            });

            Productos.Add(new Producto
            {
                Name = "LG K71",
                Price = "Precio: ¢20.400/mes",
                Url = "https://digicompra.com.gt/wp-content/uploads/2020/11/LG_K51s_Azul-900x900.png"
            });

            BindingContext = this;

        }

        private void Btnsalir_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new DeBanco());
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Producto selectedItem = e.SelectedItem as Producto;
        }


        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Producto tappedItem = e.Item as Producto;
        }

    }
}
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
                Url = "https://images-na.ssl-images-amazon.com/images/I/712aHRi7eGL._AC_SX679_.jpg"
            });


            Productos.Add(new Producto
            {
                Name = "Apple iPhone 12 PRO MAX 128GB",
                Price = "Precio: ¢54.500/mes",
                Url = "https://img.pccomponentes.com/articles/32/328880/1943-apple-iphone-12-pro-max-128gb-azul-pacifico-libre.jpg"
            });

            Productos.Add(new Producto
            {
                Name = "Huawei P40 PRO",
                Price = "Precio: ¢20.000/mes",
                Url = "https://www.muycomputer.com/wp-content/uploads/2020/03/Huawei-P40-Pro-Plus-5G-e1584952635501.jpg"
            });

            Productos.Add(new Producto
            {
                Name = "Xiaomi Redmi Note 9",
                Price = "Precio: ¢20.000/mes",
                Url = "https://images-na.ssl-images-amazon.com/images/I/61lXY%2BSfrWL._AC_SX522_.jpg"
            });

            Productos.Add(new Producto
            {
                Name = "LG K71",
                Price = "Precio: ¢20.400/mes",
                Url = "https://i.blogs.es/b282a2/lgk71/1366_2000.jpg"
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
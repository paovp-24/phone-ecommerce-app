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
    public partial class Preview : ContentPage
    {
        public Preview()
        {
            InitializeComponent();

            btnTerminar.Clicked += BtnTerminar_Clicked;
        }

        private void BtnTerminar_Clicked(object sender, EventArgs e)
        {



        }
    }
}
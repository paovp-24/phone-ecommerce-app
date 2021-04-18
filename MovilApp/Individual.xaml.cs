using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilApp
{
  
    public partial class Individual : ContentPage
    {
        public Individual( string Name, string price, string img)
        {
            InitializeComponent();

            img_producto.Source = img;

            LabelName.Text = Name;

            LabelPrice.Text = price;



        }
    }
}
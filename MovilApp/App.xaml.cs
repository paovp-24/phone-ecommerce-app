using MovilApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilApp
{
    public partial class App : Application
    {
        public static string Token;
        public static int usuarioSesionID { get; set; }
        public static int facturaSesionID { get; set; }
        public static string usuarioSesionEmail { get; set; }


        public App(string filename)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

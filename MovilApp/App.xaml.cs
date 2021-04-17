using MovilApp.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilApp
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();
            UsuarioRepository.Inicializador(filename);
            MainPage = new NavigationPage( new MainPage());
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

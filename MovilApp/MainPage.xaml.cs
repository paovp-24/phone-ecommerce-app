using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovilApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnIr.Clicked += BtnIr_Clicked;

            Registrarse.Clicked += Registrarse_Clicked;

            Recuperar.Clicked += Recuperar_Clicked;
        }

        private void Recuperar_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Recuperar());
        }

        private void Registrarse_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Registro());
        }

        private void BtnIr_Clicked(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Usuario" && txtPass.Text == "123456")
            {
                DisplayAlert("Inicio de Sesion", "Ingreso Correcto, Bienvenido!!!", "Confirmar");
                ((NavigationPage)this.Parent).PushAsync(new DeBanco());
            }
            else
            {
                DisplayAlert("Inicio de Sesion", "Ingreso Incorrecto, Revise sus credenciales", "Cancelar");
            }
        }

        
    }
}

using System;
using System.Text;
using Xamarin.Forms;
using MovilApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using MovilApp.Controllers;

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

        private async void BtnIr_Clicked(object sender, EventArgs e)
        {
            UserManager usuarioManager = new UserManager();
            Login userLogin = await usuarioManager.Validar(txtCorreo.Text, txtPass.Text);
            App.usuarioSesionID = await usuarioManager.obtenerUsuarioID(txtCorreo.Text, txtPass.Text);
            App.usuarioSesionEmail = txtCorreo.Text;

            if (userLogin != null)
            {
                //await DisplayAlert("Usuario Session ID", App.usuarioSesionID.ToString(), "Aceptar");
                await DisplayAlert("Inicio de Sesion", "Ingreso Correcto, Bienvenido!!", "Confirmar");
                await ((NavigationPage)this.Parent).PushAsync(new DeBanco());
            }
            else if (userLogin == null)
            {
                await DisplayAlert("Inicio de Sesion", "Ingreso Incorrecto, Revise sus credenciales", "Cancelar");

            }
            else
            {
                await DisplayAlert("Inicio de Sesion", "Ingreso Incorrecto, Revise sus credenciales", "Cancelar");
            }




        }


    }
}
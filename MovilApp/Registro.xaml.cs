using MovilApp.Controllers;
using MovilApp.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace MovilApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        
        public Registro()
        {
            InitializeComponent();

            btnIr.Clicked += BtnIr_Clicked;
            
            btnVolver.Clicked += BtnVolver_Clicked;
        }

        private void BtnVolver_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

        private async void BtnIr_Clicked (object sender, EventArgs e)
        {
            if (txtNombre.Text != null &&
                txtApellido.Text != null &&
                txtIdentificacion.Text != null &&
                txtCorreo.Text != null &&
                txtPhone.Text != null &&
                txtDireccion.Text != null &&
                txtPass.Text != null &&
                txtPassConfirm.Text != null &&
                txtPass.Text == txtPassConfirm.Text)
            {
                UserManager userManager = new UserManager();
                Usuario user = new Usuario();
                Usuario registerUser = new Usuario()
                {
                    Nombre = txtNombre.Text,
                    Apellidos = txtApellido.Text,
                    ID = txtIdentificacion.Text,
                    Telefono = Convert.ToInt32(txtPhone.Text),
                    Direccion = txtDireccion.Text,
                    Email = txtCorreo.Text,
                    Password = txtPass.Text

                };

                user = await userManager.Ingresar(registerUser);

                if (user != null)
                {
                    await DisplayAlert("Registro", "Registro Completado, Inicie Sesion", "Ir");
                    await ((NavigationPage)this.Parent).PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Registro incorrecto", "Revise los datos", "Aceptar");
                }

            }
            if (txtNombre.Text != null &&
                txtApellido.Text != null &&
                txtIdentificacion.Text != null &&
                txtCorreo.Text != null &&
                txtPhone.Text != null &&
                txtDireccion.Text != null &&
               txtPassConfirm.Text != null &&
               txtPass.Text != txtPassConfirm.Text)
            {
               await DisplayAlert("Registro", "Registro Incorrecto, Las contraseñas no coinciden", "Volver");
            }

            if (txtNombre.Text == null &&
                txtCorreo.Text == null &&
                txtPhone.Text == null &&
                txtPass.Text == null &&
                txtPassConfirm.Text == null
            )
            {
                await DisplayAlert("Registro", "Registro Incorrecto, Revise que todos los datos esten completos", "Volver");
            }
        }

    }
}
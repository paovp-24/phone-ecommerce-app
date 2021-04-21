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

            btnRegistrar.Clicked += btnRegistrar_Clicked;
            
            btnVolver.Clicked += BtnVolver_Clicked;
        }

        private void BtnVolver_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
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

                Usuario registerUser = new Usuario()
                {
                    NOMBRE = txtNombre.Text,
                    APELLIDOS = txtApellido.Text,
                    IDENTIFICACION = txtIdentificacion.Text,
                    TELEFONO = Convert.ToInt32(txtPhone.Text),
                    DIRECCION = txtDireccion.Text,
                    EMAIL = txtCorreo.Text,
                    PASSWORD = txtPass.Text,

                };
                UserManager usuarioManager = new UserManager();

                Usuario usuarioRegistrado = await usuarioManager.Registrar(registerUser);

                if (registerUser != null)
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

            if (txtNombre.Text == null ||
                txtApellido.Text == null||
                txtIdentificacion.Text == null||
                txtDireccion.Text == null||
                txtCorreo.Text == null ||
                txtPhone.Text == null ||
                txtPass.Text == null ||
                txtPassConfirm.Text == null

            )
            {
                await DisplayAlert("Registro", "Registro Incorrecto, Revise que todos los datos esten completos", "Volver");
            }
        }

    }
}
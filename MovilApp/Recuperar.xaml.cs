using MovilApp.Controllers;
using MovilApp.Models;
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
    public partial class Recuperar : ContentPage
    {

        UserManager usuarioManager = new UserManager();
        Login usuarioActualizado = new Login();


        public Recuperar()
        {
            InitializeComponent();

            btnCambiarClave.Clicked += btnCambiarClave_Clicked;

            btnVolver.Clicked += BtnVolver_Clicked;
        }

        private void BtnVolver_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

        private async void btnCambiarClave_Clicked(object sender, EventArgs e)
        {

            //try
            //{
            //    if (ValidarInsertar() && (!string.IsNullOrEmpty(txtCodigo.Text)))
            //    {
            //        HotelManager hotelManager = new HotelManager();
            //        Hotel hotelActualizado = new Hotel();
            //        Hotel hotel = new Hotel()
            //        {
            //            HOT_CODIGO = Convert.ToInt32(txtCodigo.Text),
            //            HOT_NOMBRE = txtNombre.Text,
            //            HOT_EMAIL = txtEmail.Text,
            //            HOT_DIRECCION = txtDireccion.Text,
            //            HOT_TELEFONO = txtTelefono.Text,
            //            HOT_CATEGORIA = pkrCategoria.SelectedItem.ToString().Substring(0, 1)
            //        };

            //        hotelActualizado = await hotelManager.Actualizar(hotel, App.Token);

            //        if (hotelActualizado != null)
            //        {
            //            await DisplayAlert("Actualizacion de usuario", "Se ha cambiado la contraseña", "Aceptar");
            //        }
            //        else
            //        {
            //            await DisplayAlert("Actualizacion de usuario","Ocurrio un error", "Aceptar");
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("Error", ex.Message, "Ok");
            //}


            if (txtCorreo.Text != null &&
             txtOldpass.Text != null &&
             txtPass.Text != null &&
             txtPassConfirm.Text != null &&
             txtPass.Text == txtPassConfirm.Text)
            {
                Login login = new Login()
                {
                    Correo = txtCorreo.Text,
                    Password = txtPass.Text
                };

                usuarioActualizado = await usuarioManager.cambiarClave(login);

                if (usuarioActualizado != null)
                {
                    await DisplayAlert("Cambio de Contraseña", "Cambio de Contraseña correcto, Inicie Sesion", "Ir");
                    await ((NavigationPage)this.Parent).PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Actualizacion de usuario", "Ocurrio un error", "Aceptar");
                }

            }
            else if (txtPass.Text != txtPassConfirm.Text)
            {
                await DisplayAlert("Cambio de Contraseña", "Las contraseñas no coinciden", "Ir");

            }
            else
            {
                await DisplayAlert("Cambio de Contraseña", "Cambio de Contraseña Incorrecto, Revise que todos los datos esten completos", "Volver");
            }




        }


    }
}
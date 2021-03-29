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

        private void BtnIr_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text != null &&
                txtCorreo.Text != null &&
                txtPhone.Text != null &&
                txtPass.Text != null &&
                txtPassConfirm.Text != null &&
                txtPass.Text == txtPassConfirm.Text)
            {
                DisplayAlert("Registro", "Registro Completado, Inicie Sesion", "Ir");
                ((NavigationPage)this.Parent).PushAsync(new MainPage());

            }

            if (txtNombre.Text != null &&
               txtCorreo.Text != null &&
               txtPhone.Text != null &&
               txtPass.Text != null &&
               txtPassConfirm.Text != null &&
               txtPass.Text != txtPassConfirm.Text)
            {
                DisplayAlert("Registro", "Registro Incorrecto, Las contraseñas no coinciden", "Volver");
            }

            if (txtNombre.Text == null &&
                txtCorreo.Text == null &&
                txtPhone.Text == null &&
                txtPass.Text == null &&
                txtPassConfirm.Text == null
            )
            {
                DisplayAlert("Registro", "Registro Incorrecto, Revise que todos los datos esten completos", "Volver");
            }



        }
    }
}
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
        public Recuperar()
        {
            InitializeComponent();

            btnRecuperar.Clicked += btnRecuperar_Clicked;

            btnVolver.Clicked += BtnVolver_Clicked;
        }

        private void BtnVolver_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

        private void btnRecuperar_Clicked(object sender, EventArgs e)
        {
            if (txtCorreo.Text != null &&
             txtOldpass.Text != null &&
             txtPass.Text != null &&
             txtPassConfirm.Text != null &&
             txtPass.Text == txtPassConfirm.Text)
            {

                DisplayAlert("Cambio de Contraseña", "Cambio de Contraseña correcto, Inicie Sesion", "Ir");
                ((NavigationPage)this.Parent).PushAsync(new MainPage());
            }
            else
            {
                DisplayAlert("Cambio de Contraseña", "Cambio de Contraseña Incorrecto, Revise que todos los datos esten completos", "Volver");
            }
        }
    }
}
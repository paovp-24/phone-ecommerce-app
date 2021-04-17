using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MovilApp.Models;

namespace MovilApp
{
    public partial class MainPage : ContentPage
    {
        String DB_PATH = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Siu_cSharp.db3");

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
            var db = new SQLiteConnection(DB_PATH);
            var tablaUsuario = db.Table<Usuario>();
            var adminDB = tablaUsuario.Where(field => field.Email == txtCorreo.Text && field.Password == txtPass.Text && field.Rol == 1).FirstOrDefault();
            var usuarioDB = tablaUsuario.Where(field => field.Email == txtCorreo.Text && field.Password == txtPass.Text && field.Rol == 0).FirstOrDefault();


            //if (txtCorreo.Text == "Usuario" && txtPass.Text == "123456")
            if (usuarioDB != null)
            {
                DisplayAlert("Inicio de Sesion", "Ingreso Correcto, Bienvenido!!!", "Confirmar");
                ((NavigationPage)this.Parent).PushAsync(new DeBanco());
            }
            else if (adminDB != null )
            {
                DisplayAlert("Inicio de Sesion", "Ingreso Correcto como administrador, Bienvenido!!!", "Confirmar");
                ((NavigationPage)this.Parent).PushAsync(new Admin());
            }
            else
            {
                DisplayAlert("Inicio de Sesion", "Ingreso Incorrecto, Revise sus credenciales", "Cancelar");
            }
        }

        
    }
}

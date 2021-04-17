using MovilApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        String DB_PATH = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Siu_cSharp.db3");
        
        public Registro()
        {
            InitializeComponent();

            btnIr.Clicked += BtnIr_Clicked;
            btnCrearAdmin.Clicked += BtnCrearAdmin_Clicked;

            btnVolver.Clicked += BtnVolver_Clicked;
        }

        private async void BtnCrearAdmin_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text != null &&
                txtApellidoPaterno.Text != null &&
                txtApellidoMaterno.Text != null &&
                txtIdentificacion.Text != null &&
                fecha.Date.ToString() != null &&
                txtCorreo.Text != null &&
                txtPhone.Text != null &&
                txtDireccion.Text != null &&
                txtPass.Text != null &&
                txtPassConfirm.Text != null &&
                txtPass.Text == txtPassConfirm.Text)
            {
                var db = new SQLiteConnection(DB_PATH);
                db.CreateTable<Usuario>();

                var pKey = db.Table<Usuario>().OrderByDescending(field => field.Usuario_ID).FirstOrDefault();

                Usuario usuario = new Usuario()
                {
                    Usuario_ID = (pKey == null ? 1 : pKey.Usuario_ID + 1),
                    Nombre = txtNombre.Text,
                    Apellido_Paterno = txtApellidoPaterno.Text,
                    Apellido_Materno = txtApellidoMaterno.Text,
                    ID = Convert.ToInt32(txtIdentificacion.Text),
                    Telefono = Convert.ToInt32(txtPhone.Text),
                    Fecha_Nacimiento = fecha.Date.ToString(),
                    Direccion = txtDireccion.Text,
                    Email = txtCorreo.Text,
                    Password = txtPass.Text,
                    Rol = 1
                };

                if (validarCorreo(txtCorreo.Text) == true) { await DisplayAlert("Ups!", "El correo ya existe", "Aceptar"); }
                else
                {
                    db.Insert(usuario);

                    await DisplayAlert("Registro", "Registro Completado de Administrador, Inicie Sesion", "Ir");

                    await ((NavigationPage)this.Parent).PushAsync(new MainPage());
                }


            }

            if (txtNombre.Text != null &&
                txtApellidoPaterno.Text != null &&
                txtApellidoMaterno.Text != null &&
                txtIdentificacion.Text != null &&
                fecha.Date.ToString() != null &&
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

        private void BtnVolver_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }

        private async void BtnIr_Clicked (object sender, EventArgs e)
        {
            if (txtNombre.Text != null &&
                txtApellidoPaterno.Text != null &&
                txtApellidoMaterno.Text != null &&
                txtIdentificacion.Text != null &&
                fecha.Date.ToString() != null &&
                txtCorreo.Text != null &&
                txtPhone.Text != null &&
                txtDireccion.Text != null &&
                txtPass.Text != null &&
                txtPassConfirm.Text != null &&
                txtPass.Text == txtPassConfirm.Text)
            {
                var db = new SQLiteConnection(DB_PATH);
                db.CreateTable<Usuario>();

                var pKey = db.Table<Usuario>().OrderByDescending(field => field.Usuario_ID).FirstOrDefault();

                Usuario usuario = new Usuario()
                {
                    Usuario_ID = (pKey == null ? 1 : pKey.Usuario_ID + 1),
                    Nombre = txtNombre.Text,
                    Apellido_Paterno = txtApellidoPaterno.Text,
                    Apellido_Materno = txtApellidoMaterno.Text,
                    ID = Convert.ToInt32(txtIdentificacion.Text),
                    Telefono = Convert.ToInt32(txtPhone.Text),
                    Fecha_Nacimiento = fecha.Date.ToString(),
                    Direccion = txtDireccion.Text,
                    Email = txtCorreo.Text,
                    Password = txtPass.Text,
                    Rol = 0
                };

                if (validarCorreo(txtCorreo.Text) == true) { await DisplayAlert("Ups!", "El correo ya existe", "Aceptar"); }
                else {
                    db.Insert(usuario);

                    await DisplayAlert("Registro", "Registro Completado, Inicie Sesion", "Ir");

                    await ((NavigationPage)this.Parent).PushAsync(new MainPage());
                }
            }

            if (txtNombre.Text != null &&
                txtApellidoPaterno.Text != null &&
                txtApellidoMaterno.Text != null &&
                txtIdentificacion.Text != null &&
                fecha.Date.ToString() != null &&
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

        public bool validarCorreo(string correo)
        {
            var db = new SQLiteConnection(DB_PATH);
            var correoExistente = db.Table<Usuario>().Where(field => field.Email == correo).ToList();

            return (correoExistente.Count() > 0);
        }
    }
}
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
    public partial class Admin : ContentPage
    {
        public Admin()
        {
            InitializeComponent();
            BtnAllUser.Clicked += BtnAllUser_Clicked;
        }
        private void BtnAllUser_Clicked(object sender, EventArgs e)
        {
            var allUsers = UsuarioRepository.Instancia.GetAllUsers();
            userList.ItemsSource = allUsers;
            StatusMessage.Text = UsuarioRepository.Instancia.EstadoMensaje;
        }

    }
}
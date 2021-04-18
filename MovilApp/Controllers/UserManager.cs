using MovilApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovilApp.Controllers
{
    class UserManager
    {

        string UrlAuthenticate = "http://192.168.0.28:45455/api/login/authenticate";
        string UrlRegister = "http://192.168.0.28:45455/api/login/register";
        string UrlAllUser = "http://192.168.0.28:45455/api/login/allUser";


        public async Task<Usuario> Ingresar(Usuario usuario)
        {
            HttpClient httpClient = GetClient();

            var response = await httpClient.PostAsync(UrlRegister,
                new StringContent(JsonConvert.SerializeObject(usuario),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
        }

        HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        public async Task<Login> Validar(string correo, string password)
        {
            Login loginRequest = new Login() { Correo = correo, Password = password };

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(UrlAuthenticate,
                new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json")
                );

            return JsonConvert.DeserializeObject<Login>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Usuario> Registrar(Usuario usuario)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.PostAsync(UrlRegister,
                new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarios(string token)
        {
            HttpClient httpClient = GetClient();

            string resultado = await httpClient.GetStringAsync(UrlAllUser);

            return JsonConvert.DeserializeObject<IEnumerable<Usuario>>(resultado);
        }




    }
}

using SQLite;
using System;

namespace MovilApp.Models
{
    public class Usuario
    {
        public int Usuario_ID { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string ID { get; set; }

        public int Telefono { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Rol { get; set; }
    }
}

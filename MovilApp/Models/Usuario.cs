using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovilApp.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Usuario_ID { get; set; }

        [MaxLength(100)]
        public String Nombre { get; set; }

        [MaxLength(100)]
        public String Apellido_Paterno { get; set; }

        [MaxLength(100)]
        public String Apellido_Materno { get; set; }

        [MaxLength(9)]
        public int ID { get; set; }

        [MaxLength(8)]
        public int Telefono { get; set; }

        [MaxLength(100)]
        public String Fecha_Nacimiento { get; set; }

        [MaxLength(100)]
        public String Direccion { get; set; }

        [MaxLength(100), Unique]
        public String Email { get; set; }

        [MaxLength(100)]
        public String Password { get; set; }

        [MaxLength(1)]
        public int Rol { get; set; }
    }
}

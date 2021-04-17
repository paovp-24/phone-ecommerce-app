using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovilApp.Models
{
    class UsuarioRepository
    {
        private SQLiteConnection con;
        private static UsuarioRepository instancia;
        public static UsuarioRepository Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return instancia;
            }
        }
        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instancia != null)
            {
                instancia.con.Close();
            }
            instancia = new UsuarioRepository(filename);
        }
        private UsuarioRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Usuario>();
        }
        public string EstadoMensaje;
        public int AddNewUser(string nombre, string apellido_materno, string apellido_paterno, int identificador, int tel, string email, string fecha_nac, string direccion,  string password)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Usuario
                {
                    Nombre = nombre,
                    Apellido_Materno = apellido_materno,
                    Apellido_Paterno = apellido_paterno,
                    ID = identificador,
                    Telefono = tel,
                    Fecha_Nacimiento = fecha_nac,
                    Email = email,
                    Direccion = direccion,
                    Password = password,
                   
                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }
        public IEnumerable<Usuario> GetAllUsers()
        {
            try
            {
                return con.Table<Usuario>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Usuario>();
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diprolim
{
    public class conexion
    {
        public MySqlConnection ObtenerConexion()
        {
            Leer_txt();
            MySqlConnection conectar = new MySqlConnection("server=" + Servidor + "; database=" + BaseDeDatos + "; Uid=" + Usuarios + "; pwd=" + Password + ";connectiontimeout=30;SslMode=none");
            return conectar;
        }
        int Cont = 0;
        string Linea;
        String Gestor;
        String BaseDeDatos;
        String Servidor;
        String Usuarios;
        String Password;
        public void Leer_txt()
        {
            StreamReader txt = new StreamReader(@"Config.txt");

            while ((Linea = txt.ReadLine()) != null)
            {
                if (Cont == 0)
                {
                    Gestor = Linea;
                }
                else if (Cont == 1)
                {
                    Servidor = Linea;
                }
                else if (Cont == 2)
                {
                    BaseDeDatos = Linea;
                }
                else if (Cont == 3)
                {
                    Usuarios = Linea;
                }
                else if (Cont == 4)
                {
                    Password = Linea;
                }
                Cont++;
            }
            txt.Close();
        }
    }
}

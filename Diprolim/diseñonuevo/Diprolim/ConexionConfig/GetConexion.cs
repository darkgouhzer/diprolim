using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionConfig
{
    public class GetConexion
    {
        public static GetConexion _instance = null;

        public CConexionData getObj;
        private GetConexion()
        {
            getObj = new CConexionData();
            Leer_txt();
        }

        public static GetConexion Instance
        {
            get
            {
                // The first call will create the one and only instance.
                if (_instance == null)
                {
                    _instance = new GetConexion();
                }

                // Every call afterwards will return the single instance created above.
                return _instance;
            }
        }

        private void Leer_txt()
        {
            StreamReader txt = new StreamReader(@"Config.txt");

            int Cont = 0;
            String Linea = "";
            while ((Linea = txt.ReadLine()) != null)
            {
                if (Cont == 0)
                {
                    getObj.Gestor = Linea;
                }
                else if (Cont == 1)
                {
                    getObj.Servidor = Linea;
                }
                else if (Cont == 2)
                {
                    getObj.BaseDeDatos = Linea;
                }
                else if (Cont == 3)
                {
                    getObj.Usuarios = Linea;
                }
                else if (Cont == 4)
                {
                    getObj.Password = Linea;
                }
                else if (Cont == 5)
                {
                    getObj.Puerto =  Convert.ToInt32(Linea);
                }
                Cont++;
            }
            txt.Close();
        }

    }
}

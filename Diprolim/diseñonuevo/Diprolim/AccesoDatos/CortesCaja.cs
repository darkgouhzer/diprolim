using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CortesCaja
    {
        UnicaSQL.DBMS_Unico objConexion;
        String cmd;
        public CortesCaja()
        {
            cmd = string.Empty;
            objConexion = new UnicaSQL.DBMS_Unico(Conexion.Default.GestorBD, Conexion.Default.Server,
                            Conexion.Default.BaseDatos, Conexion.Default.Usuario, Conexion.Default.Password,
                            Conexion.Default.Puerto);
        }



    }
}

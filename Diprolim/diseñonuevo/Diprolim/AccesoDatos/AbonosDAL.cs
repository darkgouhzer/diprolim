using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AbonosDAL
    {
        UnicaSQL.DBMS_Unico objConexion;
        String cmd;
        public AbonosDAL()
        {
            cmd = string.Empty;
            objConexion = new UnicaSQL.DBMS_Unico(Conexion.Default.GestorBD, Conexion.Default.Server,
                            Conexion.Default.BaseDatos, Conexion.Default.Usuario, Conexion.Default.Password,
                            Conexion.Default.Puerto);
        }

        public DataTable ConsultarAbonos()
        {
            DataTable dt = new DataTable();
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref dt);
            objConexion.Desconectarse();
            return dt;
        }

        public Boolean CancelarAbono()
        {
            Boolean bAllOK = false;
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd);
            objConexion.Desconectarse();
            return bAllOK;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DescuentosDAL
    {
        UnicaSQL.DBMS_Unico objConexion;
        String cmd;
        public DescuentosDAL()
        {
            cmd = string.Empty;
            objConexion = new UnicaSQL.DBMS_Unico(Conexion.Default.GestorBD, Conexion.Default.Server,
                            Conexion.Default.BaseDatos, Conexion.Default.Usuario, Conexion.Default.Password,
                            Conexion.Default.Puerto); 
        }
        public Boolean Guardar(DataTable dtDatos)
        {
            Boolean bAllOk = false;
            DataTable dtValidar;
            if (dtDatos.Rows.Count > 0)
            {
                objConexion.Conectarse();
                objConexion.IniciarTransaccion();
                foreach (DataRow row in dtDatos.Rows)
                {
                    dtValidar = new DataTable();
                    cmd = String.Format("SELECT idDescuentoComision AS contador FROM DescuentoComision " +
                        "WHERE idDescuentoComision = {0}", row["ID"]);
                    objConexion.Ejecutar(cmd, ref dtValidar);
                    if (dtValidar.Rows.Count > 0)
                    {
                        cmd = String.Format("UPDATE DescuentoComision SET Dias={0}, Porcentaje={1} " +
                            " WHERE idDescuentoComision = {2}",
                        row["Dias"].ToString(), row["Porcentaje"].ToString(), row["ID"].ToString());
                        objConexion.Ejecutar(cmd);
                    }
                    else
                    {
                        cmd = String.Format("INSERT INTO DescuentoComision(Dias, Porcentaje) " +
                                "VALUES({0}, {1}); ", row["Dias"].ToString(), row["Porcentaje"].ToString());
                        objConexion.Ejecutar(cmd);

                    }

                    bAllOk = true;
                }
                objConexion.FinTransaccion(bAllOk);
                objConexion.Desconectarse();
            }
            return bAllOk;

        }
    }
}

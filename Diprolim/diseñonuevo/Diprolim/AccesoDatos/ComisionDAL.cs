using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Identidades;
namespace AccesoDatos
{
    public class ComisionDAL
    {
        UnicaSQL.DBMS_Unico objConexion;
        String cmd;
        public ComisionDAL()
        {
            cmd = string.Empty;
            objConexion = new UnicaSQL.DBMS_Unico(Conexion.Default.GestorBD, Conexion.Default.Server,
                            Conexion.Default.BaseDatos, Conexion.Default.Usuario, Conexion.Default.Password,
                            Conexion.Default.Puerto);        
        }
        public DataTable ObtenerDescuentosComision()
        {
            DataTable objDataTable = new DataTable();
            cmd = String.Format("SELECT  idDescuentoComision, Dias, Porcentaje FROM DescuentoComision ORDER BY Dias ASC");
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref objDataTable);
            objConexion.Desconectarse();
            return objDataTable;
        }
        public CComision ObtenerPorcentajeDescuento(int iDias)
        {
            DataTable objDataTable = new DataTable();
            CComision objCComision = new CComision();
            cmd = String.Format("SELECT idDescuentoComision, Dias, Porcentaje FROM DescuentoComision WHERE Dias <= {0} ORDER BY Dias desc limit 1", iDias);
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref objDataTable);
            objConexion.Desconectarse();
            if (objDataTable.Rows.Count > 0)
            {
                DataRow row = objDataTable.Rows[0];
                objCComision.IdDescuentoComision = Convert.ToInt32(row["idDescuentoComision"]);
                objCComision.Dias = Convert.ToInt32(row["Dias"]);
                objCComision.Porcentaje = Convert.ToInt32(row["Porcentaje"]);
            }

            return objCComision;
        }
        public Double ObtenerPorcentajeComision(string sTipoComision, int IDCategoria)
        {
            DataTable objDataTable = new DataTable();
            Double dPorcentaje = 0;
            cmd = String.Format("SELECT {0} FROM categorias WHERE idcategorias = {1};", sTipoComision, IDCategoria);
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref objDataTable);
            objConexion.Desconectarse();
            if (objDataTable.Rows.Count > 0)
            {
                DataRow row = objDataTable.Rows[0];
                dPorcentaje = Convert.ToDouble(row[sTipoComision]);
            }

            return dPorcentaje;
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
                    cmd = String.Format("SELECT idDescuentoComision AS contador FROM DescuentoComision "+
                        "WHERE idDescuentoComision = {0}",row["ID"]);
                    objConexion.Ejecutar(cmd, ref dtValidar);
                    if (dtValidar.Rows.Count > 0)
                    {
                        cmd = String.Format("UPDATE DescuentoComision SET Dias={0}, Porcentaje={1} " +
                            " WHERE idDescuentoComision = {2}",
                        row["Dias"].ToString(),row["Porcentaje"].ToString(), row["ID"].ToString());
                        objConexion.Ejecutar(cmd);
                    }
                    else
                    {
                        cmd = String.Format("INSERT INTO DescuentoComision(Dias, Porcentaje) "+
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

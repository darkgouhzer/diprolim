using Identidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicaSQL;

namespace AccesoDatos
{
    public class ArticuloDAL
    {
       DBMS_Unico objConexion;
        String cmd;
        public ArticuloDAL()
        {
            cmd = string.Empty;
            objConexion = new DBMS_Unico(Conexion.Default.GestorBD, Conexion.Default.Server,
                            Conexion.Default.BaseDatos, Conexion.Default.Usuario, Conexion.Default.Password,
                            Conexion.Default.Puerto);
        }
        public CArticulos ObtenerDatosArticulo(int iArticulo)
        {
            CArticulos objCArticulos = new CArticulos();
            DataTable dtDatos = new DataTable();
            cmd = String.Format("SELECT a.codigo, a.descripcion, a.precioproduccion, a.cantidad, a.precio_calle, " +
                " a.precio_abarrotes, a.precio_distribuidor, a.departamento, a.Descuento, a.Comision, " +
                "a.aplicacomision, a.valor_medida, um.simbolo FROM articulos a inner JOIN unidad_medida um " +
                "ON um.id = a.unidad_medida_id WHERE codigo = {0};", iArticulo);
            objConexion.Conectarse();
            objConexion.Ejecutar(cmd, ref dtDatos);
            objConexion.Desconectarse();
            if (dtDatos.Rows.Count > 0)
            {
                DataRow row = dtDatos.Rows[0];
                objCArticulos.Codigo = Convert.ToInt32(row["codigo"]);
                objCArticulos.Descripcion = row["descripcion"].ToString();
                objCArticulos.PrecioProduccion = Convert.ToDouble(row["precioproduccion"]);
                objCArticulos.Cantidad = Convert.ToDouble(row["cantidad"]);
                objCArticulos.PrecioCalle = Convert.ToDouble(row["precio_calle"]);
                objCArticulos.PrecioAbarrotes = Convert.ToDouble(row["precio_abarrotes"]);
                objCArticulos.PrecioDistribuidor = Convert.ToDouble(row["precio_distribuidor"]);
                objCArticulos.Departamento = Convert.ToInt32(row["departamento"]);
                objCArticulos.Descuento = Convert.ToDouble(row["Descuento"]);
                objCArticulos.Comision = Convert.ToInt32(row["Comision"]);
                objCArticulos.AplicaComision = (short)Convert.ToInt32(row["aplicacomision"]);
                objCArticulos.ValorMedida = Convert.ToDouble(row["valor_medida"]);
                objCArticulos.UnidadMedida = row["simbolo"].ToString();
            }
            return objCArticulos;
        }

    }
}

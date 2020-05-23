using ConexionConfig;
using Entidades;
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
        GetConexion objGetConexion;
        String cmd;
        public ArticuloDAL()
        {
            cmd = string.Empty;
            objGetConexion = GetConexion.Instance;
            objConexion = new DBMS_Unico(objGetConexion.getObj.Gestor, objGetConexion.getObj.Servidor,
                            objGetConexion.getObj.BaseDeDatos, objGetConexion.getObj.Usuarios, objGetConexion.getObj.Password,
                            objGetConexion.getObj.Puerto);
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

        public Boolean AgregarFamilia(String sDescripcion)
        {
            Boolean bAllOk = false;

            if (sDescripcion.Length > 0)
            {
                objConexion.Conectarse();

                cmd = String.Format("call sp_agregarnuevafamilia('{0}');", sDescripcion);
                bAllOk = objConexion.Ejecutar(cmd);
                objConexion.Desconectarse();
            }
            return bAllOk;
        }

        public DataTable ObtenerFamilias()
        {
            DataTable tblFamilias = new DataTable();
         
            objConexion.Conectarse();
            cmd = String.Format("call sp_obtenerfamilias();");
            objConexion.Ejecutar(cmd, ref tblFamilias);
            objConexion.Desconectarse();
            return tblFamilias;
        }

        public Boolean EliminarFamilias(int[] aFamiliasID)
        {
            Boolean bAllOk = false;

            objConexion.Conectarse();
            objConexion.IniciarTransaccion();
            for (int i=0; i < aFamiliasID.Length; i++)
            {                
                cmd = String.Format("call sp_eliminarfamilia({0});", aFamiliasID[i]);
                bAllOk = objConexion.Ejecutar(cmd);
                if (!bAllOk)
                {
                    break;
                }                
            }
            objConexion.FinTransaccion(bAllOk);
            objConexion.Desconectarse();

            return bAllOk;
        }

        public Boolean actualizarFamilias(List<CFamilia> listFamilias)
        {
            Boolean bAllOk = false;

            objConexion.Conectarse();
            objConexion.IniciarTransaccion();
            for (int i = 0; i < listFamilias.Count; i++)
            {
                cmd = String.Format("call sp_actualizarFamilia({0},'{1}');", listFamilias[i].IDFamilia, listFamilias[i].Descripcion);
                bAllOk = objConexion.Ejecutar(cmd);
                if (!bAllOk)
                {
                    break;
                }
            }
            objConexion.FinTransaccion(bAllOk);
            objConexion.Desconectarse();

            return bAllOk;
        }

        public Boolean ValidarProductoProduccion(int codigoProducto)
        {
            Boolean bAllOk = false;
            DataTable dtProducto = new DataTable();
            objConexion.Conectarse();
          
            cmd = String.Format("call sp_validarProduccion({0});", codigoProducto);
            objConexion.Ejecutar(cmd, ref dtProducto);
            objConexion.Desconectarse();

            bAllOk = dtProducto.Rows.Count > 0 ? true : false;

            return bAllOk;
        }

        public Boolean ValidarTransfProduccion(int codigoProducto)
        {
            Boolean bAllOk = false;
            DataTable dtProducto = new DataTable();
            objConexion.Conectarse();

            cmd = String.Format("call sp_validarTransfProduccion({0});", codigoProducto);
            objConexion.Ejecutar(cmd, ref dtProducto);
            objConexion.Desconectarse();

            bAllOk = dtProducto.Rows.Count > 0 ? true : false;

            return bAllOk;
        }

        public Boolean AgregarDescripcionProducto(String sDescripcion)
        {
            Boolean bAllOk = false;

            if (sDescripcion.Length > 0)
            {
                objConexion.Conectarse();

                cmd = String.Format("call sp_agregarproductodescripcion('{0}');", sDescripcion);
                bAllOk = objConexion.Ejecutar(cmd);
                objConexion.Desconectarse();
            }
            return bAllOk;
        }

        public DataTable ObtenerDescripcionesProductos(String filtro)
        {
            DataTable tblDescripciones = new DataTable();

            objConexion.Conectarse();
            cmd = String.Format("call sp_obtenerdescripcionproductos('{0}');", filtro);
            objConexion.Ejecutar(cmd, ref tblDescripciones);
            objConexion.Desconectarse();
            return tblDescripciones;
        }

        public Boolean EliminarDescripcionProducto(int[] aFamiliasID)
        {
            Boolean bAllOk = false;

            objConexion.Conectarse();
            objConexion.IniciarTransaccion();
            for (int i = 0; i < aFamiliasID.Length; i++)
            {
                cmd = String.Format("call sp_eliminardescripcionProducto({0});", aFamiliasID[i]);
                bAllOk = objConexion.Ejecutar(cmd);
                if (!bAllOk)
                {
                    break;
                }
            }
            objConexion.FinTransaccion(bAllOk);
            objConexion.Desconectarse();

            return bAllOk;
        }

        public Boolean actualizarDescripcionProducto(List<CFamilia> listDescripciones)
        {
            Boolean bAllOk = false;

            objConexion.Conectarse();
            objConexion.IniciarTransaccion();
            for (int i = 0; i < listDescripciones.Count; i++)
            {
                cmd = String.Format("call sp_actualizarDescripcionProducto({0},'{1}');", listDescripciones[i].IDFamilia, listDescripciones[i].Descripcion);
                bAllOk = objConexion.Ejecutar(cmd);
                if (!bAllOk)
                {
                    break;
                }
            }
            objConexion.FinTransaccion(bAllOk);
            objConexion.Desconectarse();

            return bAllOk;
        }

        public DataTable ObtenerDescripcionesProductosById(int iDescripcionId)
        {
            DataTable tblDescripciones = new DataTable();

            objConexion.Conectarse();
            cmd = String.Format("call sp_obtenerDescripcionProdById('{0}');", iDescripcionId);
            objConexion.Ejecutar(cmd, ref tblDescripciones);
            objConexion.Desconectarse();
            return tblDescripciones;
        }
        
        public Double ObtenerExistenciasProduccion(int DescripcionID )
        {
            Double Cantidad = 0;
            DataTable tblCantidad = new DataTable();
            objConexion.Conectarse();
            cmd = String.Format("call sp_obtenerExistenciaProduccion('{0}');", DescripcionID);
            objConexion.Ejecutar(cmd, ref tblCantidad);
            objConexion.Desconectarse();

            if(tblCantidad.Rows.Count > 0)
            {
                DataRow row = tblCantidad.Rows[0];
                Cantidad = Convert.ToInt32(row["cantidad"]);
            }           

            return Cantidad;
        }

        public int ValidarExisteDescripcionAGranel(int DescripcionID, int UnidadMedidaID, int ValorMedida)
        {
            DataTable tblCantidad = new DataTable();
            objConexion.Conectarse();
            cmd = String.Format("call sp_validarExisteProductoAGranel('{0}','{1}', '{2}');", DescripcionID, UnidadMedidaID, ValorMedida);
            objConexion.Ejecutar(cmd, ref tblCantidad);
            objConexion.Desconectarse();
            return tblCantidad.Rows.Count;
        }

        public int ValidarExisteDescripcionProducto(String Descripcion, int DescripcionID)
        {
            DataTable tblCantidad = new DataTable();
            objConexion.Conectarse();
            cmd = String.Format("call sp_validarExisteDescripcion('{0}', {1});", Descripcion, DescripcionID);
            objConexion.Ejecutar(cmd, ref tblCantidad);
            objConexion.Desconectarse();
            return tblCantidad.Rows.Count;
        }

    }
}

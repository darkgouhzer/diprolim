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
    public class DescuentosDAL
    {
        DBMS_Unico objConexion;
        GetConexion objGetConexion;
        String cmd;
        public DescuentosDAL()
        {
            cmd = string.Empty;
            objGetConexion = GetConexion.Instance;
            objConexion = new DBMS_Unico(objGetConexion.getObj.Gestor, objGetConexion.getObj.Servidor,
                            objGetConexion.getObj.BaseDeDatos, objGetConexion.getObj.Usuarios, objGetConexion.getObj.Password,
                            objGetConexion.getObj.Puerto);   
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

        public Boolean GuardarDescuentoCustom(CDescuentoCustom objDescuentoCustom)
        {
            Boolean bAllOk = false;
            objConexion.Conectarse();
            cmd = String.Format("call sp_nuevacamapadescuento({0}, '{1}', {2}, '{3}', {4}, {5}, {6})", 
                                    objDescuentoCustom.CampanaID, objDescuentoCustom.NombreCampana, objDescuentoCustom.NoCompra, 
                                    objDescuentoCustom.Presentaciones, objDescuentoCustom.CantidadMinima, objDescuentoCustom.Porcentaje,
                                    objDescuentoCustom.Activa);
            bAllOk = objConexion.Ejecutar(cmd);
            objConexion.Desconectarse();
            return bAllOk;
        }

        public Boolean EliminarDescuentoCustom(int DescuentoID)
        {
            Boolean bAllOk = false;
            objConexion.Conectarse();
            cmd = String.Format("call sp_eliminarCampanaDescuentoCustom({0})", DescuentoID);
            bAllOk = objConexion.Ejecutar(cmd);
            objConexion.Desconectarse();
            return bAllOk;
        }

        // filtros Todas = 0 | Activas = 1 | Inactivas = 2
        public List<CDescuentoCustom> ObtenerTodosDescuentos(int filtro)
        {
            List<CDescuentoCustom> objListCDescuentosCustom = new List<CDescuentoCustom>();
            CDescuentoCustom objCDescuentoCustom = new CDescuentoCustom();
            DataTable dtRespuesta = new DataTable();

            objConexion.Conectarse();
            cmd = String.Format("call sp_obtenerTodasCampanasDescuento({0})", filtro);
            objConexion.Ejecutar(cmd, ref dtRespuesta);
            objConexion.Desconectarse();

            if (dtRespuesta.Rows.Count > 0)
            {
                foreach (DataRow row in dtRespuesta.Rows)
                {
                    objCDescuentoCustom = new CDescuentoCustom();
                    objCDescuentoCustom.CampanaID = Convert.ToInt32(row["iddescuentos_personalizados"]);
                    objCDescuentoCustom.NombreCampana = row["nombre_campana"].ToString();
                    objCDescuentoCustom.NoCompra = Convert.ToInt32(row["no_compra"]);
                    objCDescuentoCustom.Presentaciones = row["presentaciones"].ToString();
                    objCDescuentoCustom.CantidadMinima = Convert.ToInt32(row["cantidad_minima"]);
                    objCDescuentoCustom.Porcentaje = Convert.ToDouble(row["porcentaje"]);
                    objCDescuentoCustom.Activa  = Convert.ToBoolean(row["activa"]);
                    objCDescuentoCustom.CantidadAcumulada = 0;
                    objListCDescuentosCustom.Add(objCDescuentoCustom);
                }                
            }
            
            return objListCDescuentosCustom;
        }

        public CDescuentoCustom ObtenerDescuentoPorID(int CampanaID)
        {
            CDescuentoCustom objCDescuentoCustom = new CDescuentoCustom();
            DataTable dtRespuesta = new DataTable();

            objConexion.Conectarse();
            cmd = String.Format("call sp_obtenerCampanaDescuentoById({0})", CampanaID);
            objConexion.Ejecutar(cmd, ref dtRespuesta);
            objConexion.Desconectarse();

            if (dtRespuesta.Rows.Count > 0)
            {
                DataRow row = dtRespuesta.Rows[0];
                
                objCDescuentoCustom = new CDescuentoCustom();
                objCDescuentoCustom.CampanaID = Convert.ToInt32(row["iddescuentos_personalizados"]);
                objCDescuentoCustom.NombreCampana = row["nombre_campana"].ToString();
                objCDescuentoCustom.NoCompra = Convert.ToInt32(row["no_compra"]);
                objCDescuentoCustom.Presentaciones = row["presentaciones"].ToString();
                objCDescuentoCustom.CantidadMinima = Convert.ToInt32(row["cantidad_minima"]);
                objCDescuentoCustom.Porcentaje = Convert.ToDouble(row["porcentaje"]);
                objCDescuentoCustom.Activa = Convert.ToBoolean(row["activa"]);
                
            }

            return objCDescuentoCustom;
        }

        public List<CDescuentoCustom> ObtenerDescuentosACalcular(int nCompra, int iCantMin)
        {
            List < CDescuentoCustom > objListCDescuentosCustom = new List<CDescuentoCustom>();
            CDescuentoCustom objCDescuentoCustom = new CDescuentoCustom();
            DataTable dtRespuesta = new DataTable();

            objConexion.Conectarse();
            cmd = String.Format("call sp_obtenerDescuentosPersonalizados({0}, {1})", nCompra, iCantMin);
            objConexion.Ejecutar(cmd, ref dtRespuesta);
            objConexion.Desconectarse();

            if (dtRespuesta.Rows.Count > 0)
            {
                foreach (DataRow row in dtRespuesta.Rows)
                {
                    objCDescuentoCustom = new CDescuentoCustom();
                    objCDescuentoCustom.CampanaID = Convert.ToInt32(row["iddescuentos_personalizados"]);
                    objCDescuentoCustom.NombreCampana = row["nombre_campana"].ToString();
                    objCDescuentoCustom.NoCompra = Convert.ToInt32(row["no_compra"]);
                    objCDescuentoCustom.Presentaciones = row["presentaciones"].ToString();
                    objCDescuentoCustom.CantidadMinima = Convert.ToInt32(row["cantidad_minima"]);
                    objCDescuentoCustom.Porcentaje = Convert.ToDouble(row["porcentaje"]);
                    objCDescuentoCustom.Activa = Convert.ToBoolean(row["activa"]);
                    objListCDescuentosCustom.Add(objCDescuentoCustom);
                }
            }

            return objListCDescuentosCustom;
        }
    }
}

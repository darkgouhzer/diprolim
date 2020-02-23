using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;
namespace ReglasNegocios
{
    public class ComisionBO
    {
        ComisionDAL objComisionDAL;
        public ComisionBO()
        {
            objComisionDAL = new ComisionDAL();
        }
        public DataTable ObtenerDescuentosComision()
        {
            DataTable dtDatos = new DataTable();
            objComisionDAL = new ComisionDAL();
            dtDatos = objComisionDAL.ObtenerDescuentosComision();
            return dtDatos;
        }
        public Boolean Guardar(DataGridView dgDatos)
        {
            Boolean bAllOk = false;
            DataTable dtDatos = new DataTable();
            dtDatos.Columns.Add("ID", typeof(Int32));
            dtDatos.Columns.Add("Dias", typeof(Int32));
            dtDatos.Columns.Add("Porcentaje", typeof(Int32));

            foreach (DataGridViewRow rowGrid in dgDatos.Rows)
            {
                DataRow row = dtDatos.NewRow();
                row["ID"] = Convert.ToDouble(rowGrid.Cells[0].Value);
                row["Dias"] = Convert.ToDouble(rowGrid.Cells[1].Value);
                row["Porcentaje"] = Convert.ToDouble(rowGrid.Cells[2].Value);
                dtDatos.Rows.Add(row);
            }
            dtDatos.Rows.RemoveAt(dtDatos.Rows.Count-1);
            objComisionDAL = new ComisionDAL();
            bAllOk = objComisionDAL.Guardar(dtDatos);

            return bAllOk;
        }
        public Double ObtenerPorcentajeComision(string sTipoComision, int IDCategoria)
        {           
            Double dPorcentaje = 0;
            dPorcentaje = objComisionDAL.ObtenerPorcentajeComision(sTipoComision, IDCategoria);
            return dPorcentaje;
        }
        public Double CalcularComisionAbonos(int iDias, int iVendedor, Double dAbono, int iArticulo, int iCliente, int iFolioVenta)
        {
            objComisionDAL = new ComisionDAL();
            ArticuloBO objArticuloBO = new ArticuloBO();
            VentaDAL objVentaDAL =new VentaDAL();
            ClienteBO objClienteBO = new ClienteBO();
            EmpleadoBO objEmpleadoBO=new EmpleadoBO();
            CArticulos objCArticulos = new CArticulos();
            CClientes objCClientes = new CClientes();
            CEmpleados objCEmpleados=new CEmpleados();
            CComision objCComision = new CComision();
            Double dComision = 0, dPorcentajeComision = 0;
            objCComision = objComisionDAL.ObtenerPorcentajeDescuento(iDias);
            objCArticulos = objArticuloBO.ObtenerDatosArticulo(iArticulo);
            int IDCategoria=0;
            if (objCArticulos.Departamento == 1)
            {
                objCClientes = objClienteBO.ObtenerDatosCliente(iCliente);
                IDCategoria = objCClientes.IDcategorias;
            }
            else if (objCArticulos.Departamento == 2)
            {
                IDCategoria = 6;
            }
            else if (objCArticulos.Departamento == 3)
            {
                IDCategoria = 10;
            }

            objCEmpleados = objEmpleadoBO.ObtenerDatosVendedor(iVendedor);
            if (objCComision.Dias > 0 && objCComision.IdDescuentoComision > 0)
            {
                if (objVentaDAL.aplicaIVA(iFolioVenta))
                {
                    dComision = (dAbono / 1.16) * objCComision.Porcentaje / 100;
                }
                else
                {
                    dComision = dAbono * objCComision.Porcentaje / 100;
                }
            }
            else
            {
                dPorcentajeComision = ObtenerPorcentajeComision(objCEmpleados.TipoVendedor, IDCategoria);
                if (objVentaDAL.aplicaIVA(iFolioVenta))
                {
                    dComision = (dAbono / 1.16) * dPorcentajeComision / 100;
                }
                else
                {
                    dComision = dAbono * dPorcentajeComision / 100;
                }
            }
            return dComision;
        }
    }
}

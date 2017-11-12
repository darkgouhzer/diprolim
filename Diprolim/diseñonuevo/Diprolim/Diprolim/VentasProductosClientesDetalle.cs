using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diprolim
{
    public partial class VentasProductosClientesDetalle : Form
    {
        Inventarios.DBMS_Unico Conexion;   
        DateTimePicker Inicio;
        DateTimePicker Fin;
        string ID = "";
        public VentasProductosClientesDetalle(Inventarios.DBMS_Unico sConexion, string sID, DateTimePicker Inicio, DateTimePicker Fin)
        {
            InitializeComponent();
            this.Conexion = sConexion;
            this.Inicio =Inicio;
            this.Fin=Fin;
            this.ID = sID;
        }

        private void VentasProductosClientesDetalle_Load(object sender, EventArgs e)
        {
            GenerarVenta();
        }
        public void GenerarVenta()
        {
                DataTable Tabla = new DataTable();
                Conexion.Conectarse();
                string comando = "SELECT v.articulos_codigo,v.fecha_venta,c.nombre, a.descripcion,a.valor_medida,um.nombre, v.precio_art,v.cantidad, v.importe, v.comision " +
                "FROM ventas v,categorias c, articulos a, empleados e, unidad_medida um, clientes u WHERE v.categorias_idcategorias=c.idcategorias and v.articulos_codigo = a.codigo AND " +
                "v.empleados_id_empleado = e.id_empleado AND v.clientes_idclientes = u.idclientes AND a.unidad_medida_id=um.id AND v.clientes_idclientes=" + ID + " AND v.fecha_venta BETWEEN '" +
                Inicio.Value.ToString("yyyyMMdd000000") + "' AND '" + Fin.Value.ToString("yyyyMMdd235959") + "' ";
                Conexion.Ejecutar(comando, ref Tabla);
                Conexion.Desconectarse();
                double sumaTotal = 0;
                double totalComision = 0;
                if (Tabla.Rows.Count > 0)
                {
                    
                   
                    for(int i=0;i<Tabla.Rows.Count;i++)
                    {
                        DataRow row = Tabla.Rows[i];
                        DateTime fecha = Convert.ToDateTime(row["fecha_venta"].ToString());

                        tblReporteV.Rows.Add(row["articulos_codigo"].ToString(), fecha.ToString("dd/MM/yyyy"), row["descripcion"].ToString() + " " + row["valor_medida"].ToString(), Convert.ToDouble(row["precio_art"].ToString()),
                            Convert.ToDouble(row["cantidad"].ToString()), Convert.ToDouble(row["importe"].ToString()), Convert.ToDouble(row["comision"].ToString()));
                        sumaTotal += Convert.ToDouble(row["importe"].ToString());
                        totalComision += Convert.ToDouble(row["comision"].ToString());
                    }
                }
            tblReporteV.Rows.Add("", "", "", "",  "Total:", sumaTotal, totalComision);
        }
    }
}

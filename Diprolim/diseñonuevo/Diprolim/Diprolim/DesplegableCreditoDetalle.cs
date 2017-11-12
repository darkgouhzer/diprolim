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
    public partial class DesplegableCreditoDetalle : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        public String ClienteID;
        public String EstadoCredito;
        public String Dias;
        public string sFolio;
        public DesplegableCreditoDetalle(UnicaSQL.DBMS_Unico server)
        {
            InitializeComponent();
            Conexion = server;
            ClienteID = "";
            EstadoCredito = "";
            Dias = "";
            sFolio = "";
        }
        String cmd = "";
        private void DesplegableCreditoDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable tbl = new DataTable();
                Conexion.Conectarse();
                Conexion.Ejecutar("SELECT nombre FROM Clientes WHERE idclientes=" + ClienteID, ref tbl);
                if (tbl.Rows.Count > 0)
                {
                    DataRow row=tbl.Rows[0];
                    lblCliente.Text = "Cliente: " + row["nombre"].ToString();
                }
                tbl = new DataTable();
                cmd = "select v.folio,v.fecha_venta,a.descripcion,a.valor_medida,u.nombre,v.importe," +
                       "v.iva,v.pendiente from articulos a, ventas v, unidad_medida u where a.codigo=v.articulos_codigo and " +
                       " u.id=a.unidad_medida_id and tipo_compra='credito'  and v.folio=" + sFolio + EstadoCredito +
                       " order by v.folio asc";
                Conexion.Ejecutar(cmd, ref tbl);
                Conexion.Desconectarse();
                double credito=0;
                double abono=0;
                if (tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        DataRow row = tbl.Rows[i];
                        TimeSpan ts;
                        ts = DateTime.Now.AddDays(1) - Convert.ToDateTime(row["fecha_venta"]);

                        credito=Convert.ToDouble(row["importe"]);
                        abono=credito-Convert.ToDouble(row["pendiente"]);
                        dtgCrTabla.Rows.Add(Convert.ToInt32(row["folio"]), Convert.ToDateTime(row["fecha_venta"]).ToString("dd/MM/yyyy"),
                            row["descripcion"].ToString() + " " + row["valor_medida"].ToString() + " " + row["nombre"].ToString(),
                            credito, abono, Convert.ToDouble(row["pendiente"]),ts.Days);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

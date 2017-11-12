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
    public partial class FolioSalidas : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        public string ID = "";
        public FolioSalidas(UnicaSQL.DBMS_Unico sConexion)
        {
            InitializeComponent();
            Conexion = sConexion;
        }

        private void FolioSalidas_Load(object sender, EventArgs e)
        {
            DataTable Tabla = new DataTable();
            string Comando = "";
            Comando = "SELECT s.folio,e.nombre,e.apellido_paterno,e.apellido_materno,s.fecha FROM salidas s, empleados e WHERE s.motivo='Normal'  AND s.empleados_id_empleado=e.id_empleado GROUP BY s.folio ";

            Conexion.Conectarse();
            Conexion.Ejecutar(Comando, ref Tabla);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count;i++ )
                {
                    if (Tabla.Rows[i][0].ToString() != "null" && Tabla.Rows[i][0].ToString() != "")
                    {
                        dtgFolios.Rows.Add(Tabla.Rows[i][0].ToString(), Tabla.Rows[i][1].ToString() + " " + Tabla.Rows[i][2].ToString() + " " + Tabla.Rows[i][3].ToString(), Convert.ToDateTime(Tabla.Rows[i][4]).ToString("dd/MM/yyyy"));
                    }
                }
                    
            }
            Conexion.Desconectarse();
          

            DataTable Tabla2 = new DataTable();
            string Comando2 = "";
            Comando2 = "SELECT s.folio,e.nombre,e.apellido_paterno,e.apellido_materno,s.fecha FROM salidas s, empleados e WHERE s.motivo='Entrada a vendedor'   AND s.empleados_id_empleado=e.id_empleado GROUP BY s.folio ";

            Conexion.Conectarse();
            Conexion.Ejecutar(Comando2, ref Tabla2);
            if (Tabla2.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla2.Rows.Count; i++)
                {
                    if (Tabla2.Rows[i][0].ToString() != "null" && Tabla2.Rows[i][0].ToString() != "")
                    {
                        dtgFolios.Rows.Add(Tabla2.Rows[i][0].ToString(), Tabla2.Rows[i][1].ToString() + " " + Tabla2.Rows[i][2].ToString() + " " + Tabla2.Rows[i][3].ToString(), Convert.ToDateTime(Tabla2.Rows[i][4]).ToString("dd/MM/yyyy"));
                    }
                }

            }
            Conexion.Desconectarse();
        }

        private void dtgFolios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID = dtgFolios.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.Close();
            }
            catch { }
        }

        private void tbxNombre_TextChanged(object sender, EventArgs e)
        {
            dtgFolios.Rows.Clear();
            DataTable Tabla = new DataTable();
            string Comando = "";
            Comando = "SELECT s.folio,e.nombre,e.apellido_paterno,e.apellido_materno,s.fecha FROM salidas s, empleados e WHERE s.motivo='Normal'  AND e.nombre LIKE '%" + tbxNombre.Text + "%' AND s.empleados_id_empleado=e.id_empleado GROUP BY s.folio ";

            Conexion.Conectarse();
            Conexion.Ejecutar(Comando, ref Tabla);
            if (Tabla.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla.Rows.Count; i++)
                {
                    if (Tabla.Rows[i][0].ToString() != "null" && Tabla.Rows[i][0].ToString() != "")
                    {
                        dtgFolios.Rows.Add(Tabla.Rows[i][0].ToString(), Tabla.Rows[i][1].ToString() + " " + Tabla.Rows[i][2].ToString() + " " + Tabla.Rows[i][3].ToString(), Convert.ToDateTime(Tabla.Rows[i][4]).ToString("dd/MM/yyyy"));
                    }
                }

            }
            Conexion.Desconectarse();

            DataTable Tabla2 = new DataTable();
            string Comando2 = "";
            Comando2 = "SELECT s.folio,e.nombre,e.apellido_paterno,e.apellido_materno,s.fecha FROM salidas s, empleados e WHERE s.motivo='Entrada a vendedor'  AND e.nombre LIKE '%" + tbxNombre.Text + "%' AND s.empleados_id_empleado=e.id_empleado GROUP BY s.folio ";

            Conexion.Conectarse();
            Conexion.Ejecutar(Comando2, ref Tabla2);
            if (Tabla2.Rows.Count > 0)
            {
                for (int i = 0; i < Tabla2.Rows.Count; i++)
                {
                    if (Tabla2.Rows[i][0].ToString() != "null" && Tabla2.Rows[i][0].ToString() != "")
                    {
                        dtgFolios.Rows.Add(Tabla2.Rows[i][0].ToString(), Tabla2.Rows[i][1].ToString() + " " + Tabla2.Rows[i][2].ToString() + " " + Tabla2.Rows[i][3].ToString(), Convert.ToDateTime(Tabla2.Rows[i][4]).ToString("dd/MM/yyyy"));
                    }
                }

            }
            Conexion.Desconectarse();
        }
    }
}

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
    public partial class Rutas : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        public Rutas(UnicaSQL.DBMS_Unico svr)
        {
            InitializeComponent();
            Conexion = svr;
            cbxRutas.SelectedIndex = 0;
        }
        public void Ruta()
        {
            try
            {
                Conexion.Conectarse();
                DataTable tabla = new DataTable();
                string comando = "SELECT idRuta, Ruta FROM Rutas";
                Conexion.Ejecutar(comando, ref tabla);
                Conexion.Desconectarse();
                cbxRutas.DataSource = tabla;
                cbxRutas.DisplayMember = "Ruta";
                cbxRutas.ValueMember = "idRuta";
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void RefrescarTabla()
        {
            tblRutas.Rows.Clear();
            Conexion.Conectarse();
            DataTable tabla = new DataTable();
            Conexion.Ejecutar("SELECT idLocalidades, Localidad FROM Localidades  WHERE Rutas_IdRuta='" + cbxRutas.SelectedValue + "' ", ref tabla);
            if(tabla.Rows.Count>0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    DataRow fila = tabla.Rows[i];
                    tblRutas.Rows.Add(false, fila[1].ToString(), fila[0].ToString());
                }
            }
            Conexion.Desconectarse();
        }
        private void Rutas_Load(object sender, EventArgs e)
        {
            Ruta();
            RefrescarTabla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Conexion.Conectarse();
            Conexion.Ejecutar("INSERT INTO Localidades (Localidad,Rutas_IdRuta) values('" + tbxRuta.Text + "',"+cbxRutas.SelectedValue+")");
            Conexion.Desconectarse();
            tbxRuta.Text = "";
            RefrescarTabla();
        }

        private void cbxRutas_SelectedIndexChanged(object sender, EventArgs e)
        {
             RefrescarTabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            List<String> list2 = new List<string>();
            foreach (DataGridViewRow row in tblRutas.Rows)
            {
                DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(celdaseleccionada.Value))
                {
                    list.Add(row);

                    String Comando = string.Format("DELETE FROM Localidades WHERE idLocalidades={0} ", row.Cells[2].Value.ToString());
                    Conexion.Conectarse();
                    Conexion.Ejecutar(Comando);
                    Conexion.Desconectarse();

                }
            }


            foreach (DataGridViewRow row in list)
            {
                tblRutas.Rows.Remove(row);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Diprolim
{
    public partial class nuevaUnidadMedida : Form
    {
        conexion conn = new conexion();
        public nuevaUnidadMedida()
        {
            InitializeComponent();
        }

        public void refrescarTabla()
        {
            tblMedidas.Rows.Clear();
            MySqlConnection conectar = conn.ObtenerConexion();
            MySqlCommand comando = new MySqlCommand("Select * from unidad_medida", conectar);
            MySqlDataReader lector;
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                tblMedidas.Rows.Add(false, lector.GetString(0), lector.GetString(1), lector.GetString(2));
            }
            conectar.Close();
        }
        private void nuevaUnidadMedida_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'diprolimDataSet.articulos' table. You can move, or remove it, as needed.
            refrescarTabla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbxNombre.Text.Length > 0 && tbxSimbolo.Text.Length > 0)
            {
                MySqlConnection conectar = conn.ObtenerConexion();
                MySqlCommand comando = new MySqlCommand("INSERT INTO unidad_medida values(null,'"+tbxNombre.Text+"','"+tbxSimbolo.Text+"')", conectar);
                try
                {
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    refrescarTabla();
                }
                catch (MySqlException err)
                {
                    MessageBox.Show(err + " No se pudo agregar la unidad de medida");
                }
            }
            else
            {
                MessageBox.Show("Los campos Nombre y Simbolo son obligatorios");
            }
        }
        DialogResult result;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Sé eliminarán las unidades de medida marcadas, ¿desea continuar?", "Eliminación de unidad de medida", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                List<DataGridViewRow> list = new List<DataGridViewRow>();
                List<String> list2 = new List<string>();
                foreach (DataGridViewRow row in tblMedidas.Rows)
                {
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                    {
                        list.Add(row);
                        MySqlConnection conectar = conn.ObtenerConexion();
                        MySqlCommand comando = new MySqlCommand("delete from unidad_medida where id='" + row.Cells[1].Value.ToString() + "'", conectar);
                        try
                        {
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();
                        }
                        catch (MySqlException err)
                        {
                            MessageBox.Show(err + " La unidad de medida no pudo ser eliminada");
                        }
                    }
                }

                foreach (DataGridViewRow row in list)
                {
                    tblMedidas.Rows.Remove(row);
                }
                refrescarTabla();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Sé actulizarán datos de filas marcadas, ¿desea continuar?", "Actualización de unidad de medida", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                List<DataGridViewRow> list = new List<DataGridViewRow>();
                List<String> list2 = new List<string>();
                foreach (DataGridViewRow row in tblMedidas.Rows)
                {
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                    {
                        list.Add(row);
                        MySqlConnection conectar = conn.ObtenerConexion();
                        MySqlCommand comando = new MySqlCommand("update unidad_medida set nombre='" + row.Cells[2].Value.ToString() + "' , simbolo='" + row.Cells[3].Value.ToString() + "' where id='" + row.Cells[1].Value.ToString() + "'", conectar);
                        try
                        {
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();
                        }
                        catch (MySqlException err)
                        {
                            MessageBox.Show(err + " La unidad de medida no pudo ser actualizada");
                        }
                        
                    }
                }
            }
            refrescarTabla();
        }

      
    }
}

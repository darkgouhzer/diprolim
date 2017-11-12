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
    public partial class comisiones : Form
    {
        conexion conn = new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        MySqlDataAdapter adaptador;
        public comisiones()
        {
            InitializeComponent();
            rellenarComisiones();
        }

        public void rellenarComisiones()
        {
            try
            {
                string columnas = "";
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select * from categorias", conectar);
                adaptador = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                int ancho = 0;
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    if (ds.Tables[0].Columns[i].ColumnName != "clase")
                    {
                        DataGridViewTextBoxColumn tbxcol = new DataGridViewTextBoxColumn();
                        tbxcol.HeaderText = ds.Tables[0].Columns[i].ColumnName;
                        columnas += ds.Tables[0].Columns[i].ColumnName + ",";
                        if (this.Size.Width < 1000)
                        {
                            ancho += 100;
                            tblComisiones.SetBounds(15, 30, ancho, 140);
                            this.Size = new Size(ancho + 50, 268);
                        }
                    }
                }

                comando = new MySqlCommand("select " + columnas.Substring(0, columnas.Length - 1) + " from categorias", conectar);
                adaptador = new MySqlDataAdapter(comando);
                DataTable table = new DataTable();
                adaptador.Fill(table);
                BindingSource binding = new BindingSource();
                binding.DataSource = table;
                tblComisiones.DataSource = binding;

                // Put the cells in edit mode when user enters them.
                tblComisiones.EditMode = DataGridViewEditMode.EditOnEnter;
                tblComisiones.Columns[0].ReadOnly = true;
                tblComisiones.Columns[0].Visible = false;
                tblComisiones.Columns[1].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGuarda_Click(object sender, EventArgs e)
        {
            try
            {
                conectar = conn.ObtenerConexion();
                for (int i = 0; i < tblComisiones.Rows.Count; i++)
                { 
                    string columnas = "";
                    for (int j = 2; j < tblComisiones.Columns.Count; j++)
                    {
                        columnas += tblComisiones.Columns[j].Name + "=" + tblComisiones[j, i].Value.ToString()+",";
                    }
                    comando = new MySqlCommand("update categorias set " + columnas.Substring(0,columnas.Length-1) + " where idcategorias=" + tblComisiones[0, i].Value.ToString(), conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                }
                MessageBox.Show("Cambios guardados con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

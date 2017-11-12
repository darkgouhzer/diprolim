using MySql.Data.MySqlClient;
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
    public partial class Puestos : Form
    {
        conexion conn=new conexion();
        MySqlConnection conectar;
        MySqlCommand comando;
        MySqlDataReader lector;
        MySqlDataAdapter adaptador;
        public Puestos()
        {
            InitializeComponent();
            refrescarTabla();
        }

        public void refrescarTabla()
        {
            try
            {
                tblPuestos.Rows.Clear();
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("select * from Puestos", conectar);
                conectar.Open();
                lector = comando.ExecuteReader();
                int cont = 0;
                while (lector.Read())
                {
                    if (lector.GetString(1) == "Vendedor" || lector.GetString(1) == "Gerente")
                    {
                        tblPuestos.Rows.Add(false, lector.GetString(0), lector.GetString(1), lector.GetBoolean(2));
                        tblPuestos[0, cont].ReadOnly = true;
                        tblPuestos[3, cont].ReadOnly = true;
                    }
                    else
                    {
                        tblPuestos.Rows.Add(false, lector.GetString(0), lector.GetString(1), lector.GetBoolean(2));
                    }
                    if (lector.GetBoolean(2))
                    {
                        agregarColComision(lector.GetString(1));
                    }
                    else
                    {
                        eliminarColComision(lector.GetString(1));
                    }
                    cont++;
                }
                conectar.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void agregarColComision(string columna)
        {
            try
            {
                if (!verificarColComision(columna))
                {
                    conectar = conn.ObtenerConexion();
                    comando = new MySqlCommand("ALTER TABLE categorias ADD COLUMN " + columna + " DOUBLE NOT NULL DEFAULT 0", conectar);
                    conectar.Open();
                    comando.ExecuteNonQuery();
                    conectar.Close();
                    refrescarTabla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Boolean verificarColComision(string columna)
        {
            Boolean existe = false;
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select * from categorias", conectar);
                adaptador = new MySqlDataAdapter(comando);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    if (ds.Tables[0].Columns[i].ColumnName == columna)
                    {
                        existe = true;
                    }
                }                
                return existe;            
        }
        public void eliminarColComision(string columna)
        {
            if (verificarColComision(columna))
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("ALTER TABLE categorias drop COLUMN " + columna, conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();
            }
           
        }
        public Boolean existePuesto(string columna)
        {
            Boolean existe = false;
            conectar = conn.ObtenerConexion();
            comando = new MySqlCommand("select nombre from Puestos", conectar);
            conectar.Open();
            lector = comando.ExecuteReader();
            while (lector.Read())
            {
                if (columna == lector.GetString(0))
                {
                    existe = true;
                }
            }
            conectar.Close();
            return existe;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                conectar = conn.ObtenerConexion();
                comando = new MySqlCommand("insert into Puestos values(null,'"+tbxNombreP.Text+"',"+Convert.ToInt32(chkComision.Checked)+")",conectar);
                conectar.Open();
                comando.ExecuteNonQuery();
                conectar.Close();
                if (chkComision.Checked)
                {
                    agregarColComision(tbxNombreP.Text);
                }
                refrescarTabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        DialogResult result;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                result = MessageBox.Show("Sé eliminarán puestos marcados, ¿desea continuar?", "Eliminación de puestos", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    List<DataGridViewRow> list = new List<DataGridViewRow>();
                    List<String> list2 = new List<string>();
                    foreach (DataGridViewRow row in tblPuestos.Rows)
                    {
                        DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                        if (Convert.ToBoolean(celdaseleccionada.Value))
                        {
                            list.Add(row);
                            conectar = conn.ObtenerConexion();
                            comando = new MySqlCommand("delete from Puestos where idPuestos='" + row.Cells[1].Value.ToString() + "'", conectar);
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();
                            if (verificarColComision(row.Cells[2].Value.ToString()) && !existePuesto(row.Cells[2].Value.ToString()))
                            {
                                eliminarColComision(row.Cells[2].Value.ToString());
                            }               
                        }
                    }

                    foreach (DataGridViewRow row in list)
                    {
                        tblPuestos.Rows.Remove(row);
                    }
                    refrescarTabla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            result = MessageBox.Show("Sé actulizarán datos de filas marcadas, ¿desea continuar?", "Actualización de puestos", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                List<DataGridViewRow> list = new List<DataGridViewRow>();
                List<String> list2 = new List<string>();
                foreach (DataGridViewRow row in tblPuestos.Rows)
                {
                    DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                    if (Convert.ToBoolean(celdaseleccionada.Value))
                    {
                        list.Add(row);

                        conectar = conn.ObtenerConexion();
                        comando = new MySqlCommand("update puestos  set nombre='" + row.Cells[2].Value.ToString() + "' , aplicacomision='" + Convert.ToInt32(row.Cells[3].Value) + "' where idPuestos='" + row.Cells[1].Value.ToString() + "'", conectar);
                        try
                        {
                            conectar.Open();
                            comando.ExecuteNonQuery();
                            conectar.Close();
                        }
                        catch (MySqlException err)
                        {
                            MessageBox.Show(err.Message);
                        }

                    }
                }
            }
            refrescarTabla();
        }
    }
}

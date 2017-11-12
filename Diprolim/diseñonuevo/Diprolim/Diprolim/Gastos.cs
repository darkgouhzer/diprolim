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
    public partial class Gastos : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        public Gastos(UnicaSQL.DBMS_Unico sConexion)
        {
            InitializeComponent();
            Conexion = sConexion;
            dtpFecha.Value = DateTime.Now;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxNombreP.Text != ""&& tbxCantidad.Text!="")
                {
                    string Comentarios = "";
                    Comentarios = tbxComentarios.Text;
                    DataTable Tabla = new DataTable();
                    Conexion.Conectarse();
                    string Comando = String.Format("Select Nombre FROM Gastos WHERE Nombre like '%{0}%'" , tbxNombreP.Text);
                    Conexion.Ejecutar(Comando,ref Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                            dtgGastos.Rows.Add(true, tbxNombreP.Text, Convert.ToDouble(tbxCantidad.Text), Comentarios, IDGasto(tbxNombreP.Text));
                            Guardar();
                    }
                    else
                    {
                        Comando = String.Format("INSERT INTO Gastos VALUES(null,'{0}')", tbxNombreP.Text);
                        if (Conexion.Ejecutar(Comando))
                        {

                            dtgGastos.Rows.Add(true, tbxNombreP.Text, Convert.ToDouble(tbxCantidad.Text), Comentarios, IDGasto(tbxNombreP.Text));
                            Guardar();
                            AutoCompletar();
                        }
                    }
                        Conexion.Desconectarse();
                    
                    tbxNombreP.Clear();
                    tbxCantidad.Clear();
                    tbxComentarios.Clear();
                }
                label1.Text = "Gastos:";
                tbxNombreP.Focus();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        public Int32 IDGasto(String Nombre)
        {
            DataTable Tabla = new DataTable();
            string Comando = String.Format("Select IdGastos FROM Gastos "+
                                           "WHERE Nombre='{0}' ", Nombre);
            Conexion.Ejecutar(Comando, ref Tabla);
           
            return Convert.ToInt32(Tabla.Rows[0][0].ToString());
        }
    
        public void Guardar()
        {
            try
            {
                string Comentarios = "";
                Comentarios = tbxComentarios.Text;
                    String Comando = string.Format("INSERT INTO MovimientosGastos (Gastos_idGastos,Fecha,Importe,Comentarios) " +
                                                      "VALUES  ({0},'{1}',{2},'{3}')", IDGasto(tbxNombreP.Text), dtpFecha.Value.ToString("yyyyMMdd"), Convert.ToDouble(tbxCantidad.Text), Comentarios);
                    Conexion.Ejecutar(Comando);
            }
            catch (Exception ex)
            {
                
            }
        }
            
        
        public void refrescarTabla()
        {
            try
            {
                if(dtgGastos.Rows.Count>0)
                {
                    dtgGastos.Rows.Clear();
                }
                    DataTable Tabla = new DataTable();
                       String Comando = String.Format("SELECT a.idGastos,a.Nombre,b.Importe,b.Comentarios FROM Gastos a, MovimientosGastos b " +
                                                "WHERE b.Fecha BETWEEN '{0}' AND '{1}' AND b.Gastos_IdGastos=a.IdGastos ", dtpFecha.Value.ToString("yyyyMMdd"),
                                                                                      dtpFecha.Value.ToString("yyyyMMdd"));
                        Conexion.Conectarse();
                        Conexion.Ejecutar(Comando, ref Tabla);
                        if (Tabla.Rows.Count > 0)
                        {
                            for (int j = 0; j < Tabla.Rows.Count; j++)
                            {
                                dtgGastos.Rows.Add(false,Tabla.Rows[j][1].ToString(),Convert.ToDouble(Tabla.Rows[j][2]),Tabla.Rows[j][3].ToString(),Tabla.Rows[j][0].ToString());
                                
                            }
                            
                        }
                        Conexion.Desconectarse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        DialogResult result;
       
        private void dtgGastos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int n = 0;
            try
            {
                
                n = 0;
                if (dtgGastos.Rows.Count > 0)
                {

                    for (int i = 0; i < dtgGastos[2, e.RowIndex].Value.ToString().Length; i++)
                    {
                        if (dtgGastos[2, e.RowIndex].Value.ToString().Substring(i, 1) == ".")
                        {
                            n++;
                        }

                    }
                    if (n < 2)
                    {
                        dtgGastos[2, e.RowIndex].Value = Convert.ToDouble(dtgGastos[2, e.RowIndex].Value);
                        if (dtgGastos[2, e.RowIndex].Value.ToString().Equals("."))
                        {
                            dtgGastos[2, e.RowIndex].Value = Convert.ToDouble(0.00);
                        }



                    }
                    else
                    {
                        MessageBox.Show("Solo puede agregar 1 punto decimal");
                        dtgGastos[2, e.RowIndex].Value = Convert.ToDouble(0.00);
                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void dtgGastos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dtgGastos.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void dtgGastos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dtgGastos.CurrentCell.ColumnIndex == 2)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
                {

                    e.Handled = true;

                }
            }
        }

        private void dtgGastos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dtgGastos_KeyPress);
        }

        private void tbxNombreP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxNombreP.Text != "")
                {
                    label1.Text = "Importe:";
                    tbxCantidad.Focus();
                }
            }
        }

        private void tbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (tbxCantidad.Text != "")
                {
                    label1.Text = "Comentarios:";
                    tbxComentarios.Focus();
                }
            }
        }

        private void tbxNombreP_Click(object sender, EventArgs e)
        {
            label1.Text = "Gastos:";
        }

        private void tbxCantidad_Click(object sender, EventArgs e)
        {
            label1.Text = "Importe:";
        }

        private void tbxComentarios_Click(object sender, EventArgs e)
        {
            label1.Text = "Comentarios:";
        }

        private void Gastos_Load(object sender, EventArgs e)
        {
            Conexion.Conectarse();
            AutoCompletar();
            Conexion.Desconectarse();
        }
        void AutoCompletar()
        {
            tbxNombreP.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbxNombreP.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

            DataTable tabla = new DataTable();
            
            string Comando = "";
            string Datos = "";
            Comando = string.Format("SELECT Nombre FROM Gastos " +
                                    "WHERE Nombre like '%{0}%'", tbxNombreP.Text);
            Conexion.Ejecutar(Comando, ref tabla);
            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    Datos = tabla.Rows[i][0].ToString();
                    coll.Add(Datos);
                }
            }
            tbxNombreP.AutoCompleteCustomSource = coll;
        }

        private void tbxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46 && tbxCantidad.Text.IndexOf('.') != -1)
            {

                e.Handled = true;
                return;

            }

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != 46)
            {

                e.Handled = true;

            }
        }

        private void Gastos_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbxNombreP.Focused)
            {
                label1.Text = "Gastos:";
            }
            else if (tbxCantidad.Focused)
            {
                label1.Text = "Importe:";
            }
            else 
            {
                label1.Text = "Comentarios:";
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                refrescarTabla();   
            }
            else
            {
                dtgGastos.Rows.Clear();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> list = new List<DataGridViewRow>();
            List<String> list2 = new List<string>();
            foreach (DataGridViewRow row in dtgGastos.Rows)
            {
                DataGridViewCheckBoxCell celdaseleccionada = row.Cells[0] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(celdaseleccionada.Value))
                {
                    list.Add(row);

                    String Comando = string.Format("DELETE FROM MovimientosGastos WHERE Gastos_IdGastos={0} AND Fecha='{1}' AND Importe={2} AND Comentarios='{3}' ", row.Cells[4].Value.ToString(), dtpFecha.Value.ToString("yyyyMMdd"), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString());
                    Conexion.Conectarse();
                    Conexion.Ejecutar(Comando);
                    Conexion.Desconectarse();

                }
            }


            foreach (DataGridViewRow row in list)
            {
                dtgGastos.Rows.Remove(row);
            }
        }


    }
}

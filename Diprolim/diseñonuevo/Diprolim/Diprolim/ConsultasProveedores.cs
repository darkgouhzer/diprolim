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
    public partial class ConsultasProveedores : Form
    {
        Inventarios.DBMS_Unico Conexion;
        public ConsultasProveedores(Inventarios.DBMS_Unico sConexion)
        {
            InitializeComponent();
            Conexion = sConexion;
            Buscar();
        }
        public void Buscar()
        {
            DataTable tabla = new DataTable();
            Conexion.Conectarse();
            string Comando ="SELECT * FROM Proveedores";
            Conexion.Ejecutar(Comando,ref tabla);
            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dtgProveedores.Rows.Add(tabla.Rows[i][0].ToString(), tabla.Rows[i][1].ToString(),tabla.Rows[i][3].ToString(),tabla.Rows[i][4].ToString());
                }
            }
            Conexion.Desconectarse();
        }

        private void tbxFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            dtgProveedores.Rows.Clear();
            DataTable tabla = new DataTable();
            Conexion.Conectarse();
            string Comando = string.Format("SELECT * FROM Proveedores "+
                                           "WHERE NombreComercial LIKE '%{0}%' ",tbxFiltro.Text) ;
            Conexion.Ejecutar(Comando, ref tabla);
            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    dtgProveedores.Rows.Add(tabla.Rows[i][0].ToString(), tabla.Rows[i][1].ToString(), tabla.Rows[i][3].ToString(), tabla.Rows[i][4].ToString());
                }
            }
            Conexion.Desconectarse();
        }
    }
}

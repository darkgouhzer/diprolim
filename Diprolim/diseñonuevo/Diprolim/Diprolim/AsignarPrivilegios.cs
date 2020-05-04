using System;
using System.Data;
using System.Windows.Forms;

namespace Diprolim
{
    public partial class AsignarPrivilegios : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        public AsignarPrivilegios(UnicaSQL.DBMS_Unico sConexion)
        {
            InitializeComponent();
            Conexion = sConexion;
        }

        private void btnSV_Click(object sender, EventArgs e)
        {
            BuscarUsuarios id = new BuscarUsuarios();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                tbxCodigo.Text = id.regresar.valXn;
            }
            tbxCodigo.Focus();
            ObtenerUsuario();
        }

        public void ObtenerUsuario()
        {
            if (tbxCodigo.Text != "")
            {
               DataTable Tabla=new DataTable();
               string comando ="SELECT * FROM usuarios WHERE id_usuarios=" + tbxCodigo.Text;
                Conexion.Conectarse();
                Conexion.Ejecutar(comando,ref Tabla);
                if(Tabla.Rows.Count>0)
                {
                    DataRow row = Tabla.Rows[0];
                    tbxNUsuario.Text = row["Nombre"].ToString();
                }
                Conexion.Desconectarse();
            }
            else
            {
                MessageBox.Show("Inserte código");
            }
        }
        
        private void tbxCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbxCodigo.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                  
                        ObtenerUsuario();
                        LLenarPrivilegios();
                    
                }
            }
        }

        private void btnCambiarVendedor_Click(object sender, EventArgs e)
        {
            tbxCodigo.Clear();
            tbxNUsuario.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            if (tbxCodigo.Text != "" && tbxNUsuario.Text != "")
            {
                string[] C1 = new string[41];
               //Ventas
                if (cheVentasSucursal.Checked == true) { C1[0] = "1"; } else { C1[0] = "0"; }
                if (cheSalidasVendedores.Checked == true) { C1[1] = "1"; } else { C1[1] = "0"; }
                if (chePedidosEspeciales.Checked == true) { C1[2] = "1"; } else { C1[2] = "0"; }
                if (cheConsignacion.Checked == true) { C1[3] = "1"; } else { C1[3] = "0"; }
                if (cheEntradasVendedores.Checked == true) { C1[4] = "1"; } else { C1[4] = "0"; }
                if (cheCorteDeCaja.Checked == true) { C1[5] = "1"; } else { C1[5] = "0"; }
                //Inventarios
                if (cheEntradasInventario.Checked == true) { C1[6] = "1"; } else { C1[6] = "0"; }
                if (cheConversiones.Checked == true) { C1[7] = "1"; } else { C1[7] = "0"; }
                if (cheInventarioCosto.Checked == true) { C1[8] = "1"; } else { C1[8] = "0"; }
                if (cheInventarioNormal.Checked == true) { C1[9] = "1"; } else { C1[9] = "0"; }
                if (cheSalidasEspeciales.Checked == true) { C1[10] = "1"; } else { C1[10] = "0"; }
               //Catalogos
                if (cheVendedores.Checked == true) { C1[11] = "1"; } else { C1[11] = "0"; }
                if (cheClientes.Checked == true) { C1[12] = "1"; } else { C1[12] = "0"; }
                if (cheProductos.Checked == true) { C1[13] = "1"; } else { C1[13] = "0"; }
                if (cheConsultasProductos.Checked == true) { C1[14] = "1"; } else { C1[14] = "0"; }
                if (cheUnidadesDeMedida.Checked == true) { C1[15] = "1"; } else { C1[15] = "0"; }
                if (cheAlmacenes.Checked == true) { C1[16] = "1"; } else { C1[16] = "0"; }
                if (cheComisiones.Checked == true) { C1[17] = "1"; } else { C1[17] = "0"; }
                if (cheRutas.Checked == true) { C1[18] = "1"; } else { C1[18] = "0"; }
              //Reportes
                if (cheVenrasReporte.Checked == true) { C1[19] = "1"; } else { C1[19] = "0"; }
                if (cheVentasCosto.Checked == true) { C1[20] = "1"; } else { C1[20] = "0"; }
                if (cheVentasGenerales.Checked == true) { C1[21] = "1"; } else { C1[21] = "0"; }
                if (cheEntradasInventarioR.Checked == true) { C1[22] = "1"; } else { C1[22] = "0"; }
                if (cheSalidasInventarioR.Checked == true) { C1[23] = "1"; } else { C1[23] = "0"; }
                if (cheEntradasVendedoresR.Checked == true) { C1[24] = "1"; } else { C1[24] = "0"; }
                if (cheSalidasVendedoresR.Checked == true) { C1[25] = "1"; } else { C1[25] = "0"; }
                if (cheGraficoR.Checked == true) { C1[26] = "1"; } else { C1[26] = "0"; }
                if (chePrenominaR.Checked == true) { C1[27] = "1"; } else { C1[27] = "0"; }
                if (cheCobranzaR.Checked == true) { C1[28] = "1"; } else { C1[28] = "0"; }
                if (cheHistoricoDeMovimientosR.Checked == true) { C1[29] = "1"; } else { C1[29] = "0"; }
                if (cheConsignacionR.Checked == true) { C1[30] = "1"; } else { C1[30] = "0"; }
                if (cheIngresoDeEfectivoR.Checked == true) { C1[31] = "1"; } else { C1[31] = "0"; }
                //Usuarios
              
                if (cheCrearUsuarios.Checked == true) { C1[32] = "1"; } else { C1[32] = "0"; }
                if (cheModificarUsuarios.Checked == true) { C1[33] = "1"; } else { C1[33] = "0"; }
                if (cheAsignarPrivilegios.Checked == true) { C1[34] = "1"; } else { C1[34] = "0"; }
                if (cheCobranzaCredito.Checked == true) { C1[35] = "1"; } else { C1[35] = "0"; }
                if (cheAutorizaCredito.Checked == true) { C1[36] = "1"; } else { C1[36] = "0"; }
                if (chkDescuentoComision.Checked == true) { C1[37] = "1"; } else { C1[37] = "0"; }
                if (chbxCajaRapida.Checked == true) { C1[38] = "1"; } else { C1[38] = "0"; }
                if (chbxFamilias.Checked == true) { C1[39] = "1"; } else { C1[39] = "0"; }
                if (chbxDescripciones.Checked == true) { C1[40] = "1"; } else { C1[40] = "0"; }

                DataTable Tabla = new DataTable();
                string comando = "DELETE FROM PrivilegiosDeUsuario WHERE Usuarios_id_usuarios=" + tbxCodigo.Text;
                Conexion.Conectarse();
                Conexion.Ejecutar(comando);

                    string Insert = " INSERT INTO PrivilegiosDeUsuario VALUES (" + tbxCodigo.Text + ", ";
                    for (int i = 0; i < C1.Length; i++)
                    {
                        if (C1.Length - 1 != i)
                        {
                            Insert += C1[i] + ", ";
                        }
                        else
                        {
                            Insert += C1[i] + ") ";
                        }
                    }
                    if (Conexion.Ejecutar(Insert))
                    {
                        if (cheAutorizaCredito.Checked == true) 
                        {
                            Insert = " UPDATE Usuarios SET AutorizarCredito=true WHERE id_usuarios=" + tbxCodigo.Text;
                            Conexion.Ejecutar(Insert);
                        } 
                        else 
                        {
                            C1[36] = "0"; 
                        }
                        MessageBox.Show("Guardado con Éxito");
                    }
                Conexion.Desconectarse();
            }
        }
        public void LLenarPrivilegios()
        {
            DataTable Tabla = new DataTable();

            string comando = "Select * from PrivilegiosDeUsuario WHERE Usuarios_id_usuarios=" + tbxCodigo.Text;
            Conexion.Conectarse();
            Conexion.Ejecutar(comando, ref Tabla);
            Conexion.Desconectarse();

            if (Tabla.Rows.Count > 0)
            {
                DataRow row = Tabla.Rows[0];

                //Ventas
                //if (row["Nombre"].ToString() == "1") { ventasToolStripMenuItem.Enabled = true; } else { ventasToolStripMenuItem.Enabled = false; }
                if (row["VentasSucursal"].ToString() == "1") { cheVentasSucursal.Checked = true; } else { cheVentasSucursal.Checked = false; }
                if (row["SalidasEmpleados"].ToString() == "1") { cheSalidasVendedores.Checked = true; } else { cheSalidasVendedores.Checked = false; }
                if (row["EntradasEmpleados"].ToString() == "1") { cheEntradasVendedores.Checked = true; } else { cheEntradasVendedores.Checked = false; }
                if (row["Consignacion"].ToString() == "1") { cheConsignacion.Checked = true; } else { cheConsignacion.Checked = false;  }
                if (row["CorteDeCaja"].ToString() == "1") { cheCorteDeCaja.Checked = true; } else { cheCorteDeCaja.Checked = false; }
                //Inventarios
                if (row["EntradasDeInventario"].ToString() == "1") { cheEntradasInventario.Checked = true; } else { cheEntradasInventario.Checked = false; }
                if (row["Conversiones"].ToString() == "1") { cheConversiones.Checked = true; } else { cheConversiones.Checked = false; }
                if (row["Inventario/Costo"].ToString() == "1") { cheInventarioCosto.Checked = true; } else { cheInventarioCosto.Checked = false; }
                if (row["Inventario"].ToString() == "1") { cheInventarioNormal.Checked = true; } else { cheInventarioNormal.Checked = false; }
                if (row["SalidasEspeciales"].ToString() == "1") { cheSalidasEspeciales.Checked = true; } else { cheSalidasEspeciales.Checked = false; }
                //Catalogos
                //if (row["VentasSucursal"].ToString() == "1") { catalogosToolStripMenuItem.Enabled = true; } else { catalogosToolStripMenuItem.Enabled = false; }
                if (row["Vendedores"].ToString() == "1") { cheVendedores.Checked = true; } else { cheVendedores.Checked = false; }
                if (row["Clientes"].ToString() == "1") { cheClientes.Checked = true; } else { cheClientes.Checked = false; }
                if (row["Productos"].ToString() == "1") { cheProductos.Checked = true; } else { cheProductos.Checked = false; }
                if (row["ConsultarProductos"].ToString() == "1") { cheConsultasProductos.Checked = true; } else { cheConsultasProductos.Checked = false; }
                if (row["UnidadesDeMedida"].ToString() == "1") { cheUnidadesDeMedida.Checked = true; } else { cheUnidadesDeMedida.Checked = false; }
                if (row["Almacenes"].ToString() == "1") { cheAlmacenes.Checked = true; } else { cheAlmacenes.Checked = false; }
                if (row["Comisiones"].ToString() == "1") { cheComisiones.Checked = true; } else { cheComisiones.Checked = false; }
                if (row["Rutas"].ToString() == "1") { cheRutas.Checked = true; } else { cheRutas.Checked = false; }
                //Reportes
                //if (row["VentasSucursal"].ToString() == "1") { reporteDeVentasToolStripMenuItem.Enabled = true; } else { reporteDeVentasToolStripMenuItem.Enabled = false; }
                if (row["Ventas"].ToString() == "1") { cheVenrasReporte.Checked = true; } else { cheVenrasReporte.Checked = false; }
                if (row["VentasCosto"].ToString() == "1") { cheVentasCosto.Checked = true; } else { cheVentasCosto.Checked = false; }
                if (row["VentasGenerales"].ToString() == "1") { cheVentasGenerales.Checked = true; } else { cheVentasGenerales.Checked = false; }
                if (row["Inventario-Entradas"].ToString() == "1") { cheEntradasInventarioR.Checked = true; } else { cheEntradasInventarioR.Checked = false; }
                if (row["Inventario-Salidas"].ToString() == "1") { cheSalidasInventarioR.Checked = true; } else { cheSalidasInventarioR.Checked = false; }
                if (row["Vendedores-Entradas"].ToString() == "1") { cheEntradasVendedoresR.Checked = true; } else { cheEntradasVendedoresR.Checked = false; }
                if (row["Vendedores-Salidas"].ToString() == "1") { cheSalidasVendedoresR.Checked = true; } else { cheSalidasVendedoresR.Checked = false; }
                if (row["Grafico"].ToString() == "1") { cheGraficoR.Checked = true; } else { cheGraficoR.Checked = false; }
                if (row["Prenomina"].ToString() == "1") { chePrenominaR.Checked = true; } else { chePrenominaR.Checked = false; }
                if (row["Cobranza"].ToString() == "1") { cheCobranzaR.Checked = true; } else { cheCobranzaR.Checked = false; }
                if (row["historicoDeMovimientos"].ToString() == "1") { cheHistoricoDeMovimientosR.Checked = true; } else { cheHistoricoDeMovimientosR.Checked = false; }
                if (row["Reporte-Consignacion"].ToString() == "1") { cheConsignacionR.Checked = true; } else { cheConsignacionR.Checked = false; }
                if (row["IngresoDeEfectivo"].ToString() == "1") { cheIngresoDeEfectivoR.Checked = true; } else { cheIngresoDeEfectivoR.Checked = false; }
                if (row["CrearUsuario"].ToString() == "1") { cheCrearUsuarios.Checked = true; } else { cheCrearUsuarios.Checked = false; }
                if (row["ModificarUsuario"].ToString() == "1") { cheModificarUsuarios.Checked = true; } else { cheModificarUsuarios.Checked = false; }
                if (row["AsignarPrivilegios"].ToString() == "1") { cheAsignarPrivilegios.Checked = true; } else { cheAsignarPrivilegios.Checked = false; }
                if (row["DescuentoComision"].ToString() == "1") { chkDescuentoComision.Checked = true; } else { chkDescuentoComision.Checked = false; }

                if (row["CobranzaCreditos"].ToString() == "1") { cheCobranzaCredito.Checked = true; } else { cheCobranzaCredito.Checked = false; }
                if (row["CajaRapida"].ToString() == "1") { chbxCajaRapida.Checked = true; } else { chbxCajaRapida.Checked = false; }

                if (row["Familias"].ToString() == "1") { chbxFamilias.Checked = true; } else { chbxFamilias.Checked = false; }
                if (row["DescProductos"].ToString() == "1") { chbxDescripciones.Checked = true; } else { chbxDescripciones.Checked = false; }



            }

        }
        private void che1_CheckedChanged(object sender, EventArgs e)
        {
            if (cheVentas.Checked == true)
            {
                cheVentasSucursal.Checked = true;
                cheSalidasVendedores.Checked = true;
                cheEntradasVendedores.Checked = true;
                chePedidosEspeciales.Checked = true;
                cheConsignacion.Checked = true;
                cheCorteDeCaja.Checked = true;
            }
            else
            {
                cheVentasSucursal.Checked = false;
                cheSalidasVendedores.Checked = false;
                cheEntradasVendedores.Checked = false;
                chePedidosEspeciales.Checked = false;
                cheConsignacion.Checked = false;
                cheCorteDeCaja.Checked = false;
            }
        }

        private void che5_CheckedChanged(object sender, EventArgs e)
        {
            if (cheInventarios.Checked == true)
            {
                cheEntradasInventario.Checked = true;
                cheConversiones.Checked = true;
                cheInventarioCosto.Checked = true;
                cheInventarioNormal.Checked = true;
                cheSalidasEspeciales.Checked = true;

            }
            else
            {
                cheEntradasInventario.Checked = false;
                cheConversiones.Checked = false;
                cheInventarioCosto.Checked = false;
                cheInventarioNormal.Checked = false;
                cheSalidasEspeciales.Checked = false;
            }
        }

        private void tbxCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {

                e.Handled = true;

            }
        }

        private void tbxCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                BuscarUsuarios id = new BuscarUsuarios();
                DialogResult dr = id.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    tbxCodigo.Text = id.regresar.valXn;
                }
                tbxCodigo.Focus();
                ObtenerUsuario();
            }
        }

        private void AsignarPrivilegios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

       
    }
}

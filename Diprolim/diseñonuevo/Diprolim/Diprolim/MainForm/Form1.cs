using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;
using Diprolim.MainForm;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Diprolim
{
    public partial class Form1 : Form
    {
        UnicaSQL.DBMS_Unico Conexion;
        conexion conn = new conexion();
        string Privilegio = "";
        string UsuarioID = "";
        string Comando = "";
        DataTable tabla;
        
        public string ID = "";
        public Form1()
        {
            InitializeComponent();
            Leer_txt();
            Conexion = new UnicaSQL.DBMS_Unico(Gestor, Servidor, BaseDeDatos, Usuarios, Password, 3306);
            AjustarInventario();
            AjusteCredito();
            Inactivo();
            ComprobarPrivilegios();
        }

        public void AjusteCredito()
        {
            try
            {
                Conexion.Conectarse();
                Conexion.Ejecutar("UPDATE Ventas SET Pendiente=0 WHERE Pendiente<0.01 and tipo_compra='credito'");
                Conexion.Desconectarse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AjustarInventario()
        {
            try
            {
                Conexion.Conectarse();
                Conexion.Ejecutar("UPDATE Articulos SET Cantidad=0 WHERE Cantidad<0.01");
                Conexion.Desconectarse();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int Cont = 0;
        string Linea;
        String Gestor;
        String BaseDeDatos;
        String Servidor;
        String Usuarios;
        String Password;
        public void Leer_txt()
        {
            StreamReader txt = new StreamReader(@"Config.txt");

            while ((Linea = txt.ReadLine()) != null)
            {
                if (Cont == 0)
                {
                    Gestor = Linea;
                }
                else if (Cont == 1)
                {
                    Servidor = Linea;
                }
                else if (Cont == 2)
                {
                    BaseDeDatos = Linea;
                }
                else if (Cont == 3)
                {
                    Usuarios = Linea;
                }
                else if (Cont == 4)
                {
                    Password = Linea;
                }
                Cont++;
            }
            txt.Close();
        }
        public void ComprobarPrivilegios()
        {
            DataTable Tabla = new DataTable();
            DataTable Tablaa = new DataTable();
            Conexion.Conectarse();
            Comando = "SELECT * FROM USUARIOS";
            Conexion.Ejecutar(Comando, ref tabla);
            if (tabla.Rows.Count > 0)
            {
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    DataRow row = tabla.Rows[i];
                    Tablaa.Rows.Clear();
                    string ComandoO = "SELECT * FROM PrivilegiosDeUsuario WHERE Usuarios_id_usuarios=" + row["id_usuarios"].ToString();
                    Conexion.Ejecutar(ComandoO, ref Tablaa);
                    if (Tablaa.Rows.Count == 0)
                    {
                        ComandoO = "INSERT INTO PrivilegiosDeUsuario (Usuarios_id_usuarios) VALUES (" + row["id_usuarios"].ToString() + ")";
                        Conexion.Ejecutar(ComandoO);
                    }

                }

            }

            Conexion.Desconectarse();
        }
        private void capturaDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentasDLocal VDL = new VentasDLocal(UsuarioID, Conexion);
            VDL.ShowDialog();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventario I = new Inventario();
            I.ShowDialog();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salidas S = new Salidas(UsuarioID, Conexion);
            S.ShowDialog();
        }

        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conexion.Conectarse();
            inicioSesion id = new inicioSesion();
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                UsuarioID = id.regresar.valXn;
                Comando = "select * from usuarios where id_usuarios='" + UsuarioID + "'";
                Conexion.Ejecutar(Comando, ref tabla);
                if (tabla.Rows.Count > 0)
                {
                    LUsuario.Text = tabla.Rows[0][1].ToString();
                    Privilegio = tabla.Rows[0][3].ToString();
                }

                Usuario();
                salidasEspecialesToolStripMenuItem.Enabled = true;
            }
            label1.Text = "Usuario:";
            Conexion.Desconectarse();
        }
        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentasVendedor E = new VentasVendedor(UsuarioID, Conexion);
            E.ShowDialog();

        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inactivo();
            LUsuario.Text = "";
            label1.Text = "";
        }

        public void Inactivo()
        {
            capturaDeVentasToolStripMenuItem.Enabled = false;
            btnInvVendedor.Enabled = false;
            reportesToolStripMenuItem.Enabled = false;
            entradasToolStripMenuItem.Enabled = false;
            btnVentasVendedor.Enabled = false;
            consignacionToolStripMenuItem.Enabled = false;
            corteDeCajaToolStripMenuItem.Enabled = false;
            //Inventarios
            capturarToolStripMenuItem.Enabled = false;
            conversionesToolStripMenuItem.Enabled = false;
            inventarioToolStripMenuItem.Enabled = false;
            inventarioToolStripMenuItem1.Enabled = false;
            salidasEspecialesToolStripMenuItem.Enabled = false;
            //Catalogos
            //if (row["VentasSucursal"].ToString() == "1") { catalogosToolStripMenuItem.Enabled = true; } else { catalogosToolStripMenuItem.Enabled = false; }
            empleadosToolStripMenuItem.Enabled = false;
            clientesToolStripMenuItem.Enabled = false;
            capturarProductosToolStripMenuItem.Enabled = false;
            consultarToolStripMenuItem.Enabled = false;
            valorDeMedidaToolStripMenuItem.Enabled = false;
            familiasToolStripMenuItem.Enabled = false;
            descripcionesToolStripMenuItem.Enabled = false;
            almacenesToolStripMenuItem.Enabled = false;
            categoriasToolStripMenuItem.Enabled = false;
            rutasToolStripMenuItem.Enabled = false;
            //Reportes
            //if (row["VentasSucursal"].ToString() == "1") { reporteDeVentasToolStripMenuItem.Enabled = true; } else { reporteDeVentasToolStripMenuItem.Enabled = false; }
            ventasToolStripMenuItem1.Enabled = false;
            btnConsignacion.Enabled = false;
            ventasCostoToolStripMenuItem1.Enabled = false;
            ventasGeneralesToolStripMenuItem.Enabled = false;
            entradasToolStripMenuItem2.Enabled = false;
            salidasToolStripMenuItem1.Enabled = false;
            entradasToolStripMenuItem3.Enabled = false;
            salidasToolStripMenuItem2.Enabled = false;
            graficoToolStripMenuItem.Enabled = false;
            prenominaToolStripMenuItem.Enabled = false;
            cobranzaToolStripMenuItem1.Enabled = false;
            historicoDeMovimientosToolStripMenuItem.Enabled = false;
            consignacionToolStripMenuItem1.Enabled = false;
            ingresoDeEfectivoToolStripMenuItem.Enabled = false;
            crearUsuarioToolStripMenuItem.Enabled = false;
            modificarUsuarioToolStripMenuItem.Enabled = false;
            btnCobranzaCredito.Enabled = false;
            asignarPrivilegiosToolStripMenuItem.Enabled = false;
            descuentoComisiónToolStripMenuItem.Enabled = false;
            btnVentaRapida.Enabled = false;
            cajaRapidaToolStripMenuItem.Enabled = false;
            btnPedidos.Enabled = false;

        }

        public void Usuario()
        {
            DataTable Tabla = new DataTable();

            string comando = "Select * from PrivilegiosDeUsuario WHERE Usuarios_id_usuarios=" + UsuarioID;
            Conexion.Ejecutar(comando, ref Tabla);

            if (Tabla.Rows.Count > 0)
            {
                DataRow row = Tabla.Rows[0];

                //Ventas
                //if (row["Nombre"].ToString() == "1") { ventasToolStripMenuItem.Enabled = true; } else { ventasToolStripMenuItem.Enabled = false; }
                if (row["VentasSucursal"].ToString() == "1") { capturaDeVentasToolStripMenuItem.Enabled = true; } else { capturaDeVentasToolStripMenuItem.Enabled = false; }
                if (row["SalidasEmpleados"].ToString() == "1") { reportesToolStripMenuItem.Enabled = true; btnInvVendedor.Enabled = true; } else { reportesToolStripMenuItem.Enabled = false; btnInvVendedor.Enabled = false; }
                if (row["EntradasEmpleados"].ToString() == "1") { entradasToolStripMenuItem.Enabled = true; btnVentasVendedor.Enabled = true; } else { entradasToolStripMenuItem.Enabled = false; btnVentasVendedor.Enabled = false; }
                if (row["Consignacion"].ToString() == "1") { consignacionToolStripMenuItem.Enabled = true; btnConsignacion.Enabled = true; } else { consignacionToolStripMenuItem.Enabled = false; btnConsignacion.Enabled = false; }
                if (row["CorteDeCaja"].ToString() == "1") { corteDeCajaToolStripMenuItem.Enabled = true; } else { corteDeCajaToolStripMenuItem.Enabled = false; }
                //Inventarios
                if (row["EntradasDeInventario"].ToString() == "1") { capturarToolStripMenuItem.Enabled = true; } else { capturarToolStripMenuItem.Enabled = false; }
                if (row["Conversiones"].ToString() == "1") { conversionesToolStripMenuItem.Enabled = true; } else { conversionesToolStripMenuItem.Enabled = false; }
                if (row["Inventario/Costo"].ToString() == "1") { inventarioToolStripMenuItem.Enabled = true; } else { inventarioToolStripMenuItem.Enabled = false; }
                if (row["Inventario"].ToString() == "1") { inventarioToolStripMenuItem1.Enabled = true; } else { inventarioToolStripMenuItem1.Enabled = false; }
                if (row["SalidasEspeciales"].ToString() == "1") { salidasEspecialesToolStripMenuItem.Enabled = true; } else { salidasEspecialesToolStripMenuItem.Enabled = false; }
                //Catalogos
                //if (row["VentasSucursal"].ToString() == "1") { catalogosToolStripMenuItem.Enabled = true; } else { catalogosToolStripMenuItem.Enabled = false; }
                if (row["Vendedores"].ToString() == "1") { empleadosToolStripMenuItem.Enabled = true; } else { empleadosToolStripMenuItem.Enabled = false; }
                if (row["Clientes"].ToString() == "1") { clientesToolStripMenuItem.Enabled = true; } else { clientesToolStripMenuItem.Enabled = false; }
                if (row["Productos"].ToString() == "1") { capturarProductosToolStripMenuItem.Enabled = true; } else { capturarProductosToolStripMenuItem.Enabled = false; }
                if (row["ConsultarProductos"].ToString() == "1") { consultarToolStripMenuItem.Enabled = true; } else { consultarToolStripMenuItem.Enabled = false; }
                if (row["UnidadesDeMedida"].ToString() == "1") { valorDeMedidaToolStripMenuItem.Enabled = true; } else { valorDeMedidaToolStripMenuItem.Enabled = false; }
                if (row["Almacenes"].ToString() == "1") { almacenesToolStripMenuItem.Enabled = true; } else { almacenesToolStripMenuItem.Enabled = false; }
                if (row["Comisiones"].ToString() == "1") { categoriasToolStripMenuItem.Enabled = true; } else { categoriasToolStripMenuItem.Enabled = false; }
                if (row["Rutas"].ToString() == "1") { rutasToolStripMenuItem.Enabled = true; } else { rutasToolStripMenuItem.Enabled = false; }
                //Reportes
                //if (row["VentasSucursal"].ToString() == "1") { reporteDeVentasToolStripMenuItem.Enabled = true; } else { reporteDeVentasToolStripMenuItem.Enabled = false; }
                if (row["Ventas"].ToString() == "1") { ventasToolStripMenuItem1.Enabled = true; } else { ventasToolStripMenuItem1.Enabled = false; }
                if (row["VentasCosto"].ToString() == "1") { ventasCostoToolStripMenuItem1.Enabled = true; } else { ventasCostoToolStripMenuItem1.Enabled = false; }
                if (row["VentasGenerales"].ToString() == "1") { ventasGeneralesToolStripMenuItem.Enabled = true; } else { ventasGeneralesToolStripMenuItem.Enabled = false; }
                if (row["Inventario-Entradas"].ToString() == "1") { entradasToolStripMenuItem2.Enabled = true; } else { entradasToolStripMenuItem2.Enabled = false; }
                if (row["Inventario-Salidas"].ToString() == "1") { salidasToolStripMenuItem1.Enabled = true; } else { salidasToolStripMenuItem1.Enabled = false; }
                if (row["Vendedores-Entradas"].ToString() == "1") { entradasToolStripMenuItem3.Enabled = true; } else { entradasToolStripMenuItem3.Enabled = false; }
                if (row["Vendedores-Salidas"].ToString() == "1") { salidasToolStripMenuItem2.Enabled = true; } else { salidasToolStripMenuItem2.Enabled = false; }
                if (row["Grafico"].ToString() == "1") { graficoToolStripMenuItem.Enabled = true; } else { graficoToolStripMenuItem.Enabled = false; }
                if (row["Prenomina"].ToString() == "1") { prenominaToolStripMenuItem.Enabled = true; } else { prenominaToolStripMenuItem.Enabled = false; }
                if (row["Cobranza"].ToString() == "1") { cobranzaToolStripMenuItem1.Enabled = true; } else { cobranzaToolStripMenuItem1.Enabled = false; }
                if (row["historicoDeMovimientos"].ToString() == "1") { historicoDeMovimientosToolStripMenuItem.Enabled = true; } else { historicoDeMovimientosToolStripMenuItem.Enabled = false; }
                if (row["Reporte-Consignacion"].ToString() == "1") { consignacionToolStripMenuItem1.Enabled = true; } else { consignacionToolStripMenuItem1.Enabled = false; }
                if (row["IngresoDeEfectivo"].ToString() == "1") { ingresoDeEfectivoToolStripMenuItem.Enabled = true; } else { ingresoDeEfectivoToolStripMenuItem.Enabled = false; }
                if (row["CrearUsuario"].ToString() == "1") { crearUsuarioToolStripMenuItem.Enabled = true; } else { crearUsuarioToolStripMenuItem.Enabled = false; }
                if (row["ModificarUsuario"].ToString() == "1") { modificarUsuarioToolStripMenuItem.Enabled = true; } else { modificarUsuarioToolStripMenuItem.Enabled = false; }
                if (row["AsignarPrivilegios"].ToString() == "1") { asignarPrivilegiosToolStripMenuItem.Enabled = true; } else { asignarPrivilegiosToolStripMenuItem.Enabled = false; }

                if (row["CobranzaCreditos"].ToString() == "1") { btnCobranzaCredito.Enabled = true; } else { btnCobranzaCredito.Enabled = false; }
                if (row["DescuentoComision"].ToString() == "1") { descuentoComisiónToolStripMenuItem.Enabled = true; } else { descuentoComisiónToolStripMenuItem.Enabled = false; }
                if (row["CajaRapida"].ToString() == "1") { btnVentaRapida.Enabled = true; cajaRapidaToolStripMenuItem.Enabled = true;
                                                        } else { btnVentaRapida.Enabled = false; cajaRapidaToolStripMenuItem.Enabled = false; }
                if (row["Familias"].ToString() == "1"){ familiasToolStripMenuItem.Enabled = true; } else { familiasToolStripMenuItem.Enabled = false; }
                if (row["DescProductos"].ToString() == "1"){ descripcionesToolStripMenuItem.Enabled = true; } else { descripcionesToolStripMenuItem.Enabled = false; }
                if (row["Pedidos"].ToString() == "1") { btnPedidos.Enabled = true; } else { btnPedidos.Enabled = false; }
            }
        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreacionUsuarios CU = new CreacionUsuarios();
            CU.ShowDialog();
        }


        private void consultarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            consultaProductosCosto ca = new consultaProductosCosto();
            ca.ShowDialog();
        }

        private void agregarNuevoProductoToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            capturaProductos cP = new capturaProductos();
            cP.ShowDialog();
        }

        private void capturarProductosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Productos modP = new Productos(Conexion);
            modP.ShowDialog();
        }

        private void valorDeMedidaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            nuevaUnidadMedida nuM = new nuevaUnidadMedida();
            nuM.ShowDialog();
        }


        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comisiones C = new comisiones();
            C.ShowDialog();
        }

        private void graficoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteGrafico repg = new ReporteGrafico();
            repg.ShowDialog();
        }

        private void capturarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Capturar_Entrada capE = new Capturar_Entrada(UsuarioID, Conexion);
            capE.ShowDialog();
        }

        private void inventarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InventarioSinCosto insc = new InventarioSinCosto();
            insc.ShowDialog();
        }

        private void btnVentasVendedor_Click(object sender, EventArgs e)
        {
            VentasVendedor objVentasVendedor = new VentasVendedor(UsuarioID, Conexion);
            objVentasVendedor.ShowDialog();
        }

        private void btnInvVendedor_Click(object sender, EventArgs e)
        {
            Salidas ssal = new Salidas(UsuarioID, Conexion);
            ssal.ShowDialog();
        }

        private void btnConsignacion_Click(object sender, EventArgs e)
        {
            Consignacion Consig = new Consignacion(Conexion, UsuarioID);
            Consig.ShowDialog();
        }

        private void btnCobranzaCredito_Click(object sender, EventArgs e)
        {
            CobranzaCredito Cobcred = new CobranzaCredito(Conexion);
            Cobcred.ShowDialog();
        }

        private void conversionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conversiones C = new Conversiones(UsuarioID, Conexion);
            C.ShowDialog();
        }

        private void prenominaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prenomina RC = new Prenomina(Conexion);
            RC.ShowDialog();
        }

        private void salidasEspecialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Respuesta = "";
            string S = "";
            inicioSesion id = new inicioSesion(S);
            DialogResult dr = id.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Respuesta = id.regresar.valXn;
            }
            if (Respuesta != "")
            {
                DataTable Tabla = new DataTable();
                string comando = "Select * from PrivilegiosDeUsuario WHERE Usuarios_id_usuarios=" + Respuesta;
                Conexion.Conectarse();
                Conexion.Ejecutar(comando, ref Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    DataRow row = Tabla.Rows[0];
                    if (row["SalidasEspeciales"].ToString() == "1")
                    {
                        Salidas_de_Inventario sadei = new Salidas_de_Inventario(UsuarioID);
                        sadei.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("El usuario no tiene permiso necesario para ver estas salidas");
                    }
                }
                Conexion.Desconectarse();
            }
        }


        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificacionUsuario mode = new ModificacionUsuario();
            mode.ShowDialog();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Reportes_de_Ventas rpv = new Reportes_de_Ventas(Conexion);
            rpv.ShowDialog();
        }

        private void ventasCostoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReporteVentasCosto rpv = new ReporteVentasCosto();
            rpv.ShowDialog();
        }
        private void entradasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReporteEntradaInventario rein = new ReporteEntradaInventario();
            rein.ShowDialog();
        }

        private void salidasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReporteSalidasInventario repSI = new ReporteSalidasInventario();
            repSI.ShowDialog();
        }

        private void asignarPrivilegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AsignarPrivilegios AP = new AsignarPrivilegios(Conexion);
            AP.ShowDialog();
        }

        private void ventasGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteVentasGenerales rpvg = new ReporteVentasGenerales();
            rpvg.ShowDialog();
        }


        private void corteDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CorteSucursal CC = new CorteSucursal();
            CC.ShowDialog();
        }


        private void historicoDeMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historicos_de_movimientos HDM = new historicos_de_movimientos(Conexion);
            HDM.ShowDialog();
        }

        private void consignacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consignacion C = new Consignacion(Conexion, UsuarioID);
            C.ShowDialog();
        }

        private void consignacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Reporte_de_consignacion RDC = new Reporte_de_consignacion(Conexion);
            RDC.ShowDialog();
        }

        private void cobranzaCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CobranzaCredito CC = new CobranzaCredito(Conexion);
                CC.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cobranzaNuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepCobranzaN repcn = new RepCobranzaN(Conexion);
            repcn.ShowDialog();
        }

        private void cobranzaAnteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reporteCobranza RC = new reporteCobranza();
            RC.ShowDialog();
        }

        private void ingresoDeEfectivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingreso_de_Efectivo IE = new Ingreso_de_Efectivo();
            IE.ShowDialog();
        }

        private void entradasToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ReporteEntradaV repEV = new ReporteEntradaV();
            repEV.ShowDialog();
        }

        private void salidasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReporteSalidaV repSV = new ReporteSalidaV(Conexion);
            repSV.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarEmpleado ME = new ModificarEmpleado(Conexion);
            ME.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void almacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarAlmacen MA = new ModificarAlmacen(Conexion);
            MA.ShowDialog();
        }

        private void rutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rutas R = new Rutas(Conexion);
            R.ShowDialog();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultarClientes CC = new ConsultarClientes(Conexion);
            CC.ShowDialog();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clientes MC = new Clientes(Conexion);
            MC.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pedidosSugeridosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PedidosSugeridos ps = new PedidosSugeridos(Conexion);
            ps.ShowDialog();
        }

        private void clientesInactivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes_inactivos CI = new Clientes_inactivos(Conexion);
            CI.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Saliendo del sistema.", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else if (Privilegio == "Activo")
            {
                if (e.KeyCode == Keys.F1)
                {
                    btnVentasVendedor_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F2)
                {
                    btnInvVendedor_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F3)
                {
                    btnConsignacion_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F4)
                {
                    btnCobranzaCredito_Click(sender, e);
                }
                else if (e.KeyCode == Keys.F5)
                {
                    btnVentaRapida_Click(sender, e);
                }else if(e.KeyCode == Keys.F6 && btnPedidos.Enabled)
                {
                    btnPedidos_Click(sender, e);
                }
            }
        }

        private void descuentoComisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescuentosComision objDescuentosComision = new DescuentosComision();
            objDescuentosComision.ShowDialog();
        }

        private void cobranzaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RepCobranzaN repcn = new RepCobranzaN(Conexion);
            repcn.ShowDialog();
        }

        private void btnVentaRapida_Click(object sender, EventArgs e)
        {
            if (btnVentaRapida.Enabled)
            {
                VentaCajaRapida objVentaCajaRapida = new VentaCajaRapida(Conexion, UsuarioID);
                objVentaCajaRapida.ShowDialog();
            }
            
        }

        private void impresoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Impresoras objImpresoras = new Impresoras();
            objImpresoras.ShowDialog();
        }



        private void descuentoComisiónToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            DescuentosComision objDescuentosComision = new DescuentosComision();
            objDescuentosComision.ShowDialog();
        }

        private void descuentoCambioEnvasesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DescuentoCambioEnvase objDescuentoCambioEnvase = new DescuentoCambioEnvase();
            objDescuentoCambioEnvase.ShowDialog();
        }

        private void cajaRapidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentaCajaRapida objVentaCajaRapida = new VentaCajaRapida(Conexion, UsuarioID);
            objVentaCajaRapida.ShowDialog();
        }

        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Familias objFamilias = new Familias();
            objFamilias.ShowDialog();
        }

        private void descripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DescripcionProductos objDescripcionProductos = new DescripcionProductos();
            objDescripcionProductos.ShowDialog();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            Pedidos objPedidos = new Pedidos();
            objPedidos.ShowDialog();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identidades
{
    public class CClientes
    {
        private int idclientes;
        public int IDClientes
        {
            get { return idclientes; }
            set { idclientes = value; }
        }
        private String nombre;
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private int idEmpleado;
        public int IDEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }
        private int idcategorias;
        public int IDcategorias
        {
            get { return idcategorias; }
            set { idcategorias = value; }
        }

        private string sTelefono;
        public String Telefono
        {
            get { return sTelefono; }
            set { sTelefono = value; }
        }
        DateTime dFechaIngreso;
        public DateTime FechaIngreso
        {
            get { return dFechaIngreso; }
            set { dFechaIngreso = value; }
        }
    }
}

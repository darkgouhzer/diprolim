using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identidades
{
    public class CEmpleados
    {
        private int idEmpleado;
	    public int IDEmpleado
	    {
		    get { return idEmpleado;}
		    set { idEmpleado = value;}
	    }

        private String nombre;
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private String apellidoPaterno;
        public String ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }
        private String apellidoMaterno;
        public String ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }
        private DateTime fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        private int idPuestos;
        public int IDPuestos
        {
            get { return idPuestos; }
            set { idPuestos = value; }
        }
        private Double limiteInventario;
        public Double LimiteInventario
        {
            get { return limiteInventario; }
            set { limiteInventario = value; }
        }
        Double limiteCredito;
        public Double LimiteCredito
        {
            get { return limiteCredito; }
            set { limiteCredito = value; }
        }
        private String sStatus;
        public String Status
        {
            get { return sStatus; }
            set { sStatus = value; }
        }
        String sTipoVendedor;
        public String TipoVendedor
        {
            get { return sTipoVendedor; }
            set { sTipoVendedor = value; }
        }


    }
}

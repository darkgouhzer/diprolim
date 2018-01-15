using AccesoDatos;
using Identidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasNegocios
{
    public class ClienteBO
    {
        public ClienteBO()
        {

        }
        public CClientes ObtenerDatosCliente(int iCliente)
        {
            CClientes objCClientes = new CClientes();
            ClienteDAL objClienteDAL = new ClienteDAL();
            objCClientes = objClienteDAL.ObtenerDatosCliente(iCliente);
            return objCClientes;
        }
    }
}

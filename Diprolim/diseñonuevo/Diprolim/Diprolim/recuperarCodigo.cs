using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diprolim
{
    public class recuperarCodigo
    {
        private String _xn ="";
        private double[,] _lis;
        public String valXn
        {
            get
            {
                return (_xn);
            }
            set
            {
                _xn = value;
            }
        }
        public double[,] valLis
        {
            get
            {
                return (_lis);
            }
            set
            {
                _lis = value;
            }
        }

    }
}

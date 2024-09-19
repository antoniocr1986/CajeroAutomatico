using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class Retiro
    {
        public DateTime Fecha { get; set; }
        public double ValorRetiro { get; set; }
        public int RetirosHoyNum { get; set; }
        public double RetirosHoyEuros { get; set; }

        public Retiro()
        {
            Fecha = DateTime.Now;   
            RetirosHoyNum = 0;  
        }

        public Retiro(DateTime fecha, double valorRetiro, double RetirosHoyEuros)//TODO
        {
            Fecha = fecha;
            ValorRetiro = valorRetiro;
            RetirosHoyNum = 0;
            RetirosHoyEuros = 0;//TODO
        }
    }
}

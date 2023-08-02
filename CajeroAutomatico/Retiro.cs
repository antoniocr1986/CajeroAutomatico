using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class Retiro
    {
        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value.Date; }
        }
        public double ValorRetiro { get; set; }
        public int RetirosHoyNum { get; set; }
        public double RetirosHoyEuros { get; set; }

        public Retiro()
        {
            Fecha = DateTime.Now;   
            RetirosHoyNum = 0;  
        }

        public Retiro(DateTime fecha, double valorRetiro)
        {
            Fecha = fecha;
            ValorRetiro = valorRetiro;
        }
    }
}

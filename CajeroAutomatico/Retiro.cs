using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class Retiro
    {
        DateTime Fecha { get; set; }
        double ValorRetiro { get; set; }
        int RetirosHoyNum { get; set; }
        double RetirosHoyEuros { get; set; }

        public Retiro()
        {
        }

        public Retiro(DateTime fecha, double valorRetiro)
        {
            Fecha = fecha;
            ValorRetiro = valorRetiro;
        }
    }
}

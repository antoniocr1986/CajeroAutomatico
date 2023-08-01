using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class CuentaCorriente
    {
        double Saldo { get; set; }
        long NumCuenta { get; set; }
        string Usuario { get; set; }
        int PIN { get; set; }

        public CuentaCorriente(double saldo, long numCuenta,string usuario, int pin)
        {
            Saldo = saldo;
            NumCuenta = numCuenta;
            Usuario = usuario;
            PIN = pin;
        }

        public double consultarSaldo()
        {
            return Saldo;
        }

        public void retirarSaldo(double cantidad)
        {
            if (cantidad > 0)
            {
                Saldo = Saldo - cantidad;
            }  
        }

        public void ingresarSaldo( double cantidad)
        {
            Saldo = Saldo + cantidad;
        }
    }
}

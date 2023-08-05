using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class CuentaCorriente
    {
        public double Saldo { get; set; }
        public long NumCuenta { get; set; }
        public Usuario Usuario { get; set; }
        public int PIN { get; set; }
        public String[] Transferencias { get; set; }
        public int Contador { get; set; }

        public CuentaCorriente(double saldo, long numCuenta,Usuario usuario, int pin)
        {
            Saldo = saldo;
            NumCuenta = numCuenta;
            Usuario = usuario;
            PIN = pin;
            Transferencias = new string[] { "", "", "", "", "" };
        }

        public double consultarSaldo()
        {
            return Saldo;
        }

        public void retirarSaldo(double cantidad)
        {
            if (cantidad > 0)
            {
                Saldo -= cantidad;
            }  
        }

        public void ingresarSaldo( double cantidad)
        {
            Saldo += cantidad;
        }

        public long consultarNumCuenta()
        {
            return NumCuenta;
        }
    }
}

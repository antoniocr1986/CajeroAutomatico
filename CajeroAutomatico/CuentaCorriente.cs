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
        public string Identificacion { get; set; }
        public int PIN { get; set; }
        public String[] Transferencias { get; set; }
        public int Contador { get; set; }

        public CuentaCorriente(double saldo, long numCuenta,string identificacion, int pin)
        {
            Saldo = saldo;
            NumCuenta = numCuenta;
            Identificacion = identificacion;
            PIN = pin;
            Transferencias = new string[5];
        }

        public CuentaCorriente()
        {

        }

        public double ConsultarSaldo()
        {
            return Saldo;
        }

        public void RetirarSaldo(double cantidad)
        {
            if (cantidad > 0)
            {
                Saldo -= cantidad;
            }  
        }

        public void IngresarSaldo( double cantidad)
        {
            Saldo += cantidad;
        }

        public long ConsultarNumCuenta()
        {
            return NumCuenta;
        }
    }
}

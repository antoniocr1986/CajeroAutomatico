using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class Usuario
    {
        string Nombre;
        long NumTarjeta;
        int PIN;

        public Usuario(string nombre, long numTarjeta, int pin)
        {
            Nombre = nombre;
            NumTarjeta = numTarjeta;
            PIN = pin;
        }

        public bool verificarUsuario(long numTarjeta, int pin)
        {
            if (numTarjeta == NumTarjeta && pin == PIN)
            {
                return true;
            }
            return false;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    public class Usuario
    {
        public string Nombre { get;set; }
        public long NumTarjeta { get; set; }
        public int PIN { get; set; }

        public Usuario(string nombre, long numTarjeta, int pin)
        {
            Nombre = nombre;
            NumTarjeta = numTarjeta;
            PIN = pin;
        }

        public bool VerificarUsuario(long numTarjeta, int pin)
        {
            return numTarjeta == NumTarjeta && pin == PIN;
        }
    }
}

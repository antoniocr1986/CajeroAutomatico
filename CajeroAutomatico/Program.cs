using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Usuario usuario = new Usuario("Antonio", "53313513L", 1755);
            CuentaCorriente cuenta = new CuentaCorriente(20000, 1234123412341234, usuario, 1755);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin formLogin1 = new FormLogin(usuario);
            formLogin1.Usuario = usuario;
            formLogin1.Cuenta = cuenta;
            Application.Run(formLogin1);

        }
    }
}

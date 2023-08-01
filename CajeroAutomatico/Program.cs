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
            Usuario usuario = new Usuario("Antonio", 1234, 12345678);
            CuentaCorriente cuenta = new CuentaCorriente(20000, 1234, usuario, 12345678);


            Usuario usuario2 = new Usuario("Mario", 0001000100010001, 123456);
            CuentaCorriente cuenta2 = new CuentaCorriente(50, 0001000100010001, usuario2, 123456);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin formLogin1 = new FormLogin();
            formLogin1.usuario = usuario;
            formLogin1.cuenta = cuenta;
            formLogin1.usuario2 = usuario2;
            formLogin1.cuenta2 = cuenta2;
            Application.Run(formLogin1);

        }
    }
}

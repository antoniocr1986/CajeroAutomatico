using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajeroAutomatico
{
    public partial class FormRetirar : Form
    {
        private CuentaCorriente Cuenta;

        public FormRetirar(CuentaCorriente cuenta)
        {
            InitializeComponent();
            Cuenta = cuenta;
        }

        private void buttonConfirmarRetiro_Click(object sender, EventArgs e)
        {
            double cantidadRetirar;
            cantidadRetirar = double.Parse(textBoxRetirar.Text);
            if (cantidadRetirar < Cuenta.consultarSaldo())
            {
                Cuenta.retirarSaldo(cantidadRetirar);
                MessageBox.Show("La cantidad retirada ha sido de " + cantidadRetirar + " y el saldo total de la cuenta es de " + Cuenta.consultarSaldo());
            }
            else
            {
                MessageBox.Show("La cantidad no se puede retirar porque es mas grande que el total del saldo de la cuenta." +
                    "\n\nTOTAL CUENTA: " + Cuenta.consultarSaldo());
            }
        }
    }
}

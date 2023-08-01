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
    public partial class FormCajero : Form
    {
        private Usuario usuario, usuario2;
        private CuentaCorriente cuenta, cuenta2;

        public FormCajero(Usuario usuario, CuentaCorriente cuenta)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.cuenta = cuenta;
        }

        private void FormCajero_Load(object sender, EventArgs e)
        {
        }

        private void buttonConsultaSaldo_Click(object sender, EventArgs e)
        {
            double saldoTotal = 0;
            MessageBox.Show("El saldo total de su cuenta es: " + saldoTotal);
        }

        private void buttonRetirarSaldo_Click(object sender, EventArgs e)
        {
            double retiro = 0;
            MessageBox.Show("El retiro: " + retiro + " ha sido extradido de su cuenta.");
        }

        private void buttonIngresarSaldo_Click(object sender, EventArgs e)
        {
            double saldo = 0;
            MessageBox.Show("El ingreso de " + saldo+" ha sido transferido a su cuenta.");
        }

        private void buttonVerNumCuenta_Click(object sender, EventArgs e)
        {
            double numCuenta = 0;
            MessageBox.Show("El numero de cuenta es "+numCuenta);
        }

        private void buttonTransferencias_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Las ultimas transferencias son: ");
        }

        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }
    }
}

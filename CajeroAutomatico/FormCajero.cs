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
        private Usuario usuario;
        private CuentaCorriente cuenta;

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
            double saldoTotal = cuenta.consultarSaldo();
            MessageBox.Show("El saldo total de su cuenta es: " + saldoTotal);
        }

        private void buttonRetirarSaldo_Click(object sender, EventArgs e)
        {
            FormRetirar retirar = new FormRetirar(cuenta);
            retirar.ShowDialog();
        }

        private void buttonIngresarSaldo_Click(object sender, EventArgs e)
        {
            FormIngresar ingresar = new FormIngresar(cuenta);
            ingresar.ShowDialog();  
        }

        private void buttonVerNumCuenta_Click(object sender, EventArgs e)
        {
            long numCuenta = 0;
            numCuenta = cuenta.consultarNumCuenta();
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

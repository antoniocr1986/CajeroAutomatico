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
        private Usuario usuario,usuario2;
        private CuentaCorriente cuenta,cuenta2;
        private Retiro retiro;

        public FormCajero(Usuario usuario, Usuario usuario2, CuentaCorriente cuenta,CuentaCorriente cuenta2, Retiro retiro)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.cuenta = cuenta;
            this.cuenta2 = cuenta2;
            this.usuario2 = usuario2;
            this.retiro = retiro;
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
            FormRetirar retirar = new FormRetirar(cuenta,retiro);
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

        private void FormCajero_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void buttonTransferencias_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Las ultimas transferencias son:\n" + cuenta.Transferencias[0]+"\n"+ cuenta.Transferencias[1] + "\n"+
                cuenta.Transferencias[2] + "\n"+ cuenta.Transferencias[3] + "\n"+ cuenta.Transferencias[4] + "\n");
        }

        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin formLogin = new FormLogin();
            formLogin.usuario = usuario;
            formLogin.cuenta = cuenta;
            formLogin.usuario2 = usuario2;
            formLogin.cuenta2 = cuenta2;
            formLogin.ShowDialog();
        }
    }
}

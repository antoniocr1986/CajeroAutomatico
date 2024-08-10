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
        private CuentaCorriente cuenta;
        private Retiro retiro;
        private readonly int maxRetirar = 1000;
        private readonly int numMaxRetiros = 10;

        public FormRetirar(CuentaCorriente cuenta,Retiro retiro)
        {
            InitializeComponent();
            this.cuenta = cuenta;
            this.retiro = retiro;
        }

        private void ButtonConfirmarRetiro_Click(object sender, EventArgs e)
        {
            double cantidadRetirar;
            double.TryParse(textBoxRetirar.Text, out cantidadRetirar);

            if (cantidadRetirar > cuenta.ConsultarSaldo())
            {
                MessageBox.Show($"La cantidad no se puede retirar porque es mas grande que el total del saldo de la cuenta." +
                    "\n\nTOTAL CUENTA: " +cuenta.ConsultarSaldo());
                return;
            }
            if (cantidadRetirar > maxRetirar)
            {
                MessageBox.Show($"La cantidad ha retirar no puede ser mas grande de: {maxRetirar} €");
                return;
            }

            if (DateTime.Now.Date != retiro.Fecha.Date)
            {
                retiro.RetirosHoyNum = 0;
            }

            if (retiro.RetirosHoyNum >= numMaxRetiros)
            {
                MessageBox.Show($"Has superado el maximo de retiros de hoy: {numMaxRetiros}");
                return;
            }
                
            if (cuenta.Contador < cuenta.Transferencias.Length)
            {
                cuenta.RetirarSaldo(cantidadRetirar);
                retiro.RetirosHoyNum++;
                MessageBox.Show($"La cantidad retirada ha sido de {cantidadRetirar} € y el saldo total de la cuenta es de {cuenta.ConsultarSaldo()} €");
                cuenta.Transferencias[cuenta.Contador] = $"Retiro: {cantidadRetirar} €";
                cuenta.Contador++;
            }
            else
            {
                cuenta.Contador = 0;
                this.ButtonConfirmarRetiro_Click(sender, e);
            }         
        }
    }
}

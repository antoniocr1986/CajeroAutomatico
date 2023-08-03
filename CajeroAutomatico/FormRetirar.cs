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
        private Retiro Retiro;

        public FormRetirar(CuentaCorriente cuenta,Retiro retiro)
        {
            InitializeComponent();
            Cuenta = cuenta;
            Retiro = retiro;
        }

        private void buttonConfirmarRetiro_Click(object sender, EventArgs e)
        {
            double cantidadRetirar;
            cantidadRetirar = double.Parse(textBoxRetirar.Text);

            if (cantidadRetirar < Cuenta.consultarSaldo())
            {
                if (cantidadRetirar > 1000)
                {
                    MessageBox.Show("La cantidad ha retirar no puede ser mas grande de 1000 €");
                }
                else
                {
                    if (DateTime.Now.Date != Retiro.Fecha)
                    {
                        Retiro.RetirosHoyNum = 0;
                    }
                    if (Retiro.RetirosHoyNum >= 10)
                    {
                        MessageBox.Show("Has superado el maximo de retiros de hoy: 10");
                    }
                    else
                    {
                        if (Cuenta.Contador < 5)
                        {
                            Cuenta.retirarSaldo(cantidadRetirar);
                            Retiro.RetirosHoyNum++;
                            MessageBox.Show("La cantidad retirada ha sido de " + cantidadRetirar + " € y el saldo total de la cuenta es de " + Cuenta.consultarSaldo()+" €");
                            Cuenta.Transferencias[Cuenta.Contador] = "Retiro: " + cantidadRetirar+" €";
                            Cuenta.Contador++;
                        }
                        else
                        {
                            Cuenta.Contador = 0;
                            Cuenta.retirarSaldo(cantidadRetirar);
                            Retiro.RetirosHoyNum++;
                            MessageBox.Show("La cantidad retirada ha sido de " + cantidadRetirar + " € y el saldo total de la cuenta es de " + Cuenta.consultarSaldo() + " €");
                            Cuenta.Transferencias[Cuenta.Contador] = "Retiro: " + cantidadRetirar+ " €";
                            Cuenta.Contador++;
                        }
                    }                 
                }
            }
            else
            {
                MessageBox.Show("La cantidad no se puede retirar porque es mas grande que el total del saldo de la cuenta." +
                    "\n\nTOTAL CUENTA: " + Cuenta.consultarSaldo());
            }
        }

        private void FormRetirar_Load(object sender, EventArgs e)
        {

        }
    }
}

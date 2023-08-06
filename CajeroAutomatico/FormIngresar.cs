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
    public partial class FormIngresar : Form
    {

        private CuentaCorriente Cuenta;

        public FormIngresar(CuentaCorriente cuenta)
        {
            InitializeComponent();
            Cuenta = cuenta;    
        }

        private void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            if (Cuenta.Contador < Cuenta.Transferencias.Length)
            {
                double cantidadIngresar;
                cantidadIngresar = double.Parse(textBoxIngresar.Text);
                Cuenta.ingresarSaldo(cantidadIngresar);
                MessageBox.Show("La cantidad ingresada ha sido de " + cantidadIngresar + " € y el saldo total de la cuenta es de " + Cuenta.consultarSaldo()+ " €");
                Cuenta.Transferencias[Cuenta.Contador] = "Ingreso: " + cantidadIngresar+ " €";
                Cuenta.Contador++;
            }
            else
            {
                Cuenta.Contador = 0;
                double cantidadIngresar;
                cantidadIngresar = double.Parse(textBoxIngresar.Text);
                Cuenta.ingresarSaldo(cantidadIngresar);
                MessageBox.Show("La cantidad ingresada ha sido de " + cantidadIngresar + " € y el saldo total de la cuenta es de " + Cuenta.consultarSaldo()+" €");
                Cuenta.Transferencias[Cuenta.Contador] = "Ingreso: " + cantidadIngresar+ " €";
                Cuenta.Contador++;
            }
        }
    }
}

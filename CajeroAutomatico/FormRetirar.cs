﻿using System;
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

        public FormRetirar(CuentaCorriente cuenta,Retiro retiro)
        {
            InitializeComponent();
            this.cuenta = cuenta;
            this.retiro = retiro;
        }

        private void buttonConfirmarRetiro_Click(object sender, EventArgs e)
        {
            double.TryParse(textBoxRetirar.Text, out double cantidadRetirar);

            if (cantidadRetirar > cuenta.consultarSaldo())
            {
                MessageBox.Show("La cantidad no se puede retirar porque es mas grande que el total del saldo de la cuenta." +
                    "\n\nTOTAL CUENTA: " + cuenta.consultarSaldo());
                return;
            }
            if (cantidadRetirar > 1000)
            {
                MessageBox.Show("La cantidad ha retirar no puede ser mas grande de 1000 €");
                return;
            }

            if (DateTime.Now.Date != retiro.Fecha)
            {
                retiro.RetirosHoyNum = 0;
            }

            if (retiro.RetirosHoyNum >= 10)
            {
                MessageBox.Show("Has superado el maximo de retiros de hoy: 10");
                return;
            }
                
            if (cuenta.Contador < 5)
            {
                cuenta.retirarSaldo(cantidadRetirar);
                retiro.RetirosHoyNum++;
                MessageBox.Show("La cantidad retirada ha sido de " + cantidadRetirar + " € y el saldo total de la cuenta es de " + cuenta.consultarSaldo() + " €");
                cuenta.Transferencias[cuenta.Contador] = "Retiro: " + cantidadRetirar + " €";
                cuenta.Contador++;
            }
            else
            {
                cuenta.Contador = 0;
                cuenta.retirarSaldo(cantidadRetirar);
                retiro.RetirosHoyNum++;
                MessageBox.Show("La cantidad retirada ha sido de " + cantidadRetirar + " € y el saldo total de la cuenta es de " + cuenta.consultarSaldo() + " €");
                cuenta.Transferencias[cuenta.Contador] = "Retiro: " + cantidadRetirar + " €";
                cuenta.Contador++;
            }         
        }
    }
}

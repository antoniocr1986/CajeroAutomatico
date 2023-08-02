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
    public partial class FormIngresar : Form
    {

        private CuentaCorriente Cuenta;

        public FormIngresar(CuentaCorriente cuenta)
        {
            InitializeComponent();
            Cuenta = cuenta;    
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            double cantidadIngresar;
            cantidadIngresar = double.Parse(textBoxIngresar.Text);
            Cuenta.ingresarSaldo(cantidadIngresar);
            MessageBox.Show("La cantidad ingresada ha sido de " + cantidadIngresar + " y el saldo total de la cuenta es de " + Cuenta.consultarSaldo());
        }
    }
}
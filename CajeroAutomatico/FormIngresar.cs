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
        BdDML bdDMl = new BdDML();

        private CuentaCorriente Cuenta;

        private double CuentaSaldo;
        private long NumCuenta;
        private string CuentaUsuario;
        private int CuentaPin;
        private string CuentaIdentificacion;
        private int CuentaContador;

        public FormIngresar(double cuentaSaldo, long cuentaNumCuenta, string cuentaUsuario, int cuentaPin, string cuentaIdentificacion, int cuentaContador)
        {
            InitializeComponent();

            CuentaSaldo = cuentaSaldo;
            NumCuenta = cuentaNumCuenta;
            CuentaUsuario = cuentaUsuario;
            CuentaPin = cuentaPin;
            CuentaIdentificacion = cuentaIdentificacion;
            CuentaContador = cuentaContador;
        }

        private void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            double cantidadIngresar;
            cantidadIngresar = double.Parse(textBoxIngresar.Text);

            if (cantidadIngresar == 0)
            {
                MessageBox.Show($"La cantidad ingresada no puede ser de 0 €");
            }

            else if (CuentaContador < Cuenta.Transferencias.Length)
            {            
                Cuenta.IngresarSaldo(cantidadIngresar);
                MessageBox.Show($"La cantidad ingresada ha sido de {cantidadIngresar} € y el saldo total de la cuenta es de {Cuenta.ConsultarSaldo()} €");
                Cuenta.Transferencias[CuentaContador] = $"Ingreso: {cantidadIngresar} €";
                CuentaContador++;
            }
            else
            {
                CuentaContador = 0;
                this.ButtonConfirmar_Click(sender,e);
            }
        }

        private void textBoxIngresar_TextChanged(object sender, EventArgs e)
        {
            // Reemplazar todos los puntos por comas en el texto del TextBox
            textBoxIngresar.Text = textBoxIngresar.Text.Replace('.', ',');

            // Establecer la posición del cursor al final del texto
            textBoxIngresar.SelectionStart = textBoxIngresar.Text.Length;
            textBoxIngresar.SelectionLength = 0;
        }
    }
}

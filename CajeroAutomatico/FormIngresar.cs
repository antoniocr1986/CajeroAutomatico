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
        private string[] CuentaTransferencias;

        public FormIngresar(double cuentaSaldo, long cuentaNumCuenta, string cuentaUsuario, int cuentaPin, string cuentaIdentificacion, int cuentaContador, string[] cuentaTrasnferencias)
        {
            InitializeComponent();

            CuentaSaldo = cuentaSaldo;
            NumCuenta = cuentaNumCuenta;
            CuentaUsuario = cuentaUsuario;
            CuentaPin = cuentaPin;
            CuentaIdentificacion = cuentaIdentificacion;
            CuentaContador = cuentaContador;
            CuentaTransferencias = cuentaTrasnferencias;
        }

        private void ButtonConfirmar_Click(object sender, EventArgs e)
        {
            float cantidadIngresar;
            cantidadIngresar = float.Parse(textBoxIngresar.Text);

            if (cantidadIngresar == 0)
            {
                MessageBox.Show($"La cantidad ingresada no puede ser de 0 €");
            }

            else if (CuentaContador < CuentaTransferencias.Length)
            {
                bdDMl.IngresarSaldo(cantidadIngresar, CuentaIdentificacion);
                CuentaSaldo = bdDMl.ConsultaSaldo(CuentaIdentificacion);
                MessageBox.Show($"La cantidad ingresada ha sido de {cantidadIngresar} € y el saldo total de la cuenta es de {CuentaSaldo} €");
                CuentaTransferencias[CuentaContador] = $"Ingreso: {cantidadIngresar} €";
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

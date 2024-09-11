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
        BdDML bdDMl = new BdDML();

        private CuentaCorriente cuenta;
        private double CuentaSaldo;
        private long NumCuenta;
        private string CuentaUsuario;
        private int CuentaPin;
        private string CuentaIdentificacion;
        private int CuentaContador;

        private Retiro retiro;
        private readonly int maxRetirar = 1000;
        private readonly int numMaxRetiros = 10;

        public FormRetirar(double cuentaSaldo, string cuentaIdentificacion,Retiro retiro)
        {
            InitializeComponent();
            CuentaSaldo = cuentaSaldo;
            CuentaIdentificacion = cuentaIdentificacion;
            this.retiro = retiro;
        }

        private void ButtonConfirmarRetiro_Click(object sender, EventArgs e)
        {
            float cantidadRetirar;
            float.TryParse(textBoxRetirar.Text, out cantidadRetirar);

            CuentaSaldo = bdDMl.ConsultaSaldo(CuentaIdentificacion);
            
            if (cantidadRetirar == 0)
            {
                MessageBox.Show($"Indique un valor mayor que 0 para retirar saldo de la cuenta." +
                    "\n\nTOTAL CUENTA: " + CuentaSaldo);
                return;
            }

            if (cantidadRetirar > bdDMl.ConsultaSaldo(CuentaIdentificacion))
            {
                MessageBox.Show($"La cantidad no se puede retirar porque es mas grande que el total del saldo de la cuenta." +
                    "\n\nTOTAL CUENTA: " + CuentaSaldo);
                return;
            }
            if (cantidadRetirar > maxRetirar)
            {
                MessageBox.Show($"La cantidad ha retirar no puede ser mas grande de: {maxRetirar} €");
                return;
            }

            //Para controlar que los retiros de hoy se pongan a 0 cuando la fecha sea un nuevo dia
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
                bdDMl.RetirarSaldo(cantidadRetirar, CuentaIdentificacion);
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

        private void textBoxRetirar_TextChanged(object sender, EventArgs e)
        {
            // Reemplazar todos los puntos por comas en el texto del TextBox
            textBoxRetirar.Text = textBoxRetirar.Text.Replace('.', ',');

            // Establecer la posición del cursor al final del texto
            textBoxRetirar.SelectionStart = textBoxRetirar.Text.Length;
            textBoxRetirar.SelectionLength = 0;
        }
    }
}

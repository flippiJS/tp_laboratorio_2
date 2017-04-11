using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lippi.Franco.TP01
{
    public partial class Form1 : Form
    {

        Numero NumeroA, NumeroB;

        public Form1()
        {
            InitializeComponent();
        }

        #region Eventos

        // Completa el checkbox al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbOperacion.Items.Add("+");

            cmbOperacion.Items.Add("-");

            cmbOperacion.Items.Add("*");

            cmbOperacion.Items.Add("/");

            cmbOperacion.Text = "+";
        }

        // Obtiene los numeros String, valida numeros y operador, e inteta realizar la operacion
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double salida,auxiliar;

            string operador;

            NumeroA = new Numero(txtNumero1.Text);

            NumeroB = new Numero(txtNumero2.Text);

            operador = Calculadora.validaOperador(cmbOperacion.Text);

            auxiliar = Calculadora.operar(NumeroA, NumeroB, operador);

            lblResultado.Text = auxiliar.ToString();

            // Si no puede parsear el numero, deuvelve 0
            if (!double.TryParse(txtNumero1.Text, out salida))
                txtNumero1.Text = "0";

            // Si no puede parsear el numero, deuvelve 0
            if (!double.TryParse(txtNumero2.Text, out salida))
                txtNumero2.Text = "0";

            if (operador.Equals("/")) // Es division
                if (NumeroB.getNumero() == 0) // Divide por 0
                    lblResultado.Text = "No es posible dividir por 0"; // Error 

            if (operador.Equals("+"))
                cmbOperacion.Text = operador;

        }

        // Reinicializa a los valores por defecto
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbOperacion.Text = "+"; // Operador

            txtNumero1.Text = "0"; // Numero 1

            txtNumero2.Text = "0"; // Numero 2

            lblResultado.Text = "0"; // Resultado
        }

        #endregion
    }
}

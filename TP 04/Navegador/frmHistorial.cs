using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        #region Atributos

        public List<string> historialLista;
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        #endregion

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            this.historialLista = new List<string>();

            archivos.leer(out historialLista);

            lstHistorial.DataSource = historialLista;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formProdutosSplash : Form
    {
        formProdutosUtensilios formpai;
        public formProdutosSplash()
        {
            InitializeComponent();
        }
        public formProdutosSplash(formProdutosUtensilios pai)
        {
            InitializeComponent();
            formpai = pai;
        }
        private void formProdutosUtensilios_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
        }

        private void timerEntrada_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                timerEntrada.Stop();
                //timerSaída.Enabled = true;
            }
            else
            {
                this.Opacity = this.Opacity + 0.03;
            }
        }

        private void timerSaída_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 0) //SE A TELA DE SPLASH DESAPARECER...
            {
                timerSaída.Stop();
                this.Dispose();
                //formUsuario fu = new formUsuario();
                //fu.Show();
            }
            else
            {
                
                this.Opacity = this.Opacity - 0.03;
            }
        }

        private void timerProgresso_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(5);
            if (progressBar1.Value == 100)
            {
                timerProgresso.Stop();
                this.Dispose();
                formpai.panelCentral.Controls.Clear();
                formpai.panelCentral.Controls.Add(formpai.dataGridViewUtensilios);
                formpai.dataGridViewUtensilios.Visible = true;                
            }
        }
    }
}

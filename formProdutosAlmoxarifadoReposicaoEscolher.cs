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
    public partial class formProdutosAlmoxarifadoReposicaoEscolher : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<string> Lista = new List<string>();
        public formProdutosAlmoxarifadoReposicaoEscolher()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }
        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }
        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion

        private void formProdutosAlmoxarifadoReposicaoEscolher_Load(object sender, EventArgs e)
        {
            Lista = comandos.ReposicoesDoAlmoxarifadoEmAberto();
            foreach (string x in Lista) { ReposicaoComboBox.Items.Add(x); }
        }

        private void carregarButton_Click(object sender, EventArgs e)
        {
            string ID = ReposicaoComboBox.Text;
            if (ID == string.Empty)
            {
                MessageBox.Show("Informe o número da reposição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int id = Convert.ToInt32(ID);
                formProdutosAlmoxarifadoConfirmarReposicao confirmar = new formProdutosAlmoxarifadoConfirmarReposicao(id);
                confirmar.ShowDialog();
                Dispose();
            }
        }
    }
}

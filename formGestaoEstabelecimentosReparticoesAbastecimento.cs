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
    public partial class formGestaoEstabelecimentosReparticoesAbastecimento : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formGestaoEstabelecimentosReparticoesAbastecimento()
        {
            InitializeComponent();
        }

        private void formGestaoEstabelecimentosReparticoesAbastecimento_Load(object sender, EventArgs e)
        {
            List<string> estabelecimentos = comandos.PreencherComboEstabelecimentosParaAbastecimento();
            foreach (string x in estabelecimentos) { comboBoxEstabelecimento.Items.Add(x); }
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

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void comboBoxEstabelecimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxReparticao.Items.Clear();
            string estabelecimento = comboBoxEstabelecimento.Text;
            List<string> reparticoes = comandos.PreencherComboReparticoesParaAbastecimento(estabelecimento);
            foreach (string x in reparticoes) { comboBoxReparticao.Items.Add(x); }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string estabelecimento = comboBoxEstabelecimento.Text;
            string reparticao = comboBoxReparticao.Text;

            if (estabelecimento == string.Empty)
            {
                MessageBox.Show("Informe o estabelecimento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (reparticao == string.Empty)
            {
                MessageBox.Show("Informe a reparticação para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool reposicao_local = comandos.VerificarReposicaoLocal(reparticao);
                string texto;

                if (reposicao_local)
                {
                    texto = "O sistema identificou que a reposição será feita do estoque para a loja.\r\n Deseja continuar?";
                }
                else
                {
                    texto = "O sistema identificou que a reposição será feita\r\ndo centro de distribuição para o estoque.\r\n Deseja continuar?";
                }

                if (DialogResult.Yes == MessageBox.Show(texto, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    int id_reparticao;

                    try { string[] partir = reparticao.Split('.'); id_reparticao = Convert.ToInt32(partir[0]); }
                    catch { id_reparticao = 0; }

                    if (reposicao_local)
                    {
                        comandos.LancarReposicaoLocal(id_reparticao, estabelecimento);
                    }
                    else
                    {
                        comandos.LancarAbastecimento(id_reparticao);
                    }

                    Dispose();
                }
            }
        }
    }
}

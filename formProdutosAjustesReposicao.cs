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
    public partial class formProdutosAjustesReposicao : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Reposicao Reposicao_Loja = new Reposicao();
        Reposicao Reposicao_Estoque = new Reposicao();
        public formProdutosAjustesReposicao()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void formProdutosAjustesReposicao_Load(object sender, EventArgs e)
        {
            List<Colaborador> colaboradores = comandos.PreencherComboColaboradores();
            respLojaComboBox.ValueMember = "ID_Colaborador";
            respLojaComboBox.DisplayMember = "Nome_Colaborador";
            respLojaComboBox.DataSource = colaboradores;

            respLojaComboBox.SelectedIndex = -1;

            respEstoqueComboBox.ValueMember = "ID_Colaborador";
            respEstoqueComboBox.DisplayMember = "Nome_Colaborador";
            respEstoqueComboBox.DataSource = colaboradores;

            respEstoqueComboBox.SelectedIndex = -1;

            Reposicao_Loja = comandos.InformacoesDaReposicao("Loja");
            Reposicao_Estoque = comandos.InformacoesDaReposicao("Estoque");

            primeiraLojaTextBox.Text = Reposicao_Loja.Primeira.ToShortTimeString();
            ultimaLojaTextBox.Text = Reposicao_Loja.Ultima.ToShortTimeString();
            intervaloLojaTextBox.Text = Reposicao_Loja.Intervalo.ToString();
            respLojaComboBox.Text = Reposicao_Loja.Responsavel;
            lojaDateTime.Text = Reposicao_Loja.Proxima.ToShortDateString();
            proximaLojaTextBox.Text = Reposicao_Loja.Proxima.ToShortTimeString();

            primeiraEstoqueTextBox.Text = Reposicao_Estoque.Primeira.ToShortTimeString();
            ultimaEstoqueTextBox.Text = Reposicao_Estoque.Ultima.ToShortTimeString();
            intervaloEstoqueTextBox.Text = Reposicao_Estoque.Intervalo.ToString();
            respEstoqueComboBox.Text = Reposicao_Estoque.Responsavel;
            estoqueDateTime.Text = Reposicao_Estoque.Proxima.ToShortDateString();
            proximaEstoqueTextBox.Text = Reposicao_Estoque.Proxima.ToShortTimeString();
        }

        private void intervaloLojaTextBox_Enter(object sender, EventArgs e)
        {
            if (intervaloLojaTextBox.Text == "0") { intervaloLojaTextBox.Text = string.Empty; }
        }

        private void intervaloLojaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void intervaloLojaTextBox_Leave(object sender, EventArgs e)
        {
            if (intervaloLojaTextBox.Text == string.Empty) { intervaloLojaTextBox.Text = "0"; }
        }

        private void intervaloEstoqueTextBox_Enter(object sender, EventArgs e)
        {
            if (intervaloEstoqueTextBox.Text == "0") { intervaloEstoqueTextBox.Text = string.Empty; }
        }

        private void intervaloEstoqueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void intervaloEstoqueTextBox_Leave(object sender, EventArgs e)
        {
            if (intervaloEstoqueTextBox.Text == string.Empty) { intervaloEstoqueTextBox.Text = "0"; }
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

        private void buttonBalanco_Click(object sender, EventArgs e)
        {
            if (primeiraLojaTextBox.Text == ":  " || primeiraLojaTextBox.Text.Length < 5)
            {
                MessageBox.Show("Preencha o horário da primeira reposição da loja corretamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (primeiraLojaTextBox.Text == ":  " || primeiraLojaTextBox.Text.Length < 5)
            {
                MessageBox.Show("Preencha o horário da última reposição da loja corretamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (proximaLojaTextBox.Text == ":  " || proximaLojaTextBox.Text.Length < 5)
            {
                MessageBox.Show("Preencha o horário da próxima reposição da loja corretamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToDateTime(lojaDateTime.Text + " " + proximaLojaTextBox.Text) < DateTime.Now)
            {
                MessageBox.Show("Não é possível definir uma hora que já passou para a próxima reposição da loja!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (intervaloLojaTextBox.Text == "0")
            {
                MessageBox.Show("Não é possível atribuir 0 minutos como intervalo de reposição da loja!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (primeiraEstoqueTextBox.Text == ":  " || primeiraEstoqueTextBox.Text.Length < 5)
            {
                MessageBox.Show("Preencha o horário da primeira reposição do estoque corretamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (primeiraEstoqueTextBox.Text == ":  " || primeiraEstoqueTextBox.Text.Length < 5)
            {
                MessageBox.Show("Preencha o horário da última reposição do estoque corretamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (proximaEstoqueTextBox.Text == ":  " || proximaEstoqueTextBox.Text.Length < 5)
            {
                MessageBox.Show("Preencha o horário da próxima reposição do estoque corretamente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToDateTime(estoqueDateTime.Text + " " + proximaEstoqueTextBox.Text) < DateTime.Now)
            {
                MessageBox.Show("Não é possível definir uma hora que já passou para a próxima reposição do estoque!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (intervaloEstoqueTextBox.Text == "0")
            {
                MessageBox.Show("Não é possível atribuir 0 minutos como intervalo de reposição do estoque", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Alterar essas informações deve interferir nas reposições automáticas. Tem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    Reposicao_Loja.Proxima = Convert.ToDateTime(lojaDateTime.Text + " " + proximaLojaTextBox.Text);
                    Reposicao_Loja.Intervalo = Convert.ToInt32(intervaloLojaTextBox.Text);
                    Reposicao_Loja.Primeira = Convert.ToDateTime(primeiraLojaTextBox.Text);
                    Reposicao_Loja.Ultima = Convert.ToDateTime(ultimaLojaTextBox.Text);
                    string[] partir_loja = respLojaComboBox.Text.Split(' ');
                    Reposicao_Loja.ID_Responsavel = Convert.ToInt32(partir_loja[0]);

                    Reposicao_Estoque.Proxima = Convert.ToDateTime(estoqueDateTime.Text + " " + proximaEstoqueTextBox.Text);
                    Reposicao_Estoque.Intervalo = Convert.ToInt32(intervaloEstoqueTextBox.Text);
                    Reposicao_Estoque.Primeira = Convert.ToDateTime(primeiraEstoqueTextBox.Text);
                    Reposicao_Estoque.Ultima = Convert.ToDateTime(ultimaEstoqueTextBox.Text);
                    string[] partir_estoque = respEstoqueComboBox.Text.Split(' ');
                    Reposicao_Estoque.ID_Responsavel = Convert.ToInt32(partir_estoque[0]);

                    comandos.EditarParametrosDasReposicoes(Reposicao_Loja, Reposicao_Estoque);
                    Dispose();
                }
            }
        }
    }
}

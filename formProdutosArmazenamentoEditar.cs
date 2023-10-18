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
    public partial class formProdutosArmazenamentoEditar : Form
    {
        formProdutosAjustesArmazenamento pai = new formProdutosAjustesArmazenamento();
        ComandosSQL comandos = new ComandosSQL();
        Produto Produto = new Produto();
        int id_produto;
        public formProdutosArmazenamentoEditar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formProdutosArmazenamentoEditar(int ID_Produto, formProdutosAjustesArmazenamento Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_produto = ID_Produto;
            pai = Pai;
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
        #region Formatação
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void cmrLojaTextBox_Enter(object sender, EventArgs e)
        {
            if (cmrLojaTextBox.Text == "0") { cmrLojaTextBox.Text = string.Empty; }
        }
        private void cmrLojaTextBox_Leave(object sender, EventArgs e)
        {
            if (cmrLojaTextBox.Text == string.Empty) { cmrLojaTextBox.Text = 0.ToString(); }
        }
        private void cmrEstoqueTextBox_Enter(object sender, EventArgs e)
        {
            if (cmrEstoqueTextBox.Text == "0") { cmrEstoqueTextBox.Text = string.Empty; }
        }
        private void cmrEstoqueTextBox_Leave(object sender, EventArgs e)
        {
            if (cmrEstoqueTextBox.Text == string.Empty) { cmrEstoqueTextBox.Text = 0.ToString(); }
        }
        private void idealLojaTextBox_Enter(object sender, EventArgs e)
        {
            if (idealLojaTextBox.Text == "0") { idealLojaTextBox.Text = string.Empty; }
        }
        private void idealLojaTextBox_Leave(object sender, EventArgs e)
        {
            if (idealLojaTextBox.Text == string.Empty) { idealLojaTextBox.Text = 0.ToString(); }
        }
        private void idealEstoqueTextBox_Enter(object sender, EventArgs e)
        {
            if (idealEstoqueTextBox.Text == "0") { idealEstoqueTextBox.Text = string.Empty; }
        }
        private void idealEstoqueTextBox_Leave(object sender, EventArgs e)
        {
            if (idealEstoqueTextBox.Text == string.Empty) { idealEstoqueTextBox.Text = 0.ToString(); }
        }
        private void idealDepositoTextBox_Enter(object sender, EventArgs e)
        {
            if (idealDepositoTextBox.Text == "0") { idealDepositoTextBox.Text = string.Empty; }
        }
        private void idealDepositoTextBox_Leave(object sender, EventArgs e)
        {
            if (idealDepositoTextBox.Text == string.Empty) { idealDepositoTextBox.Text = 0.ToString(); }
        }
        #endregion

        private void formProdutosArmazenamentoEditar_Load(object sender, EventArgs e)
        {
            List<string> prateleiras_loja = comandos.TrazerPrateleirasPorSetor("LOJA");
            foreach (string prateleira in prateleiras_loja) { lojaComboBox.Items.Add(prateleira); }
            List<string> prateleiras_estoque = comandos.TrazerPrateleirasPorSetor("ESTOQUE");
            foreach (string prateleira in prateleiras_estoque) { estoqueComboBox.Items.Add(prateleira); }
            List<string> prateleiras_deposito = comandos.TrazerPrateleirasPorSetor("DEPÓSITO");
            foreach (string prateleira in prateleiras_deposito) { depositoComboBox.Items.Add(prateleira); }

            lojaComboBox.DropDownHeight = 120;
            estoqueComboBox.DropDownHeight = 120;
            depositoComboBox.DropDownHeight = 120;

            Produto = comandos.InformacoesDeArmazenamentoDoProduto(id_produto);

            produtoTextBox.Text = Produto.Nome_Produto;
            caixaTextBox.Text = Produto.qtd_Caixa.ToString();
            cmrLojaTextBox.Text = Produto.CMR_Loja.ToString();
            cmrEstoqueTextBox.Text = Produto.CMR_Estoque.ToString();
            atualLojaTextBox.Text = Produto.qtd_Prateleira.ToString();
            atualEstoqueTextBox.Text = Produto.qtd_Deposito1.ToString();
            atualDepositoTextBox.Text = Produto.qtd_Deposito2.ToString();
            idealLojaTextBox.Text = Produto.Ideal_Loja.ToString();
            idealEstoqueTextBox.Text = Produto.Ideal_Estoque.ToString();
            idealDepositoTextBox.Text = Produto.Ideal_Deposito.ToString();

            if (Produto.Local_Loja != string.Empty)
            {
                lojaComboBox.Text = Produto.Local_Loja;
            }
            else { lojaComboBox.SelectedIndex = -1; }

            if (Produto.Local_Estoque != string.Empty)
            {
                estoqueComboBox.Text = Produto.Local_Estoque;
            }
            else { estoqueComboBox.SelectedIndex = -1; }

            if (Produto.Local_Deposito != string.Empty)
            {
                depositoComboBox.Text = Produto.Local_Deposito;
            }
            else { depositoComboBox.SelectedIndex = -1; }
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Produto Produto = new Produto();
            Produto.ID_Produto = id_produto;
            Produto.CMR_Loja = Convert.ToInt32(cmrLojaTextBox.Text);
            Produto.CMR_Estoque= Convert.ToInt32(cmrEstoqueTextBox.Text);
            Produto.Ideal_Loja= Convert.ToInt32(idealLojaTextBox.Text);
            Produto.Ideal_Estoque= Convert.ToInt32(idealEstoqueTextBox.Text);
            Produto.Ideal_Deposito= Convert.ToInt32(idealDepositoTextBox.Text);
            Produto.Local_Loja = lojaComboBox.Text;
            Produto.Local_Estoque = estoqueComboBox.Text;
            Produto.Local_Deposito = depositoComboBox.Text;
            bool permitir = true;

            if (Produto.CMR_Loja == 0)
            {
                if (DialogResult.No == MessageBox.Show("A Carga Mínima de Reposição (CMR) da loja consta como 0.\r\nIsso fará com que as reposições das prateleiras não ocorram de forma adequada.\r\nSe você continuar, uma notificação será enviada à gestão.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    permitir = false;
                }
            }
            if (Produto.CMR_Estoque == 0)
            {
                if (DialogResult.No == MessageBox.Show("A Carga Mínima de Reposição (CMR) do estoque consta como 0.\r\nIsso fará com que as reposições das prateleiras não ocorram de forma adequada.\r\nSe você continuar, uma notificação será enviada à gestão.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    permitir = false;
                }
            }
            if (Produto.Ideal_Loja == 0)
            {
                if (DialogResult.No == MessageBox.Show("A Quantidade ideal da loja consta como 0.\r\nIsso fará com que as reposições das prateleiras não ocorram de forma adequada.\r\nSe você continuar, uma notificação será enviada à gestão.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    permitir = false;
                }
            }
            if (Produto.Ideal_Estoque == 0)
            {
                if (DialogResult.No == MessageBox.Show("A Quantidade ideal do estoque consta como 0.\r\nIsso fará com que as reposições das prateleiras não ocorram de forma adequada.\r\nSe você continuar, uma notificação será enviada à gestão.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    permitir = false;
                }
            }

            if (Produto.Local_Loja == string.Empty)
            {
                if (DialogResult.No == MessageBox.Show("O produto não tem uma definição de localização na loja.\r\nIsso fará com que as reposições das prateleiras não ocorram de forma adequada.\r\nSe você continuar, uma notificação será enviada à gestão.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    permitir = false;
                }
            }
            if (Produto.Local_Estoque == string.Empty)
            {
                if (DialogResult.No == MessageBox.Show("O produto não tem uma definição de localização no estoque.\r\nIsso fará com que as reposições das prateleiras não ocorram de forma adequada.\r\nSe você continuar, uma notificação será enviada à gestão.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    permitir = false;
                }
            }

            if (permitir)
            {
                comandos.EditarInformacoesDeArmazenamento(Produto);
                pai.alteracao = true;
                Dispose();
            }
        }
    }
}

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
    public partial class formProdutosAlmoxarifadoEditar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formProdutosAlmoxarifado pai = new formProdutosAlmoxarifado();
        Almoxarifado Item = new Almoxarifado();
        bool novo_item;
        string item;
        int id_item;

        public formProdutosAlmoxarifadoEditar(formProdutosAlmoxarifado Pai, bool Novo_item)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
            novo_item = Novo_item;
        }
        public formProdutosAlmoxarifadoEditar(int ID_Item, formProdutosAlmoxarifado Pai, bool Novo_item)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_item = ID_Item;
            novo_item = Novo_item;
            pai = Pai;
        }

        private void formProdutosAlmoxarifadoEditar_Load(object sender, EventArgs e)
        {
            List<string> categorias = comandos.ListaDeCategoriasDoAlmoxarifado();
            foreach (string categoria in categorias) { comboBoxCategoria.Items.Add(categoria); }

            if (!novo_item)
            {
                Item = comandos.TrazerInformacoesDoItem(id_item);

                item = Item.Item;
                itemTextBox.Text = item;
                comboBoxCategoria.SelectedItem = Item.Categoria;
                checkBoxRestricao.Checked = Item.Restricao;
                idealTextBox.Text = Item.Estoque_Ideal.ToString();
                minimoTextBox.Text = Item.Estoque_Minimo.ToString();
                custoTextBox.Text = Item.Custo.ToString("C");
                atualTextBox.Text = Item.Estoque_Atual.ToString();
                periodoTextBox.Text = Item.Periodo_Reposicao.ToString();
                dateTimePicker.Value = Item.Proxima_Reposicao;
                if (Item.Status == "Ativo") { ativoCheckBox.Checked = true; }
                else { ativoCheckBox.Checked = false; }
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string item = itemTextBox.Text;
            int minimo = Convert.ToInt32(minimoTextBox.Text);
            int ideal = Convert.ToInt32(idealTextBox.Text);
            int atual = Convert.ToInt32(atualTextBox.Text);
            int periodo = Convert.ToInt32(periodoTextBox.Text);
            string categoria = comboBoxCategoria.Text;
            DateTime proxima = dateTimePicker.Value;
            string[] partir = custoTextBox.Text.Split('$');
            decimal custo = Convert.ToDecimal(partir[1]);
            string status;
            if (ativoCheckBox.Checked) { status = "Ativo"; }
            else { status = "Inativo"; }

            if (item == string.Empty)
            {
                MessageBox.Show("Informe o nome do item para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (item != this.item && comandos.VerificarSeItemDoAlmoxarifadoJaExiste(item))
            {
                MessageBox.Show("Já existe um item do almoxarifado com esse nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (categoria == string.Empty)
            {
                MessageBox.Show("Informe a categoria do item para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (minimo == 0 || ideal == 0)
            {
                MessageBox.Show("As quantidades de estoque mínimo e ideal não podem ser 0.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (periodo == 0)
            {
                MessageBox.Show("O período de reposição não pode ser de 0 dias.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (proxima.Date < DateTime.Now)
            {
                MessageBox.Show("Não é possível atribuir uma data que já passou para a próxima reposição!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Item.ID_Almoxarifado = id_item;
                Item.Item = item;
                Item.Estoque_Minimo = minimo;
                Item.Estoque_Ideal = ideal;
                Item.Estoque_Atual = atual;
                Item.Periodo_Reposicao = periodo;
                Item.Proxima_Reposicao = proxima;
                Item.Categoria = categoria;
                Item.Custo = custo;
                Item.Status = status;

                if (novo_item)
                {
                    comandos.CadastrarItemDoAlmoxarifado(Item);
                }
                else
                {
                    comandos.EditarItemDoAlmoxarifado(Item);
                }

                Dispose();
                pai.alteracao = true;
            }
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

        #region Formatação de Texto

        private void idealTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void idealTextBox_Leave(object sender, EventArgs e)
        {
            if (idealTextBox.Text == string.Empty)
                idealTextBox.Text = "0";
        }
        private void idealTextBox_Enter(object sender, EventArgs e)
        {
            if (idealTextBox.Text == "0") { idealTextBox.Clear(); }
        }
        private void custoTextBox_Enter(object sender, EventArgs e)
        {
            if (custoTextBox.Text == "R$0,00")
            {
                custoTextBox.Text = string.Empty;
            }
            else
            {
                string[] partir = custoTextBox.Text.Split('$');
                custoTextBox.Text = partir[1];
            }
        }

        private void custoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
   (e.KeyChar != ',' && e.KeyChar != '.' &&
    e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!custoTextBox.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }

        private void custoTextBox_Leave(object sender, EventArgs e)
        {
            if (custoTextBox.Text == string.Empty)
            {
                custoTextBox.Text = "R$0,00";
            }
            else
            {
                custoTextBox.Text = Convert.ToDouble(custoTextBox.Text).ToString("C");
            }
        }
        #endregion



        private void minimoTextBox_Leave(object sender, EventArgs e)
        {
            if (minimoTextBox.Text == string.Empty)
                minimoTextBox.Text = "0";
        }

        private void atualTextBox_Leave(object sender, EventArgs e)
        {
            if (atualTextBox.Text == string.Empty)
                atualTextBox.Text = "0";
        }

        private void periodoTextBox_Leave(object sender, EventArgs e)
        {
            if (periodoTextBox.Text == string.Empty)
                periodoTextBox.Text = "0";
        }



        private void minimoTextBox_Enter(object sender, EventArgs e)
        {
            if (minimoTextBox.Text == "0") { minimoTextBox.Clear(); }
        }
    }
}

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
    public partial class formProdutosLotesQuarentenasProdutosEditar : Form
    {
        string edicao;
        string atual;
        Produto_Quarentena produto = new Produto_Quarentena();
        formProdutosLotesQuarentenasProdutos pai = new formProdutosLotesQuarentenasProdutos();

        public formProdutosLotesQuarentenasProdutosEditar()
        {
            InitializeComponent();
        }
        public formProdutosLotesQuarentenasProdutosEditar(formProdutosLotesQuarentenasProdutos Pai, Produto_Quarentena Produto, string Edicao, string Atual)
        {
            InitializeComponent();
            produto = Produto;
            edicao = Edicao;
            atual = Atual;
            pai = Pai;
        }

        private void formProdutosLotesQuarentenasProdutosEditar_Load(object sender, EventArgs e)
        {
            textBoxProduto.Text = produto.Nome;
            labelAtual.Text = produto.Quantidade.ToString();

            if (edicao == "Etiqueta" || edicao == "Acabamento")
            {
                comboBoxAtual.Items.Add("Pendente");
                comboBoxAtual.Items.Add("Realizado");
                comboBoxAtual.Items.Add("Pronto");

                comboBoxNovo.Items.Add("Pendente");
                comboBoxNovo.Items.Add("Realizado");
                comboBoxNovo.Items.Add("Pronto");

                if (edicao == "Etiqueta") 
                {
                    comboBoxAtual.SelectedItem = atual;

                    comboBoxNovo.Items.Remove(atual);
                    comboBoxNovo.SelectedItem = produto.Etiqueta;
                }
                else
                {
                    comboBoxAtual.SelectedItem = atual;

                    comboBoxNovo.Items.Remove(atual);
                    comboBoxNovo.SelectedItem = produto.Acabamento;
                }
            }
            else
            {
                comboBoxAtual.Items.Add("Avariado");
                comboBoxAtual.Items.Add("Faltando");
                comboBoxAtual.Items.Add("Intacto");
                comboBoxAtual.Items.Add("Pendente");
 


                comboBoxNovo.Items.Add("Avariado");
                comboBoxNovo.Items.Add("Faltando");
                comboBoxNovo.Items.Add("Intacto");
                comboBoxNovo.Items.Add("Pendente");
                comboBoxAtual.SelectedItem = atual;

                comboBoxNovo.Items.Remove(atual);
                comboBoxNovo.SelectedItem = produto.Condicionamento;
            }

            comboBoxAtual.Enabled = false;
        }

        private void textBoxQuantidade_Enter(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == "0")
                textBoxQuantidade.Clear();
        }

        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxQuantidade_Leave(object sender, EventArgs e)
        {
            if (textBoxQuantidade.Text == string.Empty)
                textBoxQuantidade.Text = "0";
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string status = comboBoxNovo.Text;
            int quantidade = Convert.ToInt32(textBoxQuantidade.Text);

            if (status == string.Empty)
            {
                MessageBox.Show("Informe o status para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (quantidade == 0)
            {
                MessageBox.Show("Informe a quantidade para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (quantidade > produto.Quantidade)
            {
                MessageBox.Show("A quantidade informada é maior do que a quantidade atual!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int i = 0;

                foreach(Produto_Quarentena produto in pai.Produtos)
                {
                    if (i == quantidade)
                    {
                        break;
                    }

                    if (edicao == "Etiqueta")
                    {
                        if (produto.Nome == this.produto.Nome && produto.Cod_Barras == this.produto.Cod_Barras && produto.Etiqueta == atual && produto.Acabamento == this.produto.Acabamento && produto.Condicionamento == this.produto.Condicionamento)
                        {
                            produto.Etiqueta = status;
                            i++;
                        }
  
                    }
                    else if (edicao == "Acabamento")
                    {
                        if (produto.Nome == this.produto.Nome && produto.Cod_Barras == this.produto.Cod_Barras && produto.Acabamento == atual && produto.Etiqueta == this.produto.Etiqueta && produto.Condicionamento == this.produto.Condicionamento)
                        {
                            produto.Acabamento = status;
                            i++;
                        }
                    }
                    else if (edicao == "Condicionamento")
                    {
                        if (produto.Nome == this.produto.Nome && produto.Cod_Barras == this.produto.Cod_Barras && produto.Condicionamento == atual && produto.Acabamento == this.produto.Acabamento && produto.Etiqueta == this.produto.Etiqueta)
                        {
                            produto.Condicionamento = status;
                            i++;
                        }
                    }
                }

                Dispose();
            }
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
    }
}

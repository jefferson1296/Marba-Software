using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MarbaSoftware
{
    public partial class formProdutosEditar : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        bool tela_produtos;
        bool tela_variacoes;

        int id_produto;

        public Produto Produto = new Produto();

        //Apagar
        //public List<string> Fornecedores = new List<string>();

        public formProdutosEditar(int ID_Produto, string Editar)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            id_produto = ID_Produto;

            if (Editar == "Produto")
            {
                tela_produtos = true;
                tela_variacoes = false;
            }
            else
            {
                tela_produtos = false;
                tela_variacoes = true;
            }
        }

        private void formProdutosEditar_Load(object sender, EventArgs e)
        {
            Produto = comandos.TrazerTodasInformacoesDoProduto(id_produto);
            DestacarBotão();
        }
        private void fecharPictureBox_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void DestacarBotão()
        {
            if (tela_produtos)
            {
                formProdutosEditarProduto editar_principal = new formProdutosEditarProduto(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(editar_principal);
                editar_principal.Show();
                buttonProduto2.Visible = true;
                buttonProduto1.Visible = false;
            }
            else
            {
                buttonProduto2.Visible = false;
                buttonProduto1.Visible = true;
            }
            
            if (tela_variacoes)
            {
                formProdutosEditarVariacoes editar_complementar = new formProdutosEditarVariacoes(this, Produto) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(editar_complementar);
                editar_complementar.Show();

                buttonVariacoes2.Visible = true;
                buttonVariacoes1.Visible = false;
            }
            else
            {
                buttonVariacoes2.Visible = false;
                buttonVariacoes1.Visible = true;
            }
        }

        private void buttonPrincipais1_MouseEnter(object sender, EventArgs e)
        {
            if (!tela_produtos)
            {
                buttonProduto1.Visible = false;
                buttonProduto2.Visible = true;
            }
        }
        private void buttonPrincipais2_MouseLeave(object sender, EventArgs e)
        {
            if (!tela_produtos)
            {
                buttonProduto1.Visible = true;
                buttonProduto2.Visible = false;
            }
        }
        private void buttonPrincipais2_Click(object sender, EventArgs e)
        {
            if (!tela_produtos)
            {
                tela_produtos = true;
                tela_variacoes = false;
                DestacarBotão();
            }
        }

        private void buttonComplementar1_MouseEnter(object sender, EventArgs e)
        {
            if (!tela_variacoes)
            {
                buttonVariacoes1.Visible = false;
                buttonVariacoes2.Visible = true;
            }
        }
        private void buttonComplementar2_MouseLeave(object sender, EventArgs e)
        {
            if (!tela_variacoes)
            {
                buttonVariacoes1.Visible = true;
                buttonVariacoes2.Visible = false;
            }
        }
        private void buttonComplementar2_Click(object sender, EventArgs e)
        {
            if (!tela_variacoes)
            {
                tela_produtos = false;
                tela_variacoes = true;
                DestacarBotão();
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

        private void salvarButton_Click(object sender, EventArgs e)
        {
            bool continuar = false;

            if (Produto.Nome_Produto == string.Empty)
            {
                MessageBox.Show("Informe o nome do produto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Produto.Cod_Barras == string.Empty)
            {
                Random codigo_aleatorio = new Random();

                if (DialogResult.Yes == MessageBox.Show("Você não definiu um código de barras. \r\nPor isso, o sistema criará um código de barras aleatório.\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    int i = 0;
                    while (i < 1)
                    {
                        Produto.Cod_Barras = codigo_aleatorio.Next(78900000, 78999999).ToString();
                        if (comandos.VerificarCodigo(Produto.Cod_Barras) != Produto.Cod_Barras) { i++; continuar = true; }
                    }
                }
            }
            else if (Produto.Utensilio == string.Empty)
            {
                MessageBox.Show("Informe o utensílio para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!comandos.VerificarSeUtensilioJaExiste(Produto.Utensilio))
            {
                MessageBox.Show("Informe um utensílio válido para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Produto.Fabricante == string.Empty)
            {
                MessageBox.Show("Informe o fabricante!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Produto.Caixa == 0)
            {
                MessageBox.Show("Informe a quantidade por volume!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Produto.Preco_Base == 0)
            {
                if (DialogResult.Yes == MessageBox.Show("O preço de custo não foi informado.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    continuar = true;
                }
            }
            else
            {
                continuar = true;
            }

            if (continuar)
            {
                Produto.ID_Produto = id_produto;
                comandos.EditarProduto(Produto);
                Dispose();
            }
        }
    }
}

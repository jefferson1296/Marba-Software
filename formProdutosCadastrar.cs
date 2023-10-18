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
    public partial class formProdutosCadastrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        public Conjunto conjunto = new Conjunto();
        public bool cadastrar_conjunto;

        public Produto Produto = new Produto();

        public formProdutosCadastrar()
        {
            InitializeComponent();
        }

        public formProdutosCadastrar(Conjunto Conjunto)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            conjunto = Conjunto;
            cadastrar_conjunto = true;
        }

        private void formProdutosCadastrar_Load(object sender, EventArgs e)
        {
            Produto.Cod_Barras = string.Empty;

            if (cadastrar_conjunto)
            {
                Produto.Cod_Extra = conjunto.Cod_Extra;
                Produto.Fabricante = conjunto.Fabricante;
                
                Produto.Aliquota_ICMS = conjunto.Aliquota_ICMS;
                Produto.Aliquota_IPI = conjunto.Aliquota_IPI;

                string Tipo_Venda = conjunto.Tipo_Venda;

                if (Tipo_Venda == "UNIDADE")
                {
                    Produto.Preco_Base = conjunto.Custo_Base / conjunto.Qtd_Produtos;
                }
                else
                {
                    Produto.Preco_Base = conjunto.Custo_Base;
                }
            }

            formProdutosEditarProduto editar_principal = new formProdutosEditarProduto(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panelCentral.Controls.Clear();
            panelCentral.Controls.Add(editar_principal);
            editar_principal.Show();
        }

        private void AvancarButton_Click(object sender, EventArgs e)
        {
            bool continuar = false;

            if (Produto.Nome_Produto == string.Empty)
            {
                MessageBox.Show("Informe o nome do produto para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (Produto.MateriaPrima == string.Empty)
            {
                MessageBox.Show("Informe o material!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                continuar = true;
            }

            if (continuar)
            {                
                comandos.CadastrarProdutos(cadastrar_conjunto, Produto, conjunto);
                int id = comandos.IdDoUltimoProdutoCadastrado(Produto.Nome_Produto);
                Produto.ID_Produto = id;

                formProdutosEditarVariacoes cadastrar_variacoes = new formProdutosEditarVariacoes(this, Produto) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(cadastrar_variacoes);
                cadastrar_variacoes.Show();

                AvancarButton.Visible = false;
                buttonContinuar.Visible = true;
            }
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
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

        private void fecharPictureBox_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}

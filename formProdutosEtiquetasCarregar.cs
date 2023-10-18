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
    public partial class formProdutosEtiquetasCarregar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formProdutosEtiquetas pai = new formProdutosEtiquetas();
        public formProdutosEtiquetasCarregar()
        {
            InitializeComponent();
        }
        public formProdutosEtiquetasCarregar(formProdutosEtiquetas Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void fonteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fonteComboBox.Text == "ÚLTIMA IMPRESSÃO")
            {
                Height = 150;
                carregamentoComboBox.Visible = false;
                labelCarregamento.Visible = false;
            }
            else
            {
                Height = 200;
                carregamentoComboBox.Visible = true;
                labelCarregamento.Visible = true;
                carregamentoComboBox.DataSource = null;

                if (fonteComboBox.Text == "PEDIDO")
                {
                    labelCarregamento.Text = "Informe o Pedido:";
                    carregamentoComboBox.DataSource = comandos.ComboBoxPedidosConfirmados();
                    carregamentoComboBox.DisplayMember = "Pedido";
                    carregamentoComboBox.Update();
                }
                else if (fonteComboBox.Text == "ÚLTIMA ENTRADA")
                {
                    labelCarregamento.Text = "Informe a Entrada:";
                    carregamentoComboBox.DataSource = comandos.ComboBoxFornecedoresEntradas();
                    carregamentoComboBox.DisplayMember = "Fornecedor";
                    carregamentoComboBox.Update();
                }
            }
        }

        private void fonteComboBox_DropDown(object sender, EventArgs e)
        {
            if (fonteComboBox.Items.IndexOf(string.Empty) == 0)
            {
                fonteComboBox.Items.RemoveAt(0);
            }
        }

        private void formProdutosEtiquetasCarregar_Load(object sender, EventArgs e)
        {
            carregamentoComboBox.DropDownHeight = 120;
            carregamentoComboBox.DropDownWidth = 250;
        }

        private void carregarButton_Click(object sender, EventArgs e)
        {
            if (fonteComboBox.Text == string.Empty)
            {
                MessageBox.Show("Selecione a origem para carregar os produtos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                pai.alteracao = true;
                if (fonteComboBox.Text == "ÚLTIMA IMPRESSÃO")
                {
                    pai.lista = comandos.TrazerProdutosDaUltimaImpressao();
                }
                else
                {
                    if (fonteComboBox.Text == "PEDIDO")
                    {
                        string[] partir = carregamentoComboBox.Text.Split(' ');
                        int id = Convert.ToInt32(partir[0]);
                        pai.lista = comandos.TrazerProdutosDoPedido(id);
                    }
                    else if (fonteComboBox.Text == "ÚLTIMA ENTRADA")
                    {
                        string fornecedor = carregamentoComboBox.Text;
                        pai.lista = comandos.TrazerProdutosDaEntrada(fornecedor);
                    }
                }
                Dispose();
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
    }
}

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
    public partial class formProdutosListas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool pedido = false;
        bool entrada = false;
        List<ProdutoEtiqueta> lista = new List<ProdutoEtiqueta>();
        public formProdutosListas()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void formProdutosListas_Load(object sender, EventArgs e)
        {
            Height = 145;
        }
        private void buttonEntrada_Click(object sender, EventArgs e)
        {
            entrada = true;
            AlterarVisibilidadeDosComponentes();
            escolherComboBox.DataSource = comandos.ComboBoxFornecedoresEntradas();
            escolherComboBox.DisplayMember = "Fornecedor";
            escolherComboBox.Update();
            listaComboBox.Items.RemoveAt(0);
        }
        private void buttonPedido_Click(object sender, EventArgs e)
        {
            pedido = true;
            AlterarVisibilidadeDosComponentes();
            labelEscolher.Text = "Selecione o Pedido:";
            escolherComboBox.DataSource = comandos.ComboBoxPedidosConfirmados();
            escolherComboBox.DisplayMember = "Pedido";
            escolherComboBox.Update();
        }
        private void AlterarVisibilidadeDosComponentes()
        {
            Height = 215;
            CenterToScreen();
            buttonEntrada.Visible = false;
            buttonPedido.Visible = false;
            labelInfo.Visible = false;
            labelEscolher.Visible = true;
            labelLista.Visible = true;
            escolherComboBox.Visible = true;
            listaComboBox.Visible = true;
            buttonVisualizar.Visible = true;
            buttonImprimir.Visible = true;
        }
        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            if (listaComboBox.Text == "LISTA PARA CONFERÊNCIA")
            {
                string[] partir = escolherComboBox.Text.Split(' ');
                int id = Convert.ToInt32(partir[0]);
                string fornecedor = comandos.TrazerFornecedorPeloPedido(id);
                comandos.ListaParaConferencia(id, fornecedor, true);
            }
            else if (listaComboBox.Text == "LISTA DE REAJUSTES")
            {
                if (entrada)
                {
                    string fornecedor = escolherComboBox.Text;
                    comandos.ListaDeReajustes("Entrada", 0, fornecedor, true);
                }
                else if (pedido)
                {
                    string[] partir = escolherComboBox.Text.Split(' ');
                    int id = Convert.ToInt32(partir[0]);
                    string fornecedor = comandos.TrazerFornecedorPeloPedido(id);
                    comandos.ListaDeReajustes("Pedido", id, fornecedor, true);
                }
            }
            else if (listaComboBox.Text == "LISTA DE PRODUTOS ZERADOS")
            {

            }
            else if (listaComboBox.Text == "CÓDIGO DE BARRAS - AUTOMÁTICO")
            {

            }
            else if (listaComboBox.Text == "PREÇOS - AUTOMÁTICO")
            {

            }
            else if (listaComboBox.Text == "PLACAS - AUTOMÁTICO")
            {

            }
            else if (listaComboBox.Text == "LISTA DE NOVOS PRODUTOS")
            {

            }            
        }
        private void buttonVisualizar_Click(object sender, EventArgs e)
        {
            string operador = Program.colaborador.Nome_Colaborador;
            if (listaComboBox.Text == "LISTA PARA CONFERÊNCIA")
            {
                string[] partir = escolherComboBox.Text.Split(' ');
                int id = Convert.ToInt32(partir[0]);
                string fornecedor = comandos.TrazerFornecedorPeloPedido(id);
                comandos.ListaParaConferencia(id, fornecedor, false);
            }
            else if (listaComboBox.Text == "LISTA DE REAJUSTES")
            {
                if (entrada)
                {
                    string fornecedor = escolherComboBox.Text;
                    comandos.ListaDeReajustes("Entrada", 0, fornecedor, false);
                }
                else if (pedido)
                {
                    string[] partir = escolherComboBox.Text.Split(' ');
                    int id = Convert.ToInt32(partir[0]);
                    string fornecedor = comandos.TrazerFornecedorPeloPedido(id);
                    comandos.ListaDeReajustes("Pedido", id, fornecedor, false);
                }
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
    }
}

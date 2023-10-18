using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formFornecedoresPedido : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string operador = Program.colaborador.Nome_Colaborador;
        string Selecao_BotaoDireito;
        //string fornecedor_selecionado;

        public formFornecedoresPedido()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }

        private void formFornecedoresPedido_Load(object sender, EventArgs e)
        {
            comandos.PreencherDataGridPedidos(dataGridViewLista);
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridViewLista.Rows[e.RowIndex].Selected = true;
                        dataGridViewLista.Focus();

                        Selecao_BotaoDireito = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    else
                    {
                        Selecao_BotaoDireito = string.Empty;
                    }
                }
                catch { }
            }
        }
        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string[] partir = dataGridViewLista.Rows[e.RowIndex].Cells[2].Value.ToString().Split(' ');

            Font fonte = new Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point);
            DataGridViewCell celula_do_botao = dataGridViewLista.Rows[e.RowIndex].Cells[4];
            celula_do_botao.Style.Font = fonte;

            if (partir[0] == "Faltam")
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Value = "Aguarde";
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.DarkGray;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.SelectionForeColor = Color.DarkGray;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.Gainsboro;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.SelectionBackColor = Color.Gainsboro;
            }
            else if (partir[0] == "Atrasado")
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Value = "Pedido";
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.White;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.SelectionForeColor = Color.White;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.Red;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.SelectionBackColor = Color.Red;
            }
            else if (partir[0] == "Hoje")
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Value = "Pedido";
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.ForeColor = Color.White;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.SelectionForeColor = Color.White;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.LimeGreen;
                dataGridViewLista.Rows[e.RowIndex].Cells[4].Style.SelectionBackColor = Color.LimeGreen;
            }


            Font minhafonte = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.WhiteSmoke;
            dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionBackColor = Color.Gainsboro;
            DataGridViewCell celula_do_nivel = dataGridViewLista.Rows[e.RowIndex].Cells[1];
            celula_do_nivel.Style.Font = minhafonte;

            string[] repartir = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString().Split('%');
            decimal nivel = Convert.ToDecimal(repartir[0]);

            if (nivel <= 10)
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Firebrick;
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionForeColor = Color.Firebrick;
            }                                            
            else if (nivel > 10 && nivel <= 20)          
            {                                            
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Red;
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionForeColor = Color.Red;
            }                                            
            else if (nivel > 20 && nivel <= 30)          
            {                                            
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.DarkOrange;
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionForeColor = Color.DarkOrange;
            }                                            
            else if (nivel > 30 && nivel <= 40)          
            {                                            
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Orange;
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionForeColor = Color.Orange;
            }                                            
            else if (nivel > 40 && nivel <= 50)          
            {                                            
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Gold;
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionForeColor = Color.Gold;
            }                                            
            else if (nivel > 50 && nivel <= 60)          
            {                                            
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Yellow;
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionForeColor = Color.Yellow;
            }                                            
            else if (nivel > 60 && nivel <= 70)          
            {                                            
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.GreenYellow;
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionForeColor = Color.GreenYellow;
            }                                            
            else if (nivel > 70 && nivel <= 80)          
            {                                            
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.LawnGreen;
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionForeColor = Color.LawnGreen;
            }                                            
            else if (nivel > 80 && nivel <= 90)          
            {                                            
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.LimeGreen;
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionForeColor = Color.LimeGreen;
            }                                            
            else if (nivel > 90 && nivel <= 100)         
            {                                            
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Lime;
                dataGridViewLista.Rows[e.RowIndex].Cells[1].Style.SelectionForeColor = Color.Lime;
            }
        }

        private void verPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Selecao_BotaoDireito != string.Empty)
            {
                comandos.VisualizarPrePedido(operador, Selecao_BotaoDireito, false);
            }
        }
        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Selecao_BotaoDireito != string.Empty)
            {
                comandos.VisualizarPrePedido(operador, Selecao_BotaoDireito, true);
            }
        }

        private void verPedidoDetalhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Selecao_BotaoDireito != string.Empty)
            {
                comandos.VisualizarPrePedidoDetalhado(operador, Selecao_BotaoDireito, false);
            }
        }


        private void dataGridViewLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Pedido")
                {
                    string fornecedor = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    comandos.VisualizarPedido(operador, fornecedor, false);
                    comandos.PreencherDataGridPedidos(dataGridViewLista);
                }
            }
        }

        private void fazerPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Selecao_BotaoDireito != string.Empty)
            {
                string fornecedor = Selecao_BotaoDireito;
                comandos.DefinirProdutosDoPedido(comandos.ProdutosDoPedido(fornecedor));
                comandos.FazerPedido(operador, fornecedor);
                comandos.PreencherDataGridPedidos(dataGridViewLista);
            }
        }

        private void buttonContinuar_Click(object sender, EventArgs e)
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

        private void buttonAberto_Click(object sender, EventArgs e)
        {
            formFornecedoresPedidoEmAberto em_aberto = new formFornecedoresPedidoEmAberto();
            em_aberto.ShowDialog();
        }

        private void buttonRecebimentos_Click(object sender, EventArgs e)
        {
            formFornecedoresPedidoRecebimentos proximos = new formFornecedoresPedidoRecebimentos();
            proximos.ShowDialog();
        }
    }
}

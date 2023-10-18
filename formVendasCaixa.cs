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
    public partial class formVendasCaixa : Form
    {
        formVendas pai = new formVendas();

        ComandosSQL comando = new ComandosSQL();

        bool vendas_realizadas;
        int id;
        public bool concessao;
        bool apagar_vendas;

        public formVendasCaixa()
        {
            InitializeComponent();
        }
        public formVendasCaixa(formVendas Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        private void formVendasCaixaAtual_Load(object sender, EventArgs e)
        {
            VerificarVenda();
            apagar_vendas = Program.Acessos.Where(x => x.Descricao == "Apagar vendas").Select(x => x.Permissao).FirstOrDefault();
        }
        private void pictureBoxPesquisar_Click(object sender, EventArgs e)
        {
            string data = DateTime.Now.ToShortDateString();
            textBoxPesquisa.Text = data;
        }
        private void buttonAbrir_Click(object sender, EventArgs e)
        {
            formVendasCaixaAbrirCaixa abrirCaixa = new formVendasCaixaAbrirCaixa(this);
            abrirCaixa.ShowDialog();
            VerificarVenda();
        }
        private void buttonFecharCaixa_Click(object sender, EventArgs e)
        {
            formVendasCaixaFecharCaixa fecharCaixa = new formVendasCaixaFecharCaixa(this);
            fecharCaixa.ShowDialog();
            VerificarVenda();
        }
        private void VerificarVenda()
        {
            pai.caixa_aberto = comando.VerificarCaixaAberto();
            vendas_realizadas = comando.VerificarVendasRealizadas();

            if (pai.caixa_aberto)
            {
                labelCaixaFechado.Visible = false;
                buttonAbrir.Visible = false;
                buttonFecharCaixa.Visible = true;

                if (vendas_realizadas)
                {
                    labelNenhumaVenda.Visible = false;
                    comando.PreencherDataGridCaixaAtual(dataGridVendas, bindingSourceVendas);
                }
                else
                {
                    labelNenhumaVenda.Visible = true;
                }
            }
            else
            {
                labelCaixaFechado.Visible = true;
                labelNenhumaVenda.Visible = false;
                buttonAbrir.Visible = true;
                buttonFecharCaixa.Visible = false;
                dataGridVendas.DataSource = null;
                dataGridVendas.Rows.Clear();
            }
        }
        private void timerVerificar_Tick(object sender, EventArgs e)
        {
        }
        private void buttonSangrias_Click(object sender, EventArgs e)
        {
            if (pai.caixa_aberto)
            {
                formVendasCaixaSangriasSuprimentos movimentacoes = new formVendasCaixaSangriasSuprimentos();
                movimentacoes.ShowDialog();
            }
            else
            {
                MessageBox.Show("Não é possível registrar movimentações quando o caixa está fechado.", "Caixa fechado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void buttonRelatorio_Click(object sender, EventArgs e)
        {
            if (pai.caixa_aberto)
            {
                bool imprimir = true;
                comando.ImprimirCupomRelatorioDeVendas(imprimir);
            }
            else
            {
                MessageBox.Show("Não é possível imprimir o relatório quando o caixa está fechado.", "Caixa fechado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void buttonContador_Click(object sender, EventArgs e)
        {
            formVendasCaixaContadorDeMoedas contador_de_moedas = new formVendasCaixaContadorDeMoedas();
            contador_de_moedas.Show();
        }
        private void imprimirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool imprimir = true;
            comando.ImprimirCupomRelatorioDeVendas(imprimir);
        }
        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool imprimir = false;
            comando.ImprimirCupomRelatorioDeVendas(imprimir);
        }
        private void dataGridVendas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridVendas.CurrentCell = dataGridVendas.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridVendas.Rows[e.RowIndex].Selected = true;
                        dataGridVendas.Focus();

                        id = Convert.ToInt32(dataGridVendas.Rows[e.RowIndex].Cells[0].Value);
                    }
                    else
                    {
                        id = 0;
                        if (apagar_vendas) { apagarVendaToolStripMenuItem.Visible = true; }
                        else { apagarVendaToolStripMenuItem.Visible = false; }
                    }
                }
                catch { }
            }
        }
        private void imprimirCupomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comando.ImprimirCuponsAnteriores(id);
            }
        }
        private void textBoxPesquisa_Enter(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == "Digite o número da venda")
            {
                textBoxPesquisa.Text = string.Empty;                
            }
            textBoxPesquisa.ForeColor = Color.Black;
        }
        private void textBoxPesquisa_Leave(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text == string.Empty)
            {
                textBoxPesquisa.Text = "Digite o número da venda";
                textBoxPesquisa.ForeColor = Color.DarkGray;
            }
        }
        private void textBoxPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPesquisa.Text != "Digite o número da venda")
                bindingSourceVendas.Filter = "CONVERT(ID_Venda, System.String) like '%" + textBoxPesquisa.Text + "%'";
        }

        private void panelBarra_Resize(object sender, EventArgs e)
        {
            labelVendas.Left = (panelBarra.Width / 2) - (labelVendas.Width / 2);
            labelCaixaFechado.Left = (panelBarra.Width / 2) - (labelCaixaFechado.Width / 2);
            labelNenhumaVenda.Left = (panelBarra.Width / 2) - (labelNenhumaVenda.Width / 2);
            pictureBoxEtiqueta.Left = labelVendas.Left - 20;
        }

        private void dataGridVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridVendas.Rows[e.RowIndex].Cells[0].Value);
                formVendasCaixaVenda venda = new formVendasCaixaVenda(id);
                venda.ShowDialog();
            }
            catch { }
        }

        private void apagarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comando.ApagarVenda(id);
            }
        }

        private void labelAbrir_Click(object sender, EventArgs e)
        {
            comando.AbrirGaveta();
        }
    }
}

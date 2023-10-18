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
    public partial class formVendasCaixasAnterioresVendas : Form
    {
        int id_caixa;
        string colaborador;
        DateTime data;
        bool apagar_vendas;
        int id;

        List<Pagamento> pagamentos = new List<Pagamento>();

        ComandosSQL comando = new ComandosSQL();

        public formVendasCaixasAnterioresVendas()
        {
            InitializeComponent();
        }

        public formVendasCaixasAnterioresVendas(int ID_Caixa,string Colaborador, DateTime Data)
        {
            InitializeComponent();
            id_caixa = ID_Caixa;
            colaborador = Colaborador;
            data = Data;
        }

        private void formVendasCaixasAnterioresVendas_Load(object sender, EventArgs e)
        {
            string[] partir = colaborador.Split(' ');
            colaborador = partir[0];
            labelVendas.Text = "VENDAS DE " + colaborador + " NO DIA " + data.ToShortDateString();

            apagar_vendas = Program.Acessos.Where(x => x.Descricao == "Apagar vendas").Select(x => x.Permissao).FirstOrDefault();

            AtualizarDataGrid();

            AjustarTexto();
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridVendas.CurrentRow != null)
            {
                primeira_linha = dataGridVendas.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridVendas.CurrentRow.Index;
            }

            comando.PreencherDataGridVendasDoCaixa(dataGridVendas, bindingSourceVendas, id_caixa);
            pagamentos = comando.PagamentosDoCaixa(id_caixa);

            decimal dinheiro = pagamentos.Where(x => x.Forma == "DINHEIRO").Sum(x => x.Valor);
            decimal debito = pagamentos.Where(x => x.Forma == "DÉBITO").Sum(x => x.Valor);
            decimal credito = pagamentos.Where(x => x.Forma == "CRÉDITO").Sum(x => x.Valor);
            decimal outros = pagamentos.Where(x => x.Forma != "DINHEIRO" && x.Forma != "DÉBITO" && x.Forma != "CRÉDITO").Sum(x => x.Valor);
            decimal troco = pagamentos.Sum(x => x.Troco);

            textBoxDinheiro.Text = dinheiro.ToString("C");
            textBoxDebito.Text = debito.ToString("C");
            textBoxCredito.Text = credito.ToString("C");
            textBoxOutros.Text = outros.ToString("C");
            textBoxTroco.Text = troco.ToString("C");

            try
            {
                dataGridVendas.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridVendas.CurrentCell = dataGridVendas.Rows[linha_selecionada].Cells[0];
            }
            catch { }
            if (dataGridVendas.CurrentRow != null)
                dataGridVendas.CurrentRow.Selected = false;
        }

        private void panelBarra_Resize(object sender, EventArgs e)
        {
            labelVendas.Left = (panelBarra.Width / 2) - (labelVendas.Width / 2);
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

        private void AjustarTexto()
        {
            int a = (panelBarra.Width / 2);
            int b = (labelVendas.Width / 2);
            int esquerda = a - b;
            labelVendas.Left = esquerda;
            pictureBoxEtiqueta.Left = labelVendas.Left - 30;
        }

        private void dataGridVendas_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceVendas.Filter = dataGridVendas.FilterString;
        }

        private void dataGridVendas_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceVendas.Sort = dataGridVendas.SortString;
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

        private void imprimirCupomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                comando.ImprimirCuponsAnteriores(id);
            }
        }

        private void apagarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("A venda será apagada permanentemente.\r\n\r\nDeseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    comando.ApagarVenda(id);
                    AtualizarDataGrid();
                }
            }
        }

        private void dataGridVendas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (apagar_vendas) { apagarVendaToolStripMenuItem.Visible = true; }
                    else { apagarVendaToolStripMenuItem.Visible = false; }

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
                    }
                }
                catch { }
            }
        }
    }
}

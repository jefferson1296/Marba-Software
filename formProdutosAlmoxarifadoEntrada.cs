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
    public partial class formProdutosAlmoxarifadoEntrada : Form
    {
        List<Almoxarifado> Itens = new List<Almoxarifado>();
        ComandosSQL comandos = new ComandosSQL();
        formProdutosAlmoxarifado pai = new formProdutosAlmoxarifado();
        string item;
        public formProdutosAlmoxarifadoEntrada()
        {
            InitializeComponent();
        }
        public formProdutosAlmoxarifadoEntrada(formProdutosAlmoxarifado Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        private void formProdutosAlmoxarifadoEntrada_Load(object sender, EventArgs e)
        {
            itemTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            itemTextBox.AutoCompleteCustomSource = comandos.AutoCompleteAlmoxarifado();
        }

        #region Formatação de Texto
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
        #endregion

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string item = itemTextBox.Text;
            int quantidade = Convert.ToInt32(idealTextBox.Text);
            string[] partir = custoTextBox.Text.Split('$');
            decimal custo = Convert.ToDecimal(partir[1]);

            if (item == string.Empty)
            {
                MessageBox.Show("Informe o nome do item para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!comandos.VerificarSeItemDoAlmoxarifadoJaExiste(item))
            {
                MessageBox.Show("Informe um item ativo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (quantidade == 0)
            {
                MessageBox.Show("Informe a quantidade para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int igual = Itens.Where(x => x.Item == item).Count();

                if (igual > 0)
                {
                    foreach (Almoxarifado Item in Itens)
                    {
                        if (Item.Item == item)
                        {
                            Item.Estoque_Ideal = Item.Estoque_Ideal + quantidade;
                        }
                    }
                }
                else
                {
                    Itens.Add(new Almoxarifado
                    {
                        Item = item,
                        Estoque_Ideal = quantidade,
                        Custo = custo
                    });
                }

                itemTextBox.Clear();
                custoTextBox.Text = "R$0,00";
                idealTextBox.Text = "0";
                itemTextBox.Focus();
            }

            AtualizarDataGrid();
        }
        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            dataGridViewLista.Rows.Clear();

            {
                foreach (Almoxarifado Item in Itens)
                {
                    dataGridViewLista.Rows.Add(Item.Item, Item.Custo, Item.Estoque_Ideal);
                }
            }

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
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

                        item = dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                    else
                    {
                        item = string.Empty;
                    }
                }
                catch { }
            }
        }
        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (item != string.Empty)
            {
                Itens.RemoveAll(x => x.Item == item);
                AtualizarDataGrid();
            }
        }
        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (Itens.Count < 0)
            {
                MessageBox.Show("É necessário inserir ao menos um item para dar entrada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comandos.RegistrarEntradaDoAlmoxarifado(Itens);
                pai.alteracao = true;
                Dispose();
            }
        }

        private void formProdutosAlmoxarifadoEntrada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}

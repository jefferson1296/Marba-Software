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
    public partial class formPromocoesTabelas : Form
    {
        bool limpar = false;
        public formPromocoesTabelas()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        private void formProdutosDescontos_Load(object sender, EventArgs e)
        {
            labelDesconto.Top = 36;
            labelDesconto.Left = 145;
            textBox1.Visible = false;
            textBox2.Visible = false;
            labelE.Visible = false;
            ComandosSQL comando = new ComandosSQL();
            comboBoxTabelas.DataSource = comando.TrazerListaDeTabelas(limpar);
            comboBoxTabelas.Update();
            foreach (DataGridViewColumn coluna in dataGridViewDescontos.Columns)
            {
                if (coluna.Index != 1)
                {
                    coluna.ReadOnly = true;
                }
            }
            dataGridViewDescontos.ClearSelection();
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void comboBoxTabelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linhas = dataGridViewDescontos.Rows.Count;
            string tabela = comboBoxTabelas.Text;
            string cliente = "";
            ComandosSQL comando = new ComandosSQL();
            dataGridViewDescontos.Columns.Clear();
            comando.PreencherDataGridProdutosDescontos(tabela, dataGridViewDescontos, bindingSourceDescontos);
            try
            {
                dataGridViewDescontos.Columns[0].Width = 440;
                dataGridViewDescontos.Columns[1].Width = 130;
            }
            catch { }
            if (comboBoxTabelas.Text == "")
            {
                labelDesconto.Text = "Informativo de Desconto";
                List<string> dados = new List<string>();
                dataGridViewDescontos.DataSource = null;
                DataGridViewColumn colunaCategoria = new DataGridViewColumn();
                DataGridViewColumn colunaDesc = new DataGridViewColumn();
                colunaCategoria.HeaderText = "CATEGORIA";
                colunaDesc.HeaderText = "DESCONTO %";
                dataGridViewDescontos.Columns.Add(colunaCategoria);
                dataGridViewDescontos.Columns.Add(colunaDesc);
                dataGridViewDescontos.Columns[0].Width = 440;
                dataGridViewDescontos.Columns[1].Width = 130;

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBoxDesconto.Text = string.Empty;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBoxDesconto.Enabled = false;
                labelE.Visible = false;
            }
            else
            {
                labelDesconto.Top = 6;
                labelDesconto.Left = 16;
                textBox1.Visible = true;
                textBoxDesconto.Text = comando.TrazerPercentualDaTabela(tabela);
                textBoxDesconto.Enabled = true;
                if (comboBoxTabelas.Text == "Cliente1" || comboBoxTabelas.Text == "Cliente2" || comboBoxTabelas.Text == "Cliente3")
                {
                    cliente = "CLIENTES";
                }
                else
                {
                    cliente = "REVENDEDORES";
                }
                if (comboBoxTabelas.Text == "Cliente3" || comboBoxTabelas.Text == "Revendedor3")
                {
                    labelDesconto.Text = "DESCONTO PARA " + cliente + " CADASTRADOS\r\nEM COMPRAS ACIMA DE";
                    labelE.Visible = false;
                    textBox1.Visible = true;
                    textBox2.Visible = false;
                }
                else
                {
                    labelDesconto.Text = "DESCONTO PARA " + cliente + " CADASTRADOS\r\nEM COMPRAS ENTRE";
                    labelE.Visible = true;
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                }

            }
            string[] separar = comando.TrazerParametrosDeDesconto(tabela).Split('/');
            try
            {
                if (separar[1] != string.Empty)
                {
                    double valor1 = Convert.ToDouble(separar[0]);
                    double valor2 = Convert.ToDouble(separar[1]);
                    textBox1.Text = valor1.ToString("C");
                    textBox2.Text = valor2.ToString("C");
                }
                else
                {
                    double valor1 = Convert.ToDouble(separar[0]);
                    textBox1.Text = valor1.ToString("C");
                }
            }
            catch{}             
        }
        private void dataGridViewDescontos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dataGridViewDescontos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    dataGridViewDescontos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
            catch { }
        }
        private void dataGridViewDescontos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void textBoxDesconto_Enter(object sender, EventArgs e)
        {
            if (textBoxDesconto.Text == "0%")
            {
                textBoxDesconto.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxDesconto.Text.Split('%');
                textBoxDesconto.Text = partir[0];
            }
            textBox1.SelectionStart = textBox1.Text.Length;
        }
        private void textBoxDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void textBoxDesconto_Leave(object sender, EventArgs e)
        {
            if (textBoxDesconto.Text == string.Empty)
            {
                textBoxDesconto.Text = "0%";
            }
            else
            {
                textBoxDesconto.Text = textBoxDesconto.Text + "%";
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "R$0,00")
            {
                textBox1.Text = string.Empty;
            }
            else
            {
                try
                {
                    string[] partir = textBox1.Text.Split('$');
                    textBox1.Text = partir[1];
                }
                catch { }
            }
            textBox1.SelectionStart = textBox1.Text.Length;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBox1.Text.Contains(','))
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
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "R$0,00";
            }
            else
            {
                textBox1.Text = Convert.ToDouble(textBox1.Text).ToString("C");
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "R$0,00")
            {
                textBox2.Text = string.Empty;
            }
            else
            {
                try
                {
                    string[] partir = textBox2.Text.Split('$');
                    textBox2.Text = partir[1];
                }
                catch { }
            }
            textBox2.Select(textBox2.Text.Length, 0);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBox2.Text.Contains(','))
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
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.Text = "R$0,00";
            }
            else
            {
                textBox2.Text = Convert.ToDouble(textBox2.Text).ToString("C");
            }
        }

        private void buttonAplicar_Click(object sender, EventArgs e)
        {
            string[] partir = textBoxDesconto.Text.Split('%');
            string desconto = partir[0];
            foreach (DataGridViewRow linha in dataGridViewDescontos.Rows)
            {
                dataGridViewDescontos.Rows[linha.Index].Cells[1].Value = desconto;
            }
        }

        private void dataGridViewDescontos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow linha in dataGridViewDescontos.Rows)
            {
                string[] partir = textBoxDesconto.Text.Split('%');
                int desconto = Convert.ToInt32(dataGridViewDescontos.Rows[linha.Index].Cells[1].Value);
                int padrao;
                try
                {
                    padrao = Convert.ToInt32(partir[0]);
                }
                catch { padrao = 0; }

                if (desconto != padrao)
                {
                    dataGridViewDescontos.Rows[linha.Index].Cells[1].Style.ForeColor = Color.Red;
                    dataGridViewDescontos.Rows[linha.Index].Cells[1].Style.SelectionForeColor = Color.Red;
                }
                else
                {
                    dataGridViewDescontos.Rows[linha.Index].Cells[1].Style.ForeColor = Color.Black;
                    dataGridViewDescontos.Rows[linha.Index].Cells[1].Style.SelectionForeColor = Color.Black;
                }

            }
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string[] separar = textBoxDesconto.Text.Split('%');
            int desconto = Convert.ToInt32(separar[0]);
            string[] faixa1 = textBox1.Text.Split('$');
            string[] faixa2 = textBox2.Text.Split('$');
            double inicio = Convert.ToDouble(faixa1[1]);
            double termino = 0;
            try { termino = Convert.ToDouble(faixa2[1]); } catch { }
            string tabela = comboBoxTabelas.Text;
            ComandosSQL comando = new ComandosSQL();
            comando.SalvarPercentuaisDasCategorias(desconto, tabela, dataGridViewDescontos, inicio, termino);
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

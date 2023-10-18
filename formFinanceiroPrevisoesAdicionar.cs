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
    public partial class formFinanceiroPrevisoesAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formFinanceiroPrevisoes pai;
        public formFinanceiroPrevisoesAdicionar(formFinanceiroPrevisoes Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
        }

        private void formFinanceiroPrevisoesAdicionar_Load(object sender, EventArgs e)
        {
            comboBoxFin.DataSource = comandos.PreencherComboPlanoDeContas(false);
            comboBoxFin.DisplayMember = "Categoria";
            comboBoxFin.ValueMember = "ID";
            comboBoxFin.DropDownHeight = 120;
            comboBoxFin.SelectedIndex = -1;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string[] partir = textBoxValor.Text.Split('$');

            DateTime data_escolhida = dateTimePicker.Value;
            DateTime mes_que_vem = DateTime.Now.AddMonths(1);
            DateTime proximo_mes = new DateTime(mes_que_vem.Year, mes_que_vem.Month, 1);

            bool atrasado = false;

            if (proximo_mes > data_escolhida)
            {
                atrasado = true;
            }
            if (textBoxDescricao.Text == string.Empty)
            {
                MessageBox.Show("Informe a Descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxValor.Text == "R$0,00")
            {
                MessageBox.Show("Informe o Valor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBoxFin.Text == string.Empty)
            {
                MessageBox.Show("Informe a categoria para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Previsao previsao = new Previsao()
                {
                    Descricao = textBoxDescricao.Text,
                    Data = dateTimePicker.Text,
                    Valor = Convert.ToDecimal(partir[1]),
                    Status = "Pendente",
                    Responsavel = Program.colaborador.Nome_Colaborador,
                    Tipo = comboBoxTransacao.Text,
                    ID_CatFin = (int)comboBoxFin.SelectedValue,
                };

                if (atrasado)
                {
                    if (DialogResult.Yes == MessageBox.Show("As previsões de gasto devem ser registradas para os próximos meses.\r\nSe continuar, a previsão será cadastrada como 'Atrasada'.\r\nDeseja continuar mesmo assim?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        comandos.AdicionarPrevisao(previsao, atrasado);
                        Dispose();
                        pai.alteracao = true;
                    }
                }
                else
                {
                    comandos.AdicionarPrevisao(previsao, atrasado);
                    this.Dispose();
                    pai.alteracao = true;
                }
            }            
        }

        private void textBoxValor_Enter(object sender, EventArgs e)
        {
            if (textBoxValor.Text == "R$0,00")
            {
                textBoxValor.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxValor.Text.Split('$');
                textBoxValor.Text = partir[1];
            }
        }

        private void textBoxValor_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (!textBoxValor.Text.Contains(','))
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

        private void textBoxValor_Leave(object sender, EventArgs e)
        {
            if (textBoxValor.Text == string.Empty)
            {
                textBoxValor.Text = "R$0,00";
            }
            else
            {
                decimal valor = Convert.ToDecimal(textBoxValor.Text);
                textBoxValor.Text = valor.ToString("C");
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxFin_DropDown(object sender, EventArgs e)
        {
            if (comboBoxFin.Items.IndexOf(string.Empty) == 0)
            {
                comboBoxFin.Items.RemoveAt(0);
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

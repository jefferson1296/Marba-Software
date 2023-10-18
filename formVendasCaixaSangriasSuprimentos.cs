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
    public partial class formVendasCaixaSangriasSuprimentos : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public bool permitir = false;
        public string valor;
        List<MovimentacaoCaixa> lista = new List<MovimentacaoCaixa>();

        public formVendasCaixaSangriasSuprimentos()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        private void formSangriasSuprimentos_Load(object sender, EventArgs e)
        {
            AtualizarTudo();
        }
        private void buttonSangria_Click(object sender, EventArgs e)
        {
            formVendasCaixaMovimentacao movimentacao = new formVendasCaixaMovimentacao(this, "Sangria");
            movimentacao.ShowDialog();

            if (permitir)
            {
                comandos.ImprimirCupomMovimentacao(valor, "SANGRIA");
                permitir = false;
                valor = "0";
            }
            AtualizarTudo();
        }

        private void buttonSobrando_Click(object sender, EventArgs e)
        {
            formVendasCaixaMovimentacao movimentacao = new formVendasCaixaMovimentacao(this, "Sobrando");
            movimentacao.ShowDialog();
            if (permitir)
            {
                comandos.ImprimirCupomMovimentacao( valor, "SOBRANDO");
                permitir = false;
                valor = "0";
            }
            AtualizarTudo();
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        public void AtualizarTudo()
        {
            dataGridViewLista.Rows.Clear();
            lista = comandos.ListaDeMovimentacoesDoCaixa();

            foreach (MovimentacaoCaixa mov in lista)
            {
                int id = mov.ID;
                string tipo = mov.Tipo;
                string valor = mov.Valor.ToString("C");
                string hora = mov.Hora;
                string status;

                if (mov.Operador == string.Empty && mov.Recebedor != string.Empty && mov.Tipo == "Suprimento")
                {
                    status = "Pendente";
                }
                else if (mov.Operador != string.Empty && mov.Recebedor == string.Empty && mov.Tipo == "Sangria")
                {
                    status = "Pendente";
                }
                else
                {
                    status = "Concluído";
                }

                dataGridViewLista.Rows.Add(id, tipo, valor, hora, status);
            }
            decimal sangria = lista.Where(x => x.Tipo == "Sangria").Sum(x => x.Valor);
            decimal suprimento = lista.Where(x => x.Tipo == "Suprimento").Sum(x => x.Valor);
            labelSangria.Text = sangria.ToString("C");
            labelSuprimento.Text = suprimento.ToString("C");
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

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string movimentacao = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
            string status = dataGridViewLista.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (movimentacao == "Sangria")
            {
                MessageBox.Show("Apenas os suprimentos pendentes estão passíveis de confirmação.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (movimentacao == "Suprimento" && status == "Concluído")
            {
                MessageBox.Show("Este suprimento já foi confirmado.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (movimentacao == "Suprimento" && status == "Pendente")
            {
                int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                string[] partir = dataGridViewLista.Rows[e.RowIndex].Cells[2].Value.ToString().Split('$');
                decimal Valor = Convert.ToDecimal(partir[1]);
                formVendasCaixaMovimentacao Movimentacao = new formVendasCaixaMovimentacao(id, this, "Suprimento", Valor);
                Movimentacao.ShowDialog();
                if (permitir)
                {
                    comandos.ImprimirCupomMovimentacao(valor, "SUPRIMENTO");
                    permitir = false;
                    valor = "0";
                }
                AtualizarTudo();
            }
        }
    }
}

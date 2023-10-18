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
    public partial class formGestaoExpedientes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        MaskedTextBox masked = new MaskedTextBox();

        bool alterar_expedientes;
        DateTime data = new DateTime();
        int id;
        public formGestaoExpedientes()
        {
            InitializeComponent();
        }

        private void formTelaInicialAtividadesExpedientes_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
            data = dateTimePicker1.Value;

            alterar_expedientes = Program.Acessos.Where(x => x.Descricao == "Alterar expedientes").Select(x => x.Permissao).FirstOrDefault();

            if (alterar_expedientes)
            {
                buttonApagar.Enabled = true;
                buttonDeslocar.Enabled = true;
            }
            else
            {
                buttonApagar.Enabled = false;
                buttonDeslocar.Enabled = false;
            }

            masked.TextAlign = HorizontalAlignment.Center;
            masked.Visible = false;
            //masked.SelectionStart = 1;
            //masked.SelectionLength = 0;

            dataGridViewLista.Controls.Add(masked);

            dataGridViewLista.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridViewLista_CellBeginEdit);
            dataGridViewLista.CellEndEdit += new DataGridViewCellEventHandler(dataGridViewLista_CellEndEdit);
            dataGridViewLista.Scroll += new ScrollEventHandler(dataGridViewLista_Scroll);

            masked.VisibleChanged += new EventHandler(masked_VisibleChanged);
            masked.Leave += new EventHandler(masked_Leave);

            foreach (DataGridViewColumn coluna in dataGridViewLista.Columns)
            {
                if (coluna.Index == 0 || coluna.Index == 1 || coluna.Index == 2 || coluna.Index == 15)
                {
                    coluna.ReadOnly = true;
                }
            }
        }

        private void verificarButton_Click(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void buttonDeslocar_Click(object sender, EventArgs e)
        {
            formTelaInicialAtividadesDeslocarHorarios deslocar = new formTelaInicialAtividadesDeslocarHorarios();
            deslocar.ShowDialog();
            AtualizarDataGrid();
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            formTelaInicialAtividadesApagar apagar = new formTelaInicialAtividadesApagar();
            apagar.ShowDialog();
            AtualizarDataGrid();
        }

        private void dataGridViewLista_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string status = dataGridViewLista.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (status != "Serviço")
            {
                dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.DimGray;
                dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.DimGray;
            }
            else
            {
                if (dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Atrasado")
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                    dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Red;
                }

                Font minhafonte = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);

                if (e.ColumnIndex == 4 || e.ColumnIndex == 6 || e.ColumnIndex == 8 || e.ColumnIndex == 10 || e.ColumnIndex == 12 || e.ColumnIndex == 14)
                {
                    dataGridViewLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = minhafonte;
                }
            }

            try
            {
                if (e.ColumnIndex == 2)
                {
                    string previsao = dataGridViewLista.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string inicio = dataGridViewLista.Rows[e.RowIndex].Cells[4].Value.ToString();

                    DateTime data_e_hora = Convert.ToDateTime(dateTimePicker1.Text + " " + previsao + ":00");                    

                    if (data_e_hora < DateTime.Now && inicio == string.Empty)
                    {
                        dataGridViewLista.Rows[e.RowIndex].Cells[4].Value = "Atrasado";
                    }
                }


            }
            catch { }
        }

        private void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;

            if (dataGridViewLista.CurrentRow != null)
            {
                primeira_linha = dataGridViewLista.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridViewLista.CurrentRow.Index;
            }

            data = dateTimePicker1.Value;

            dataGridViewLista.Rows.Clear();

            comandos.ListaDeExpedientes(data, dataGridViewLista);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void dataGridViewLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (alterar_expedientes)
                {
                    int id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                    if (id != 0)
                    {
                        formTelaInicialAtividadesExpedientesAlterar alterar = new formTelaInicialAtividadesExpedientesAlterar(id, data.Date, false);
                        alterar.ShowDialog();
                        AtualizarDataGrid();
                    }
                }
            }
            catch { }
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

                        id = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);

                        if (dataGridViewLista.Rows[e.RowIndex].Cells[0].Value.ToString() == "Folga")
                        {
                            alterarRegistrosToolStripMenuItem.Visible = false;
                            liberarToolStripMenuItem.Visible = false;
                        }
                        else
                        {
                            alterarRegistrosToolStripMenuItem.Visible = true;
                            liberarToolStripMenuItem.Visible = true;

                            DateTime data = dateTimePicker1.Value.Date;

                            if (comandos.VerificarLiberacaoDoColaborador(id, data))
                            {
                                liberarToolStripMenuItem.Text = "Retirar liberação";
                            }
                            else
                            {
                                liberarToolStripMenuItem.Text = "Liberar";
                            }
                        }
                    }
                    else
                    {
                        id = 0;
                    }
                }
                catch { }
            }
        }

        private void alterarRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                formTelaInicialAtividadesExpedientesAlterar alterar = new formTelaInicialAtividadesExpedientesAlterar(id, data.Date, true);
                alterar.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void pbProximo_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.Date.AddDays(1);
            AtualizarDataGrid();
        }

        private void pbAnterior_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.Date.AddDays(-1);
            AtualizarDataGrid();
        }

        private void liberarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                DateTime data = dateTimePicker1.Value.Date;
                comandos.AlterarLiberacaoDoColaborador(id, data);
            }
        }

        private void dataGridViewLista_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            masked.Mask = "##:##";
            Rectangle retangulo = dataGridViewLista.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            masked.Location = retangulo.Location;
            masked.Size = retangulo.Size;
            masked.Text = "";

            if (dataGridViewLista[e.ColumnIndex, e.RowIndex].Value != null)
            {
                masked.Text = dataGridViewLista[e.ColumnIndex, e.RowIndex].Value.ToString();
            }

            horario = masked.Text;

            masked.Visible = true;
            masked.Focus();
            focus = true;
        }

        private void dataGridViewLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (masked.Visible)
            {
                DateTime data = dateTimePicker1.Value.Date;

                string[] partir = masked.Text.Split(':');
                int horas;
                int minutos;
                try
                {
                    if (masked.Text == "  :" || masked.Text == string.Empty) { horas = 0; minutos = 0; }
                    else { horas = Convert.ToInt32(partir[0]); minutos = Convert.ToInt32(partir[1]); }
                }
                catch
                {
                    horas = 100;
                    minutos = 100;
                }

                if (masked.Text.Length != 5 && masked.Text != "  :" || horas > 23 || minutos > 59)
                {
                    MessageBox.Show("Formato de hora incorreto.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    masked.Text = horario;
                }

                string novo_horario;

                if (masked.Text == "  :")
                {
                    novo_horario = string.Empty;
                }
                else
                {
                    novo_horario = masked.Text;
                }

                dataGridViewLista.CurrentCell.Value = novo_horario;

                if (novo_horario != horario)
                {
                    id = Convert.ToInt32(dataGridViewLista[0, e.RowIndex].Value);

                    string horario;

                    if (novo_horario == string.Empty)
                    {
                        horario = string.Empty;
                    }
                    else
                    {
                        horario = data.ToShortDateString() + " " + novo_horario;
                    }
                    
                    string registro = dataGridViewLista.Columns[e.ColumnIndex].Name;

                    comandos.AlterarHorario(id, horario, registro, data.Date);

                    if (registro == Inicio.Name || registro == Lanche_Inicio.Name || registro == Lanche_Termino.Name || registro == Almoco_Inicio.Name || registro == Almoco_Termino.Name || registro == Termino.Name)
                    {
                        if (horario != string.Empty)
                        {
                            if (registro == Termino.Name)
                            {
                                if (DialogResult.Yes == MessageBox.Show("Se você registrar o término do expediente do colaborador,\r\nsuas horas no banco de horas serão atualizadas.\r\nDeseja continuar?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    comandos.RegistrarImpressaoPendente(id, horario, registro);
                                    Expediente Expediente = comandos.TrazerExpedienteDoColaborador(id, data);
                                    comandos.AtualizarBancoDeHoras(id, Expediente);
                                }
                            }
                            else
                            {
                                comandos.RegistrarImpressaoPendente(id, horario, registro);
                            }
                        }
                    }
                }

                masked.Visible = false;
            }
        }

        private void dataGridViewLista_Scroll(object sender, ScrollEventArgs e)
        {
            if (masked.Visible)
            {
                Rectangle retangulo = dataGridViewLista.GetCellDisplayRectangle(dataGridViewLista.CurrentCell.ColumnIndex, dataGridViewLista.CurrentCell.RowIndex, true);
                masked.Location = retangulo.Location;
            }
        }

        bool focus = true;
        string horario;

        private void masked_VisibleChanged(object sender, EventArgs e)
        {
            masked.Focus();
        }

        private void masked_Leave(object sender, EventArgs e)
        {
            if (focus)
            {
                masked.Focus();
                focus = false;
            }

        }

        private void imprimirEscalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Colaborador> Colaboradores = comandos.ListaDeColaboradores(false);
            List<Colaborador> colaboradores = new List<Colaborador>();
            int id;

            foreach (DataGridViewRow linha in dataGridViewLista.SelectedRows)
            {
                id = Convert.ToInt32(dataGridViewLista[0, linha.Index].Value);
                colaboradores.Add(Colaboradores.Where(x => x.ID_Colaborador == id).FirstOrDefault());
            }

            if (colaboradores.Count > 0)
            {
                formColaboradoresImprimirHorario horarios = new formColaboradoresImprimirHorario(colaboradores);
                horarios.ShowDialog();
            }
        }

        private void labelImprimir_Click(object sender, EventArgs e)
        {
            formGestaoExpedientesImprimir imprimir = new formGestaoExpedientesImprimir(data);
            imprimir.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            data = dateTimePicker1.Value.Date;
        }
    }
}

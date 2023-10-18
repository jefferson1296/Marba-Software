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
    public partial class formTelaInicialAtividadesEmAndamento : Form
    {        
        ComandosSQL comandos = new ComandosSQL();
        bool centralizar = false;

        AtividadeLancada atividade = new AtividadeLancada();

        Point coordenada_imagem = new Point();
        List<Colaborador> colaboradores = new List<Colaborador>();
        List<int> registros = new List<int>();

        string colaborador;
        int id_colaborador;

        bool arrastar;
        bool soltar;
        bool delegar;

        public formTelaInicialAtividadesEmAndamento()
        {
            InitializeComponent();
        }

        private void formTelaInicialAtividades_Load(object sender, EventArgs e)
        {
            //atividadesPorStatusTableAdapter.Fill(dataSetAtividadesPorStatus.AtividadesPorStatus);

            colaboradores = comandos.ListaDeColaboradoresDoSetor();
            AtualizarQuadroDeFuncionarios();

            dataGridViewLista.AutoGenerateColumns = false;

            AtualizarDataGrid();
            timerTempo.Enabled = true;
        }

        private void buttonAtividades_Click(object sender, EventArgs e)
        {
            formTelaInicialAtividades ativ = new formTelaInicialAtividades();
            ativ.ShowDialog();
            AtualizarDataGrid();
        }

        private void buttonDelegar_Click(object sender, EventArgs e)
        {
            formTelaInicialAtividadesDelegar delegar = new formTelaInicialAtividadesDelegar();
            delegar.ShowDialog();
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

            comandos.PreencherDataGridAtividadesEmAndamento(dataGridViewLista, bindingSource);

            try
            {
                dataGridViewLista.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridViewLista.CurrentRow != null)
                dataGridViewLista.CurrentRow.Selected = false;
        }

        private void timerTempo_Tick(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToLongTimeString();
            string data = DateTime.Now.ToLongDateString();

            labelHora.Text = hora;
            labelData.Text = data;

            if (!centralizar)
            {
                labelData.Left = chartAtividades.Left + ((chartAtividades.Width - labelData.Width) / 2);
                labelHora.Left = labelData.Left + ((labelData.Width - labelHora.Width) / 2);
                centralizar = true;
            }
        }

        #region Botões

        private void buttonFolga_Click(object sender, EventArgs e)
        {
            formTelaInicialAtividadesFolga folga = new formTelaInicialAtividadesFolga();
            folga.ShowDialog();
        }

        private void buttonHoraExtra_Click(object sender, EventArgs e)
        {
            formTelaInicialAtividadesHoraExtra horaExtra = new formTelaInicialAtividadesHoraExtra();
            horaExtra.ShowDialog();
        }

        private void buttonOrdenar_Click(object sender, EventArgs e)
        {
            formTelaInicialAtividadesOrdenar ordenar = new formTelaInicialAtividadesOrdenar();
            ordenar.ShowDialog();
        }

        private void buttonDeslocar_Click(object sender, EventArgs e)
        {
            formTelaInicialAtividadesDeslocarHorarios deslocar = new formTelaInicialAtividadesDeslocarHorarios();
            deslocar.ShowDialog();
        }

        private void buttonListView_Click(object sender, EventArgs e)
        {
            formListView listview = new formListView();
            listview.ShowDialog();
        }

        #endregion

        private void dataGridViewLista_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    try
                    {
                        atividade.ID_AtividadeLancada = Convert.ToInt32(dataGridViewLista.Rows[e.RowIndex].Cells[0].Value);
                        atividade.Descricao = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();
                        atividade.Status = dataGridViewLista.Rows[e.RowIndex].Cells[4].Value.ToString();
                        atividade.Responsaveis = dataGridViewLista.Rows[e.RowIndex].Cells[5].Value.ToString();

                        int colaboradores_empenhados = comandos.QuantidadeDeColaboradoresEmpenhados(atividade.ID_AtividadeLancada);

                        cancelarToolStripMenuItem.Visible = true;

                        if (colaboradores_empenhados == 1)
                        {
                            statusToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            statusToolStripMenuItem.Enabled = false;
                        }

                        if (atividade.Status == "Em aberto")
                        {
                            delegarToolStripMenuItem.Visible = true;
                            iniciarToolStripMenuItem.Visible = false;
                            concluirToolStripMenuItem.Visible = false;
                            pausarToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = false;
                            cancelarToolStripMenuItem.Visible = true;
                        }
                        if (atividade.Status == "Pendente")
                        {
                            delegarToolStripMenuItem.Visible = true;
                            iniciarToolStripMenuItem.Visible = true;
                            concluirToolStripMenuItem.Visible = false;
                            pausarToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = false;
                            cancelarToolStripMenuItem.Visible = true;
                        }
                        else if (atividade.Status == "Em andamento")
                        {
                            delegarToolStripMenuItem.Visible = true;
                            iniciarToolStripMenuItem.Visible = false;
                            concluirToolStripMenuItem.Visible = true;
                            pausarToolStripMenuItem.Visible = true;
                            retomarToolStripMenuItem.Visible = false;
                            cancelarToolStripMenuItem.Visible = true;
                        }
                        else if (atividade.Status == "Pausado")
                        {
                            delegarToolStripMenuItem.Visible = true;
                            iniciarToolStripMenuItem.Visible = false;
                            concluirToolStripMenuItem.Visible = true;
                            pausarToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = true;
                            cancelarToolStripMenuItem.Visible = true;
                        }
                        else if (atividade.Status == "Concluído")
                        {
                            delegarToolStripMenuItem.Visible = false;
                            iniciarToolStripMenuItem.Visible = false;
                            concluirToolStripMenuItem.Visible = false;
                            pausarToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = false;
                            cancelarToolStripMenuItem.Visible = false;
                        }
                        else if (atividade.Status == "Cancelado")
                        {
                            delegarToolStripMenuItem.Visible = false;
                            iniciarToolStripMenuItem.Visible = false;
                            concluirToolStripMenuItem.Visible = false;
                            pausarToolStripMenuItem.Visible = false;
                            retomarToolStripMenuItem.Visible = false;
                            cancelarToolStripMenuItem.Visible = false;
                        }
                    }
                    catch
                    {
                        atividade.ID_AtividadeLancada = 0;
                    }
                }
            }
        }

        private void lançamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (atividade.ID_AtividadeLancada != 0)
            {
                formTelaInicialAtividadesLancamentos lancamentos = new formTelaInicialAtividadesLancamentos(atividade);
                lancamentos.ShowDialog();
                AtualizarDataGrid();
            }
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (atividade.ID_AtividadeLancada != 0)
            {
                int id_atividade_delegada = comandos.IdDaAtividadeDelegada(atividade.ID_AtividadeLancada);
                comandos.IniciarAtividade(id_atividade_delegada);
                AtualizarDataGrid();
            }
        }

        private void pausarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (atividade.ID_AtividadeLancada != 0)
            {
                int id_atividade_delegada = comandos.IdDaAtividadeDelegada(atividade.ID_AtividadeLancada);
                comandos.PausarAtividade(id_atividade_delegada);
                AtualizarDataGrid();
            }
        }

        private void retomarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (atividade.ID_AtividadeLancada != 0)
            {
                int id_atividade_delegada = comandos.IdDaAtividadeDelegada(atividade.ID_AtividadeLancada);
                comandos.IniciarAtividade(id_atividade_delegada);
                AtualizarDataGrid();
            }
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (atividade.ID_AtividadeLancada != 0)
            {
                int id_atividade_delegada = comandos.IdDaAtividadeDelegada(atividade.ID_AtividadeLancada);
                comandos.CancelarAtividade(id_atividade_delegada);
                AtualizarDataGrid();
            }
        }

        private void concluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (atividade.ID_AtividadeLancada != 0)
            {
                int id_atividade_delegada = comandos.IdDaAtividadeDelegada(atividade.ID_AtividadeLancada);
                comandos.ConcluirAtividade(id_atividade_delegada);
                AtualizarDataGrid();
            }
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (atividade.ID_AtividadeLancada != 0)
            {
                if (DialogResult.Yes == MessageBox.Show("A atividade e todos os seus lançamentos serão apagados.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarAtividadeLancada(atividade.ID_AtividadeLancada);
                    AtualizarDataGrid();
                }
            }
        }

        private void delegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (atividade.ID_AtividadeLancada != 0)
            {
                if (atividade.Responsaveis != "Sem lançamentos")
                {
                    if (DialogResult.Yes == MessageBox.Show("Essa atividade já foi empenhada. Deseja delegá-la novamente?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        formTelaInicialAtividadesDelegar delegar = new formTelaInicialAtividadesDelegar(atividade);
                        delegar.ShowDialog();
                        AtualizarDataGrid();
                    }                    
                }
                else
                {
                    formTelaInicialAtividadesDelegar delegar = new formTelaInicialAtividadesDelegar(atividade);
                    delegar.ShowDialog();
                    AtualizarDataGrid();
                }
            }
        }

        private void formTelaInicialAtividades_Resize(object sender, EventArgs e)
        {
            labelQuadro.Left = panelBarra.Width / 2 - labelQuadro.Width / 2;
        }

        private void AtualizarQuadroDeFuncionarios()
        {
            panelColaboradores.Controls.Clear();

            foreach (Colaborador colaborador in colaboradores)
            {
                int registros_por_linha = 4;

                int divisao;
                int resto;
                try
                {
                    divisao = registros.Count / registros_por_linha;
                    resto = registros.Count % registros_por_linha;
                }
                catch
                {
                    divisao = 0;
                    resto = 0;
                }

                if (resto == 0)
                {
                    coordenada_imagem.X = 10;
                }
                else if (resto == 1)
                {
                    coordenada_imagem.X = 130;
                }
                else if (resto == 2)
                {
                    coordenada_imagem.X = 250;
                }
                else if (resto == 3)
                {
                    coordenada_imagem.X = 370;
                }

                if (divisao == 0)
                {
                    coordenada_imagem.Y = 10;
                }
                else
                {
                    coordenada_imagem.Y = 10 + (150 * divisao);
                }

                PictureBox picture = new PictureBox();
                picture.Location = coordenada_imagem;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Name = "pictureBox1";
                picture.Size = new Size(100, 100);
                picture.BackColor = Color.White;
                picture.Image = comandos.ConverterArrayDeBytesParaImagem(colaborador.Foto);
                panelColaboradores.Controls.Add(picture);

                Font minhafonte = new Font("Arial", 6, FontStyle.Regular, GraphicsUnit.Point);
                Font fonte2 = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);

                Label label_nome = new Label();
                label_nome.Font = fonte2;
                label_nome.ForeColor = Color.Black;
                panelColaboradores.Controls.Add(label_nome);

                label_nome.Name = colaborador.ID_Colaborador.ToString();
                label_nome.Text = colaborador.Nome_Colaborador;                
                label_nome.AutoSize = true;
                int x = picture.Left + picture.Width / 2 - label_nome.Width / 2;
                int y = coordenada_imagem.Y + picture.Height + 5;
                label_nome.Location = new Point(x, y);

                Label label_matricula = new Label();
                label_matricula.Font = minhafonte;
                label_matricula.ForeColor = Color.Black;
                panelColaboradores.Controls.Add(label_matricula);
                label_matricula.Text = colaborador.Matricula;
                label_matricula.AutoSize = true;
                x = picture.Left + picture.Width / 2 - label_matricula.Width / 2;
                y = coordenada_imagem.Y + picture.Height + 20;
                label_matricula.Location = new Point(x, y);

                Label label_status = new Label();
                label_status.Font = minhafonte;
                label_status.ForeColor = Color.Black;
                panelColaboradores.Controls.Add(label_status);
                label_status.Text = colaborador.Status;
                label_status.AutoSize = true;
                x = picture.Left + picture.Width / 2 - label_status.Width / 2;
                y = coordenada_imagem.Y + picture.Height + 30;
                label_status.Location = new Point(x, y);

                label_nome.Click += new EventHandler(label_Click);
                registros.Add(registros.Count + 1);

                label_nome.MouseDown += new MouseEventHandler(label_MouseDown);
                label_nome.MouseMove += new MouseEventHandler(label_MouseMove);
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;

            //MessageBox.Show("Testando..." + "\r\n" + label.Name);

            id_colaborador = Convert.ToInt32(label.Name);
            colaborador = label.Text;

            arrastar = true;
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;

            //MessageBox.Show("Testando..." + "\r\n" + label.Name);

            id_colaborador = Convert.ToInt32(label.Name);
            colaborador = label.Text;

            arrastar = true;
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastar)
            {
                Label Colaborador = new Label();
                Colaborador.Text = colaborador;
                Colaborador.Location = e.Location;
                Colaborador.DoDragDrop(Colaborador.Text, DragDropEffects.Copy);
                arrastar = false;
            }
        }

        private void dataGridViewLista_DragDrop(object sender, DragEventArgs e)
        {
            soltar = true;
        }

        private void dataGridViewLista_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dataGridViewLista_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridViewLista.CurrentCell = dataGridViewLista.Rows[e.RowIndex].Cells[0];
            }
            catch { }
        }

        private void dataGridViewLista_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (soltar)
            {
                if (e.RowIndex >= 0)
                {
                    string atividade = dataGridViewLista.Rows[e.RowIndex].Cells[1].Value.ToString();

                    bool treinamento = comandos.VerificarSeColaboradorRecebeuTreinamentoParaAtividade(id_colaborador, atividade);

                    if (treinamento)
                    {
                        MessageBox.Show("O colaborador " + colaborador + " recebeu treinamento para executar esta atividade.", atividade, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("O colaborador " + colaborador + " não recebeu treinamento para executar esta atividade.", atividade, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                soltar = false;
            }
        }

        private void buttonProcessos_Click(object sender, EventArgs e)
        {
            formAtividadesProcessos processos = new formAtividadesProcessos();
            processos.ShowDialog();
        }
    }    
}

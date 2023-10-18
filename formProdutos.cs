using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using ClosedXML.Excel;

namespace MarbaSoftware
{
    public partial class formProdutos : Form
    {
        #region Inicialização
        ComandosSQL comandos = new ComandosSQL();
        int id_selecionado;
        public bool alteracao;
        int id_reparticao;

        bool apagar_produtos;

        public formProdutos()
        {
            InitializeComponent();
        }        
        private void formProdutos_Load(object sender, EventArgs e)
        {
            timerPanelLateral.Enabled = true;
            BarraInferiorPanel.Height = 35;

            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoes();
            Reparticoes.RemoveAll(x => x.ID_Reparticao == id_reparticao);

            comboBoxReparticoes.ValueMember = "ID_Reparticao";
            comboBoxReparticoes.DisplayMember = "Descricao";
            comboBoxReparticoes.DataSource = Reparticoes;

            comboBoxReparticoes.DropDownHeight = 150;

            comboBoxReparticoes.SelectedValue = Program.Computador.ID_Reparticao;

            ExibirColunas();

            if (dataGridProdutos.CurrentRow != null)
                dataGridProdutos.CurrentRow.Selected = false;


            apagar_produtos = Program.Acessos.Where(x => x.Descricao == "Apagar produtos").Select(x => x.Permissao).FirstOrDefault();
        }

        #endregion

        #region Geral
        private void panel4_SizeChanged(object sender, EventArgs e) //Centralizar label "Lista de Produtos"
        {
            timerPanelLateral.Enabled = true;
        }
        private void BarraInferiorPictureBox_Click(object sender, EventArgs e) //Botão Ocultar Painel Inferior
        {
            //if (BarraInferiorPanel.Height == 35 && BarraInferiorPanel.Width == 1301)
            //{
            //    BarraInferiorPanel.Height = 170;
            //    labelProduto.Visible = true;
            //    produtoTextBox.Visible = true;
            //    pictureBoxProduto.Visible = true;
            //    labelCodBarras.Visible = true;
            //    codigoBarrasTextBox.Visible = true;
            //}
            //else if (BarraInferiorPanel.Height == 35 && BarraInferiorPanel.Width != 1301)
            //{
            //    BarraInferiorPanel.Height = 170;
            //    labelProduto.Visible = true;
            //    produtoTextBox.Visible = true;
            //    pictureBoxProduto.Visible = false;
            //    labelCodBarras.Visible = true;
            //    codigoBarrasTextBox.Visible = true;
            //}
            //else
            //{
            //    BarraInferiorPanel.Height = 35;
            //    labelProduto.Visible = false;
            //    produtoTextBox.Visible = false;
            //    pictureBoxProduto.Visible = false;
            //    labelCodBarras.Visible = false;
            //    codigoBarrasTextBox.Visible = false;
            //}
        }
        private void timerPanelLateral_Tick(object sender, EventArgs e)
        {
            labelLista.Left = (panelLista.Width / 2) - (labelLista.Width / 2);

            pictureBoxCaixa.Left = labelLista.Left - 20;
            if (BarraInferiorPanel.Width == 1301)
            {
                if (BarraInferiorPanel.Height == 35)
                {
                    pictureBoxProduto.Visible = false;
                }
                else
                {
                    pictureBoxProduto.Visible = true;

                }
            }
            else
            {
                pictureBoxProduto.Visible = false;
            }
            timerPanelLateral.Enabled = false;
        }
        #endregion

        #region Métodos

        public void AtualizarDataGrid()
        {
            int linha_selecionada = 0, primeira_linha = 0;
            if (dataGridProdutos.CurrentRow != null)
            {
                primeira_linha = dataGridProdutos.FirstDisplayedScrollingRowIndex;
                linha_selecionada = dataGridProdutos.CurrentRow.Index;
            }

            comandos.PreencherDataGridViewProdutos(dataGridProdutos, tblProdutosBindingSource, id_reparticao);

            try
            {
                dataGridProdutos.FirstDisplayedScrollingRowIndex = primeira_linha;
                dataGridProdutos.CurrentCell = dataGridProdutos.Rows[linha_selecionada].Cells[0];
            }
            catch { }

            if (dataGridProdutos.CurrentRow != null)
                dataGridProdutos.CurrentRow.Selected = false;
        }
        private void ExibirColunas()
        {
            if (checkBoxProduto.Checked == true)
            {
                dataGridProdutos.Columns["Nome_Produto"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Nome_Produto"].Visible = false;
            }
            if (checkBoxUtensilio.Checked == true)
            {
                dataGridProdutos.Columns["Utensilio"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Utensilio"].Visible = false;
            }
            if (checkBoxFabricante.Checked == true)
            {
                dataGridProdutos.Columns["Fabricante"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Fabricante"].Visible = false;
            }
            if (checkBoxMaterial.Checked == true)
            {
                dataGridProdutos.Columns["Material"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Material"].Visible = false;
            }

            if (checkBoxAltura.Checked == true)
            {
                dataGridProdutos.Columns["Altura"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Altura"].Visible = false;
            }
            if (checkBoxLargura.Checked == true)
            {
                dataGridProdutos.Columns["Largura"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Largura"].Visible = false;
            }
            if (checkBoxComprimento.Checked == true)
            {
                dataGridProdutos.Columns["Comprimento"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Comprimento"].Visible = false;
            }
            if (checkBoxDiametro.Checked == true)
            {
                dataGridProdutos.Columns["Diametro"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Diametro"].Visible = false;
            }
            if (checkBoxCapacidade.Checked == true)
            {
                dataGridProdutos.Columns["Capacidade"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Capacidade"].Visible = false;
            }
            if (checkBoxData.Checked == true)
            {
                dataGridProdutos.Columns["Data_Cadastramento"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Data_Cadastramento"].Visible = false;
            }
            if (checkBoxData.Checked == true)
            {
                dataGridProdutos.Columns["Data_Cadastramento"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Data_Cadastramento"].Visible = false;
            }
            if (checkBoxCodExtra.Checked == true)
            {
                dataGridProdutos.Columns["Cod_Extra"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Cod_Extra"].Visible = false;
            }
            if (checkBoxBase.Checked == true)
            {
                dataGridProdutos.Columns["Preco_Base"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Preco_Base"].Visible = false;
            }
            if (checkBoxVenda.Checked == true)
            {
                dataGridProdutos.Columns["Preco_Venda"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Preco_Venda"].Visible = false;
            }
            if (checkBoxIPI.Checked == true)
            {
                dataGridProdutos.Columns["Aliquota_IPI"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Aliquota_IPI"].Visible = false;
            }
            if (checkBoxICMS.Checked == true)
            {
                dataGridProdutos.Columns["Aliquota_ICMS"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Aliquota_ICMS"].Visible = false;
            }
            if (checkBoxCaixa.Checked == true)
            {
                dataGridProdutos.Columns["Caixa"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Caixa"].Visible = false;
            }
            if (checkBoxTipo.Checked == true)
            {
                dataGridProdutos.Columns["Tipo"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Tipo"].Visible = false;
            }
            if (checkBoxEspecificacao.Checked == true)
            {
                dataGridProdutos.Columns["Especificacao"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Especificacao"].Visible = false;
            }
            if (checkBoxCodBarras.Checked == true)
            {
                dataGridProdutos.Columns["Cod_Barras"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Cod_Barras"].Visible = false;
            }
            if (checkBoxAtual.Checked == true)
            {
                dataGridProdutos.Columns["Estoque_Atual"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Estoque_Atual"].Visible = false;
            }
            if (checkBoxReparticao.Checked == true)
            {
                dataGridProdutos.Columns["Reparticao"].Visible = true;
            }
            else
            {
                dataGridProdutos.Columns["Reparticao"].Visible = false;
            }
        }
        #endregion

        #region Visualização das Colunas
        private void panelColunas_MouseLeave(object sender, EventArgs e)
        {
            ExibirColunas();
            panelColunas.Visible = false;
        }
        private void colunasPictureBox_Click(object sender, EventArgs e)
        {
            panelColunas.Visible = true;
        }
        private void EscolherRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (EscolherRadioButton.Checked == true)
            {
                checkBoxProduto.Checked = true;
                checkBoxCodBarras.Checked = false;
                checkBoxUtensilio.Checked = false;
                checkBoxFabricante.Checked = false;
                checkBoxMaterial.Checked = false;
                checkBoxUtensilio.Checked = false;
                checkBoxAltura.Checked = false;
                checkBoxCodExtra.Checked = false;
                checkBoxLargura.Checked = false;
                checkBoxComprimento.Checked = false;
                checkBoxDiametro.Checked = false;
                checkBoxCaixa.Checked = false;
                checkBoxCapacidade.Checked = false;
                checkBoxEspecificacao.Checked = false;
                checkBoxBase.Checked = false;
                checkBoxIPI.Checked = false;
                checkBoxData.Checked = false;
                checkBoxTipo.Checked = false;
            }
        }
        private void tudoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (tudoRadioButton.Checked == true)
            {
                checkBoxProduto.Checked = true;
                checkBoxCodBarras.Checked = true;
                checkBoxUtensilio.Checked = true;
                checkBoxFabricante.Checked = true;
                checkBoxMaterial.Checked = true;
                checkBoxUtensilio.Checked = true;
                checkBoxAltura.Checked = true;
                checkBoxCodExtra.Checked = true;
                checkBoxLargura.Checked = true;
                checkBoxComprimento.Checked = true;
                checkBoxDiametro.Checked = true;
                checkBoxCaixa.Checked = true;
                checkBoxCapacidade.Checked = true;
                checkBoxEspecificacao.Checked = true;
                checkBoxBase.Checked = true;
                checkBoxIPI.Checked = true;
                checkBoxData.Checked = true;
                checkBoxTipo.Checked = true;
            }
        }
        #endregion

        #region Pesquisa de Produtos
        private void textBoxProduto_Enter(object sender, EventArgs e)
        {
            textBoxPesquisa.Text = string.Empty;
            textBoxPesquisa.ForeColor = Color.Black;
            textBoxPesquisa.CharacterCasing = CharacterCasing.Upper;

            if (dataGridProdutos.CurrentRow != null)
                dataGridProdutos.CurrentRow.Selected = false;
        }
        private void textBoxProduto_Leave(object sender, EventArgs e)
        {
            textBoxPesquisa.CharacterCasing = CharacterCasing.Normal;
            textBoxPesquisa.Text = "Digite aqui para pesquisar";
            textBoxPesquisa.ForeColor = Color.Gray;
        }        
        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            tblProdutosBindingSource.Sort = dataGridProdutos.SortString;
        }
        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            tblProdutosBindingSource.Filter = dataGridProdutos.FilterString;
        }
        private void textBoxProduto_TextChanged(object sender, EventArgs e) //Barra de Pesquisa
        {
            if (textBoxPesquisa.Text != "Digite aqui para pesquisar" && textBoxPesquisa.Text != string.Empty)
            {
                tblProdutosBindingSource.Filter = "Nome_Produto like '%" + textBoxPesquisa.Text + "%' OR Utensilio like '%" + textBoxPesquisa.Text + "%' OR Cod_Barras like '%" + textBoxPesquisa.Text + "%' OR Fabricante like '%" + textBoxPesquisa.Text + "%'";
            }
        }
        private void textBoxPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tblProdutosBindingSource.Filter = "Nome_Produto like '%" + textBoxPesquisa.Text + "%' OR Utensilio like '%" + textBoxPesquisa.Text + "%' OR Cod_Barras like '%" + textBoxPesquisa.Text + "%' OR Fabricante like '%" + textBoxPesquisa.Text + "%'";
            }
        }
        #endregion

        #region Instanciar Outros Formulários
        private void button11_Click(object sender, EventArgs e) //BOTÃO CADASTRAR
        {
            formProdutosCadastrar avancar = new formProdutosCadastrar();
            avancar.ShowDialog();
            AtualizarDataGrid();
        }
        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //EDITAR PRODUTOS
        {
            try
            {
                id_selecionado = Convert.ToInt32(dataGridProdutos.Rows[e.RowIndex].Cells[0].Value);
                if (id_selecionado != 0)
                {
                    formProdutosEditar editar = new formProdutosEditar(id_selecionado, "Produto");
                    editar.ShowDialog();
                }
                AtualizarDataGrid();
            }
            catch { }
        }
        private void buttonDarEntrada_Click(object sender, EventArgs e) //BOTÃO DAR ENTRADA
        {
            formProdutoEscolherFornecedor darentrada = new formProdutoEscolherFornecedor();
            darentrada.ShowDialog();
            AtualizarDataGrid();
        }

        #endregion

        private void buttonAjustes_Click(object sender, EventArgs e)
        {
            formProdutosAjustes ajustes = new formProdutosAjustes();
            ajustes.ShowDialog();
            AtualizarDataGrid();
        }
        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            DGVPrinterHelper.DGVPrinter printer = new DGVPrinterHelper.DGVPrinter();
            printer.Title = "Lista de Produtos";
            printer.SubTitle = string.Format("Hora: {0}", DateTime.Now.ToShortTimeString()) + "     " + string.Format("Data: {0}", DateTime.Now.ToLongDateString());
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = Program.colaborador.Nome_Colaborador;
            printer.FooterSpacing = 15;
            printer.PrintPreviewNoDisplay(dataGridProdutos);
        }
        private void buttonExportar_Click(object sender, EventArgs e)
        {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("Plan1");

                int colunas = dataGridProdutos.Columns.Count - 1; // CONTA QUANTAS COLUNAS HÁ NO DATAGRIDVIEW
                int inicial = 97; // 97 SIGNIFICA "A" AO CONVERTER PARA CHAR
                int total = colunas + 97; //

            if (total <= 122)
            {
                char colInic = Convert.ToChar(inicial);
                char colFinal = Convert.ToChar(total);
                string primeiraColuna = Convert.ToString(colInic);
                string ultimaColuna = Convert.ToString(colFinal);

                //TÍTULO DO RELATÓRIO
                var range = ws.Range(primeiraColuna + "1:" + ultimaColuna + "1");

                //CABEÇALHO DO RELATÓRIO
                int inicial1 = 97;
                int final1 = 97 + colunas;
                for (int i = inicial1; i <= final1; i++)
                {
                    char colInic1 = Convert.ToChar(i);
                    string primeiraColuna1 = Convert.ToString(colInic1);
                    if (i <= 122)
                    {
                        ws.Cell(primeiraColuna1 + "1").Value = dataGridProdutos.Columns[i - 97].HeaderText;
                    }
                    else
                    {
                        break;
                    }
                }
                //CORPO DO RELATÓRIO
                var linhas = dataGridProdutos.Rows.Count - 1; //21-1 = 20
                var linha = 3;
                for (int x = 0; x <= colunas; x++)
                {
                    for (int y = 0; y <= linhas; y++)
                    {
                        if (y == linhas)
                        {
                            linha = 2;
                            char colInic2 = Convert.ToChar(x + 97);
                            string primeiraColuna2 = Convert.ToString(colInic2);
                            ws.Cell(primeiraColuna2 + linha.ToString()).Value = dataGridProdutos.Rows[y].Cells[x].Value;
                            linha++;
                        }
                        else
                        {
                            char colInic2 = Convert.ToChar(x + 97);
                            string primeiraColuna2 = Convert.ToString(colInic2);
                            ws.Cell(primeiraColuna2 + linha.ToString()).Value = dataGridProdutos.Rows[y].Cells[x].Value;
                            linha++;
                        }
                    }
                }
                //Ajusta a Numeração da Linha
                linha--;

                string diretorio = "";
                using (SaveFileDialog dirDialog = new SaveFileDialog())
                {
                    // Mostra a janela de escolha do directorio
                    DialogResult res = dirDialog.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        diretorio = dirDialog.FileName;
                    }
                    else
                    {
                        // Caso o utilizador tenha cancelado
                        // ...
                    }
                }
                string arquivo = diretorio + ".xlsx";

                //CRIAR UMA TABELA PARA ATIVAR OS FILTROS
                range = ws.Range(primeiraColuna + "1:" + ultimaColuna + Convert.ToString(dataGridProdutos.RowCount + 1)); //dgvExcel.RowCount.ToString());
                range.CreateTable();


                //AJUSTA O TAMANHO DA COLUNA AO CONTEÚDO
                ws.Columns("1-" + Convert.ToString(dataGridProdutos.Columns.Count)).AdjustToContents();

                //SALVAR O ARQUIVO
                wb.SaveAs(arquivo);
                MessageBox.Show("Arquivo " + arquivo + " Gerado com Sucesso!");
                wb.Dispose();
            }
            else
            {
                char colInic = Convert.ToChar(inicial);
                char colFinal = Convert.ToChar(total);
                string primeiraColuna = Convert.ToString(colInic);
                string ultimaColuna = Convert.ToString(colFinal);

                //TÍTULO DO RELATÓRIO
                var range = ws.Range(primeiraColuna + "1:" + ultimaColuna + "1");

                //CABEÇALHO DO RELATÓRIO
                int inicial1 = 97;
                int final1 = 97 + colunas;

                if (final1 <= 122)
                {
                    for (int i = inicial1; i <= final1; i++)
                    {
                        char colInic1 = Convert.ToChar(i);
                        string primeiraColuna1 = Convert.ToString(colInic1);
                        ws.Cell(primeiraColuna1 + "1").Value = dataGridProdutos.Columns[i - 97].HeaderText;
                    }
                }
                else
                {
                    for (int i = inicial1; i <= final1; i++)
                    {
                        if (i <= 122)
                        {
                            char colInic1 = Convert.ToChar(i);
                            string primeiraColuna1 = Convert.ToString(colInic1);
                            ws.Cell(primeiraColuna1 + "1").Value = dataGridProdutos.Columns[i - 97].HeaderText;
                        }
                        else
                        {
                            char colA = Convert.ToChar(i - 26);
                            string a = Convert.ToString(colA);
                            ws.Cell("a" + colA + "1").Value = dataGridProdutos.Columns[i - 97].HeaderText;
                        }
                    }
                }
                

                string diretorio = "";
                using (SaveFileDialog dirDialog = new SaveFileDialog())
                {
                    // Mostra a janela de escolha do directorio
                    DialogResult res = dirDialog.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        diretorio = dirDialog.FileName;
                    }
                    else
                    {
                        // Caso o utilizador tenha cancelado
                        // ...
                    }
                }

                string arquivo = diretorio + ".xlsx";

                ws.Columns("1-" + Convert.ToString(dataGridProdutos.Columns.Count)).AdjustToContents();

                //SALVAR O ARQUIVO
                wb.SaveAs(arquivo);
                MessageBox.Show("Arquivo " + arquivo + " Gerado com Sucesso!");
                wb.Dispose();
            }
                
        }
        private void dataGridProdutos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        dataGridProdutos.CurrentCell = dataGridProdutos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridProdutos.Rows[e.RowIndex].Selected = true;
                        dataGridProdutos.Focus();

                        id_selecionado = Convert.ToInt32(dataGridProdutos.Rows[e.RowIndex].Cells[0].Value);

                        if (apagar_produtos) { apagarProdutoToolStripMenuItem.Visible = true; }
                        else { apagarProdutoToolStripMenuItem.Visible = false; }
                    }
                    else
                    {
                        id_selecionado = 0;
                    }
                }
                catch { }
            }


        }
        private void cadastrarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formProdutosCadastrar cadastro = new formProdutosCadastrar();
            cadastro.ShowDialog();
            AtualizarDataGrid();
        }
        private void cadastrarConjuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formProdutosConjuntosCadastrar cadastro = new formProdutosConjuntosCadastrar();
            cadastro.ShowDialog();
            AtualizarDataGrid();
        }
        private void buttonEtiquetas_Click(object sender, EventArgs e)
        {
            formProdutosEtiquetas etiquetas = new formProdutosEtiquetas();
            etiquetas.ShowDialog();
        }
        private void buttonAlmoxarifado_Click(object sender, EventArgs e)
        {
            formProdutosAlmoxarifado almoxarifado = new formProdutosAlmoxarifado();
            almoxarifado.ShowDialog();
        }

        private void panelColunas_Leave(object sender, EventArgs e)
        {
            if (panelColunas.Visible)
            {
                panelColunas.Visible = false;
                ExibirColunas();
            }          
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                formProdutosEditar editar = new formProdutosEditar(id_selecionado, "Produto");
                editar.ShowDialog();
            }
        }

        private void variaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                formProdutosEditar editar = new formProdutosEditar(id_selecionado, "Variacao");
                editar.ShowDialog();
            }
        }

        private void verPeçasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                formProdutosEditarPecas editar = new formProdutosEditarPecas(id_selecionado);
                editar.ShowDialog();
            }
        }

        private void adicionarPeçaAvulsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {                
                formProdutosPecasAvulsasAdicionar adicionar_peca = new formProdutosPecasAvulsasAdicionar(id_selecionado);
                adicionar_peca.ShowDialog();
            }
        }

        private void apagarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                if (comandos.QuantidadeDeProdutosEmEstoque(id_selecionado) > 0)
                {
                    MessageBox.Show("Não é possível apagar produtos que tem quantidade em estoque!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (comandos.QuantidadeDeVariacoesDoProduto(id_selecionado) > 1)
                {
                    MessageBox.Show("Não é possível apagar produtos com mais de uma variação.\r\nApague as variações para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o produto?\r\nSe você continuar, o produto e suas variações serão excluídos permanentemente.", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    comandos.ApagarProduto(id_selecionado);
                    AtualizarDataGrid();
                }
            }
        }

        private void acabamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                formProdutosEditarAcabamentos editar = new formProdutosEditarAcabamentos(id_selecionado);
                editar.ShowDialog();
            }
        }

        private void buttonLotes_Click(object sender, EventArgs e)
        {
            formProdutosLotes lotes = new formProdutosLotes();
            lotes.ShowDialog();
        }

        private void buttonConjuntos_Click(object sender, EventArgs e)
        {
            formProdutosConjuntos conjuntos = new formProdutosConjuntos();
            conjuntos.ShowDialog();
        }

        private void definirConjuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                string conjunto = comandos.VerificarSeProdutoDerivaDeConjunto(id_selecionado);
                bool permitir = false;

                if (conjunto != string.Empty)
                {
                    if (DialogResult.Yes == MessageBox.Show("O produto já está associado ao conjunto \"" + conjunto + "\".\r\nSe você continuar, o conjunto atual será sobreposto.\r\nTem certeza que deseja continuar?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        permitir = true;
                    }
                }
                else
                {
                    permitir = true;
                }

                if (permitir)
                {
                    formProdutosConjuntosCadastrar cadastrar_conjunto = new formProdutosConjuntosCadastrar(id_selecionado);
                    cadastrar_conjunto.ShowDialog();
                }
            }
        }

        private void comboBoxReparticao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxReparticoes.Text != string.Empty)
            {
                id_reparticao = (int)comboBoxReparticoes.SelectedValue;

                AtualizarDataGrid();
            }
        }

        private void localizarQuantidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id_selecionado != 0)
            {
                formProdutosQuantidades editar = new formProdutosQuantidades(id_selecionado, "Produto");
                editar.ShowDialog();
            }
        }
    }    
}

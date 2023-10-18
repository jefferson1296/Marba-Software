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

namespace MarbaSoftware
{
    
    public partial class formVendas : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        bool atual = false;
        bool anteriores = false;
        bool pdv = true;

        public string operador = Program.colaborador.Nome_Colaborador;

        public bool caixa_aberto;
        public bool imprimir_cupom;
        public int id_reparticao;

        public decimal desconto;

        public Cliente cliente = new Cliente();

        public List<Tabela_Descontos> Descontos = new List<Tabela_Descontos>();
        public List<Categoria> Categorias = new List<Categoria>();
        public string faixa_atual;

        public string tipo_de_venda;
        public List<ProdutoVenda> Produtos = new List<ProdutoVenda>();
        public List<Pagamento> Pagamentos = new List<Pagamento>();
        public List<int> Vales = new List<int>();

        public List<Combo> Combos = new List<Combo>();

        public AutoCompleteStringCollection Sugestao_Produtos = new AutoCompleteStringCollection();

        public formVendas()
        {
            InitializeComponent();
        }

        private void formVendas_Load(object sender, EventArgs e)
        {
            caixa_aberto = comandos.VerificarCaixaAberto();
            Descontos = comandos.TrazerFaixasDeDesconto();
            Categorias = comandos.TrazerPercentualDeDescontoPorCategoria();

            Combos = comandos.TrazerListaDeCombos();
            Sugestao_Produtos = comandos.AutoCompleteVendas();
            imprimir_cupom = true;

            desconto = 0;
            ClienteGenerico();
            faixa_atual = string.Empty;

            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoes();
            Reparticoes.RemoveAll(x => x.ID_Reparticao == id_reparticao);

            comboBoxReparticao.ValueMember = "ID_Reparticao";
            comboBoxReparticao.DisplayMember = "Descricao";
            comboBoxReparticao.DataSource = Reparticoes;

            id_reparticao = Program.Computador.ID_Reparticao;
            comboBoxReparticao.SelectedValue = id_reparticao;

            if (Program.Acessos.Where(x => x.Descricao == "Alterar repartição das vendas").Select(x => x.Permissao).FirstOrDefault())
            {
                comboBoxReparticao.Enabled = true;
            }

            labelOperador.Text = operador;
            this.pdv = true;
            formVendasPDV pdv = new formVendasPDV(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            panelCentral.Controls.Clear();
            panelCentral.Controls.Add(pdv);
            pdv.Show();

            if (Program.Acessos.Where(x => x.Descricao == "Acessar caixas anteriores").Select(x => x.Permissao).FirstOrDefault())
            {
                buttonAnteriores1.Enabled = true;
            }
            else
            {
                buttonAnteriores1.Enabled = false;
            }
        }

        public void ClienteGenerico()
        {
            cliente = new Cliente { Nome = "Consumidor Final", ID_Cliente = 1, CPF = "1" };
        }

        private void buttonAnteriores1_Click(object sender, EventArgs e)
        {
            if (!anteriores)
            {
                atual = false;
                anteriores = true;
                pdv = false;
                DestacarBotao();
            }
        }
        private void buttonAtual1_Click(object sender, EventArgs e)
        {
            if (!atual)
            {
                atual = true;
                anteriores = false;
                pdv = false;
                DestacarBotao();
            }
        }
        private void buttonPDV1_Click(object sender, EventArgs e)
        {
            if (!pdv)
            {
                atual = false;
                anteriores = false;
                pdv = true;
                DestacarBotao();
            }

        }
        private void DestacarBotao()
        {
            if (atual == true)
            {
                formVendasCaixaAtual caixaAtual = new formVendasCaixaAtual(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(caixaAtual);
                caixaAtual.Show();

                buttonAtual1.BackColor = Color.Red;
                buttonAtual1.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                buttonAtual1.BackColor = Color.White;
                buttonAtual1.ForeColor = Color.DarkRed;
            }

            if (anteriores == true)
            {
                formVendasCaixasAnteriores caixaAtual = new formVendasCaixasAnteriores(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(caixaAtual);
                caixaAtual.Show();

                buttonAnteriores1.BackColor = Color.Red;
                buttonAnteriores1.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                buttonAnteriores1.BackColor = Color.White;
                buttonAnteriores1.ForeColor = Color.DarkRed;
            }

            if (pdv == true)
            {
                try
                {
                    operador = labelOperador.Text;
                    formVendasPDV pdv = new formVendasPDV(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                    this.panelCentral.Controls.Clear();
                    this.panelCentral.Controls.Add(pdv);
                    buttonPDV1.BackColor = Color.Red;
                    buttonPDV1.ForeColor = Color.WhiteSmoke;
                    pdv.Show();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                buttonPDV1.BackColor = Color.White;
                buttonPDV1.ForeColor = Color.DarkRed;
            }
        }

        private void comboBoxReparticao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxReparticao.Text != string.Empty)
            {
                id_reparticao = (int)comboBoxReparticao.SelectedValue;
            }
        }
    }
}

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
    public partial class formVendasPDVPagamentosEntregasInformacoes : Form
    {
        string cpf;
        public bool confirmar;
        ComandosSQL comandos = new ComandosSQL();
        formVendasPDVPagamentos pai = new formVendasPDVPagamentos();
        public List<string> list = new List<string>();
        List<ProdutoVenda> lista = new List<ProdutoVenda>();
        decimal Taxa_Entrega;
        Entrega Entrega = new Entrega();

        public formVendasPDVPagamentosEntregasInformacoes()
        {
            InitializeComponent();
        }
        public formVendasPDVPagamentosEntregasInformacoes(string CPF, formVendasPDVPagamentos Pai, List<ProdutoVenda> Lista)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            cpf = CPF;
            pai = Pai;
            lista = Lista;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void formVendasPagamentoEntregas_Load(object sender, EventArgs e)
        {
            List<string> cidades = comandos.CidadesDisponiveisParaEntrega();
            foreach (string x in cidades) { comboBoxCidade.Items.Add(x); }

            //comboBoxEstado.DataSource = comandos.PreencherComboBoxEstado();
            //comboBoxEstado.ValueMember = "ID_Estado";
            //comboBoxEstado.DisplayMember = "Sigla";
            //comboBoxEstado.Text = "PE";
            //comboBoxEstado.Update();


            Entrega = comandos.TrazerInformacoesDaEntrega(cpf);

            textBoxCliente.Text = Entrega.Cliente;
            textBoxEndereco.Text = Entrega.Endereco;
            textBoxNumero.Text = Entrega.Numero;
            comboBoxBairro.Text = Entrega.Bairro;
            textBoxReferencia.Text = Entrega.Referencia;
        }
        private void buttonAgendar_Click(object sender, EventArgs e)
        {
            if (textBoxCliente.Text == string.Empty || textBoxEndereco.Text == string.Empty || textBoxNumero.Text == string.Empty || comboBoxBairro.Text == string.Empty || comboBoxCidade.Text == string.Empty || comboBoxEstado.Text == string.Empty || textBoxReferencia.Text == string.Empty || textBoxRecebedor.Text == string.Empty)
            {
                MessageBox.Show("É necessário preencher todos os campos\r\npara concluir o agendamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Entrega entrega = new Entrega();
                entrega.Endereco = textBoxEndereco.Text;
                entrega.Recebedor = textBoxRecebedor.Text;
                entrega.Bairro = comboBoxBairro.Text;
                entrega.Cidade = comboBoxCidade.Text;
                entrega.Estado = comboBoxEstado.Text;
                entrega.Valor = Taxa_Entrega;

                formVendasPDVPagamentosEntregas escolherprodutos = new formVendasPDVPagamentosEntregas(lista, this);
                escolherprodutos.ShowDialog();
                if (confirmar)
                {
                    pai.ConfirmarEntrega = true;
                    pai.listaEntrega = list;
                    pai.Entrega = entrega;
                    pai.Taxa_Entrega = Taxa_Entrega;
                    Dispose();
                }
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

        private void formVendasPagamentoEntregas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void comboBoxCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBairro.Items.Clear();
            
            string cidade = comboBoxCidade.Text;
            if (cidade != string.Empty)
            {
                List<string> bairros = comandos.BairrosDisponiveisParaEntrega(cidade);
                foreach (string x in bairros) { comboBoxBairro.Items.Add(x); }
            }

        }

        private void comboBoxBairro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cidade = comboBoxCidade.Text;
            string bairro = comboBoxBairro.Text;
            Taxa_Entrega = comandos.TaxaDeEntregaPorBairro(comboBoxCidade.Text, comboBoxBairro.Text);
            MessageBox.Show("Bairro: " + bairro + " - " + cidade + "\r\nTaxa: " + Taxa_Entrega.ToString("C"));
        }
    }
}

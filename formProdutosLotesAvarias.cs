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
    public partial class formProdutosLotesAvarias : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Produto_Lote produto = new Produto_Lote();

        int id_estabelecimento;

        public formProdutosLotesAvarias()
        {
            InitializeComponent();
        }

        public formProdutosLotesAvarias(Produto_Lote Produto)
        {
            InitializeComponent();
            produto = Produto;
        }

        private void formProdutosLotesAvarias_Load(object sender, EventArgs e)
        {
            id_estabelecimento = comandos.TrazerIdDoEstabelecimentoPelaReparticao(Program.Computador.ID_Reparticao);
            AtualizarEstabelecimentos();

            comboBoxEstabelecimentos.SelectedValue = id_estabelecimento;
        }

        private void AtualizarLocalizacoes()
        {
            comboBoxDestino.Items.Clear();

            List<string> prateleiras = comandos.ListaDePrateleirasParaAvariasDoEstabelecimento(id_estabelecimento);
            foreach (string x in prateleiras) { comboBoxDestino.Items.Add(x); }
            textBoxProduto.Text = produto.Nome;
            labelAtual.Text = "/ " + produto.Quantidade.ToString();
        }

        private void AtualizarEstabelecimentos()
        {
            comboBoxEstabelecimentos.DataSource = null;

            List<Estabelecimento> estabelecimentos = comandos.TrazerEstabelecimentos();
            comboBoxEstabelecimentos.DataSource = estabelecimentos;
            comboBoxEstabelecimentos.ValueMember = "ID_Estabelecimento";
            comboBoxEstabelecimentos.DisplayMember = "Descricao";

            comboBoxEstabelecimentos.SelectedIndex = -1;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            int quantidade = Convert.ToInt32(textBoxQuantidade.Text);
            string destino = comboBoxDestino.Text;

            if (quantidade == 0)
            {
                MessageBox.Show("Informe a quantidade para concluir o registro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (destino == string.Empty)
            {
                MessageBox.Show("Informe a prateleira de destino para concluir o registro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (quantidade > produto.Quantidade)
            {
                MessageBox.Show("A quantidade informada é maior que a quantidade de produtos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                produto.Quantidade = quantidade;
                comandos.RegistrarAvaria(produto, destino);
                Dispose();

                MessageBox.Show("Avaria registrada.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void comboBoxEstabelecimentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id_estabelecimento = (int)comboBoxEstabelecimentos.SelectedValue;
                AtualizarLocalizacoes();
            }
            catch { }
        }
    }
}

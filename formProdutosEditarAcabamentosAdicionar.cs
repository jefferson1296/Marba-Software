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
    public partial class formProdutosEditarAcabamentosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_produto;
        public formProdutosEditarAcabamentosAdicionar()
        {
            InitializeComponent();
        }
        public formProdutosEditarAcabamentosAdicionar(int ID_Produto)
        {
            InitializeComponent();
            id_produto = ID_Produto;
        }
        private void formProdutosEditarAcabamentosAdicionar_Load(object sender, EventArgs e)
        {
            List<string> Acabamentos = comandos.PreencherComboBoxAcabamentos();
            foreach (string x in Acabamentos) { comboBoxAcabamento.Items.Add(x); }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string acabamento = comboBoxAcabamento.Text;

            if (acabamento == string.Empty)
            {

                MessageBox.Show("Informe o acabamento para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //else if (!comandos.VerificarSeAcabamentoJaExiste(acabamento))
            //{
            //    MessageBox.Show("Esse acabamento xiste.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            else
            {
                Acabamento Acabamento = new Acabamento { ID_Produto = id_produto, Descricao = acabamento };
                comandos.AdicionarAcabamentoDoProduto(Acabamento);
            }
        }
    }
}

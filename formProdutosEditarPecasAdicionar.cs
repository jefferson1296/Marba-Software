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
    public partial class formProdutosEditarPecasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_produto;
        public formProdutosEditarPecasAdicionar()
        {
            InitializeComponent();
        }
        public formProdutosEditarPecasAdicionar(int ID_Produto)
        {
            InitializeComponent();
            id_produto = ID_Produto;
        }

        private void formProdutosEditarPecasAdicionar_Load(object sender, EventArgs e)
        {
            List<string> Pecas = comandos.PreencherComboBoxPecas();
            foreach(string x in Pecas) { comboBoxPeca.Items.Add(x); }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string peca = comboBoxPeca.Text;

            if (peca == string.Empty)
            {

                MessageBox.Show("Informe a peça para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!comandos.VerificarSePecaJaExiste(peca))
            {
                MessageBox.Show("Essa peça já está cadastrada.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Peca Peca = new Peca { ID_Produto = id_produto, Nome_Peca = peca };
                comandos.AdicionarPecaDoProduto(Peca);
            }
        }
    }
}

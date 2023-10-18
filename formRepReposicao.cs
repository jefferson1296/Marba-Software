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
    public partial class formRepReposicao : Form
    {
        public formRepReposicao()
        {
            InitializeComponent();
        }

        private void formRepReposicao_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'DataSetReposicao.ProdutosDaReposicao'. Você pode movê-la ou removê-la conforme necessário.
            //this.ProdutosDaReposicaoTableAdapter.Fill(this.DataSetReposicao.ProdutosDaReposicao);

            this.reportViewer1.RefreshReport();
        }
    }
}

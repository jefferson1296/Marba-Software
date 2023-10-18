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
    public partial class formRepDirecionamento : Form
    {
        public formRepDirecionamento()
        {
            InitializeComponent();
        }

        private void formRepDirecionamento_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'DataSetDirecionamento.ProdutosParaDirecionamento'. Você pode movê-la ou removê-la conforme necessário.
            //this.ProdutosParaDirecionamentoTableAdapter.Fill(this.DataSetDirecionamento.ProdutosParaDirecionamento);

            this.reportViewer1.RefreshReport();
        }
    }
}

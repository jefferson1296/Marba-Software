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
    public partial class formRelatorioReposicaoLoja : Form
    {
        public formRelatorioReposicaoLoja()
        {
            InitializeComponent();
        }

        private void formRelatoriosCupom_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bd_MarbaDataSet1.tbl_Reposicao'. Você pode movê-la ou removê-la conforme necessário.
            this.tbl_ReposicaoTableAdapter.Fill(this.bd_MarbaDataSet1.tbl_Reposicao);

            this.reportViewer1.RefreshReport();
        }
    }
}

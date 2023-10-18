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
    public partial class formRepQuarentena : Form
    {
        int id_quarentena;

        public formRepQuarentena()
        {
            InitializeComponent();
        }

        public formRepQuarentena(int ID_Quarentena)
        {
            InitializeComponent();
            id_quarentena = ID_Quarentena;
        }

        private void formRepQuarentena_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'DataSetQuarentena.ProdutosDaQuarentena'. Você pode movê-la ou removê-la conforme necessário.
            
            ProdutosDaQuarentenaTableAdapter.Fill(DataSetQuarentena.ProdutosDaQuarentena, id_quarentena);
            reportViewer1.RefreshReport();
        }
    }
}

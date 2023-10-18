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
    public partial class formRepPlanoDeAcao : Form
    {
        int id;

        public formRepPlanoDeAcao()
        {
            InitializeComponent();
        }

        public formRepPlanoDeAcao(int ID)
        {
            InitializeComponent();
            id = ID;
        }

        private void formRepPlanoDeAcao_Load(object sender, EventArgs e)
        {
            EtapasDoPlanoDeAcaoTableAdapter.Fill(dataSetEtapasDoPlano.EtapasDoPlanoDeAcao, id);
            CustosDoPlanoDeAcaoTableAdapter.Fill(dataSetCustosDoPlano.CustosDoPlanoDeAcao, id);

            reportViewer1.RefreshReport();
        }
    }
}

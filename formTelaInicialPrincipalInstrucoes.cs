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
    public partial class formTelaInicialPrincipalInstrucoes : Form
    {
        public formTelaInicialPrincipalInstrucoes()
        {
            InitializeComponent();
        }

        private void buttonAtividades_Click(object sender, EventArgs e)
        {
            formTelaInicialAtividades atividades = new formTelaInicialAtividades();
            atividades.ShowDialog();
        }

        private void buttonRegulamento_Click(object sender, EventArgs e)
        {
            formGestaoRegulamentos regulamentos = new formGestaoRegulamentos();
            regulamentos.ShowDialog();
        }

        private void buttonCursos_Click(object sender, EventArgs e)
        {
            formGestaoCursos cursos = new formGestaoCursos();
            cursos.ShowDialog();
        }
    }
}

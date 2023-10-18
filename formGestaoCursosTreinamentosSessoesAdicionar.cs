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
    public partial class formGestaoCursosTreinamentosSessoesAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id_sessao;
        bool cadastramento;

        Sessao sessao = new Sessao();

        public formGestaoCursosTreinamentosSessoesAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formGestaoCursosTreinamentosSessoesAdicionar(int ID_Sessao)
        {
            InitializeComponent();
            id_sessao = ID_Sessao;
            cadastramento = false;
        }

        private void formGestaoTreinamentosSessoesAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                sessao = comandos.TrazerInformacoesDaSessao(id_sessao);
                textBoxSessao.Text = sessao.Descricao;
                textBoxDetalhes.Text = sessao.Detalhes;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxSessao.Text;
            string detalhes = textBoxDetalhes.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a sessão para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sessao.Descricao = descricao;
                sessao.Detalhes = detalhes;

                if (cadastramento)
                {
                    comandos.CadastrarSessao(sessao);
                }
                else
                {
                    comandos.EditarSessao(sessao);
                }

                Dispose();
            }
        }
    }
}

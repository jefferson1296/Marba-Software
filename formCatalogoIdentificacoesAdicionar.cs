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
    public partial class formCatalogoIdentificacoesAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool cadastramento;
        Identificacao Identificacao = new Identificacao();
        public formCatalogoIdentificacoesAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }
        public formCatalogoIdentificacoesAdicionar(int ID_Identificacao)
        {
            InitializeComponent();
            Identificacao.ID_Identificacao = ID_Identificacao;
            cadastramento = false;
        }

        private void formPrateleirasIdentificacoesAdicionar_Load(object sender, EventArgs e)
        {
            List<string> setores = comandos.preencherComboSetores();
            foreach (string x in setores) { comboBoxSetor.Items.Add(x); }

            if (!cadastramento)
            {
                Text = "Editar identificação";
                Identificacao = comandos.InformacoesDaIdentificacao(Identificacao.ID_Identificacao);
                textBoxDescricao.Text = Identificacao.Descricao;
                comboBoxSetor.SelectedItem = Identificacao.Setor;
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string identificacao = textBoxDescricao.Text;
            string setor = comboBoxSetor.Text;
            bool impressao_auto = checkBoxAuto.Checked;

            if (identificacao == string.Empty)
            {
                MessageBox.Show("Informe a identificação para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comandos.VerificarSeIdentificacaoJaExiste(identificacao))
            {
                MessageBox.Show("Já existe uma identificação com essa descrição!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (setor == string.Empty)
            {
                MessageBox.Show("Informe o setor para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Identificacao.Descricao = identificacao;
                Identificacao.Setor = setor;
                Identificacao.Auto_Impressao = impressao_auto;

                if (cadastramento)
                {
                    comandos.CadastrarIdentifacao(Identificacao);
                }
                else
                {
                    comandos.EditarIdentifacao(Identificacao);
                }

                Dispose();
            }
        }
    }
}

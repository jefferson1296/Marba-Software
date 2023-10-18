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
    public partial class formCatalogoLinhasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool cadastramento;
        public Linha linha = new Linha();

        public bool alteracao_markup;

        public formCatalogoLinhasAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }
        public formCatalogoLinhasAdicionar(Linha Linha)
        {
            InitializeComponent();
            linha = Linha;
            cadastramento = false;
        }

        private void formCatalogoLinhasAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                textBoxDescricao.Text = linha.Descricao;
                textBoxMarketing.Text = linha.Marketing;
                textBoxMarkup.Text = linha.Markup.ToString("F") + "%";
                checkBoxAtivacao.Checked = linha.Ativacao;
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string marketing = textBoxMarketing.Text;
            bool ativacao = checkBoxAtivacao.Checked;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a linha para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (marketing == string.Empty)
            {
                MessageBox.Show("Informe frase de marketing para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (linha.Markup == 0)
            {
                MessageBox.Show("Calcule o Markup para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                linha.Descricao = descricao;
                linha.Marketing = marketing;
                linha.Ativacao = ativacao;

                if (cadastramento)
                {
                    comandos.CadastrarLinha(linha);
                }
                else
                {
                    comandos.EditarLinha(linha);

                    if (alteracao_markup)
                    {
                        comandos.EditarMarkup(linha);
                    }
                }

                Dispose();
            }
        }

        private void buttonMarkup_Click(object sender, EventArgs e)
        {
            formCatalogoLinhasAdicionarMarkup calcular = new formCatalogoLinhasAdicionarMarkup(this);
            calcular.ShowDialog();

            textBoxMarkup.Text = linha.Markup.ToString("F");
            textBoxLucro.Text = linha.Lucro.ToString("F") + '%';
        }
    }
}

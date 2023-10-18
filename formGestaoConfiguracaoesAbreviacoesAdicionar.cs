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
    public partial class formGestaoConfiguracaoesAbreviacoesAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Abreviacao abreviacao = new Abreviacao();
        bool cadastramento;

        public formGestaoConfiguracaoesAbreviacoesAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }
        public formGestaoConfiguracaoesAbreviacoesAdicionar(Abreviacao Abreviacao)
        {
            InitializeComponent();
            abreviacao = Abreviacao;
            cadastramento = false;
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string texto = textBoxTexto.Text;
            string abreviacao = textBoxAbreviacao.Text;

            if (texto == string.Empty)
            {
                MessageBox.Show("Informe o termo que deseja abreviar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (abreviacao == string.Empty)
            {
                MessageBox.Show("Informe a abreviação da palavra!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (cadastramento)
                {
                    if (comandos.VerificarSePalavraJaContemAbreviacao(texto))
                    {
                        MessageBox.Show("Já existe uma abreviação para esse termo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Abreviacao Abreviacao = new Abreviacao { Texto = texto, Descricao = abreviacao };
                        comandos.CadastrarAbreviacao(Abreviacao);
                        Dispose();
                    }
                }
                else
                {
                    this.abreviacao.Descricao = abreviacao;
                    comandos.EditarAbreviacao(this.abreviacao);
                    Dispose();
                }
            }
        }

        private void formGestaoConfiguracaoesAbreviacoesAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                Text = "Editar abreviação";
                textBoxTexto.ReadOnly = true;
                textBoxTexto.BackColor = Color.WhiteSmoke;
                textBoxTexto.Text = abreviacao.Texto;
                textBoxAbreviacao.Text = abreviacao.Descricao;
            }
        }
    }
}

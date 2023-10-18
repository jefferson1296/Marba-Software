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
    public partial class formProdutosAjustesPrateleirasArmazenamentosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Armazenamento armazenamento = new Armazenamento();
        bool cadastramento;
        public formProdutosAjustesPrateleirasArmazenamentosAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formProdutosAjustesPrateleirasArmazenamentosAdicionar(Armazenamento Armazenamento)
        {
            InitializeComponent();
            armazenamento = Armazenamento;
            cadastramento = false;
        }

        private void formProdutosAjustesPrateleirasArmazenamentosAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                textBoxDescricao.Text = armazenamento.Descricao;
                textBoxObs.Text = armazenamento.Detalhes;
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                armazenamento.Descricao = descricao;
                armazenamento.Detalhes = textBoxObs.Text;

                if (cadastramento)
                {
                    comandos.CadastrarArmazenamento(armazenamento);
                }
                else
                {
                    comandos.EditarArmazenamento(armazenamento);
                }

                Dispose();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}

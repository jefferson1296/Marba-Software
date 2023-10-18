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
    public partial class formGestaoRegulamentosAdicionarTopicos : Form
    {
        formGestaoRegulamentosAdicionar pai = new formGestaoRegulamentosAdicionar();
        Topico_Regulamento topico = new Topico_Regulamento();
        bool cadastramento;

        public formGestaoRegulamentosAdicionarTopicos()
        {
            InitializeComponent();
        }
        public formGestaoRegulamentosAdicionarTopicos(formGestaoRegulamentosAdicionar Pai)
        {
            InitializeComponent();
            pai = Pai;
            cadastramento = true;
        }

        public formGestaoRegulamentosAdicionarTopicos(formGestaoRegulamentosAdicionar Pai, Topico_Regulamento Topico)
        {
            InitializeComponent();
            pai = Pai;
            topico = Topico;
            cadastramento = false;
        }

        private void formGestaoRegulamentosAdicionarTopicos_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                textBoxTopico.Text = topico.Topico;
                textBoxDetalhes.Text = topico.Detalhes;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string topico = textBoxTopico.Text;
            string detalhes = textBoxDetalhes.Text;

            if (topico == string.Empty)
            {
                MessageBox.Show("Informe o tópico para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (detalhes == string.Empty)
            {
                MessageBox.Show("Informe os detalhes para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (pai.topicos.Any(x => x.Topico == topico) && topico != this.topico.Topico)
            {
                MessageBox.Show("Esse regulamento já possui um tópico com esse nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!cadastramento)
                {
                    foreach (Topico_Regulamento Topico in pai.topicos)
                    {
                        if (Topico.Ordem == this.topico.Ordem)
                        {
                            Topico.Topico = topico;
                            Topico.Detalhes = detalhes;
                        }
                    }
                }
                else
                {
                    Topico_Regulamento Topico = new Topico_Regulamento();
                    Topico.Topico = topico;
                    Topico.Detalhes = detalhes;
                    Topico.Ordem = pai.topicos.Count + 1;
                    pai.topicos.Add(Topico);
                }

                pai.alteracao = true;
                Dispose();
            }
        }
    }
}

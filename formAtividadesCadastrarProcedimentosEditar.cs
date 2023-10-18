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
    public partial class formAtividadesCadastrarProcedimentosEditar : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        formAtividadesCadastrar form_cadastrar = new formAtividadesCadastrar();
        formAtividadesEditar form_editar = new formAtividadesEditar();

        bool cadastramento;
        int ordem;

        public formAtividadesCadastrarProcedimentosEditar()
        {
            InitializeComponent();
        }
        public formAtividadesCadastrarProcedimentosEditar(formAtividadesCadastrar Form_cadastrar, int Ordem)
        {
            InitializeComponent();
            form_cadastrar = Form_cadastrar;
            cadastramento = true;
            ordem = Ordem;
        }
        public formAtividadesCadastrarProcedimentosEditar(formAtividadesEditar Form_editar, int Ordem)
        {
            InitializeComponent();
            form_editar = Form_editar;
            cadastramento = false;
            ordem = Ordem;
        }

        private void formAtividadesCadastrarProcedimentosEditar_Load(object sender, EventArgs e)
        {
            if (cadastramento)
            {
                textBoxResumo.Text = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem).Select(x => x.Resumo).FirstOrDefault();
                textBoxProcedimento.Text = form_cadastrar.Procedimentos.Where(x => x.Ordem == ordem).Select(x => x.Descricao).FirstOrDefault();
            }
            else
            {
                textBoxResumo.Text = form_editar.Procedimentos.Where(x => x.Ordem == ordem).Select(x => x.Resumo).FirstOrDefault();
                textBoxProcedimento.Text = form_editar.Procedimentos.Where(x => x.Ordem == ordem).Select(x => x.Descricao).FirstOrDefault();
            }

            textBoxResumo.SelectionStart = textBoxResumo.Text.Length;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string descricao = textBoxProcedimento.Text;
            string titulo = textBoxResumo.Text;

            if (titulo == string.Empty)
            {
                MessageBox.Show("Informe o título do procedimento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cadastramento)
                {
                    foreach(Procedimento procedimento in form_cadastrar.Procedimentos)
                    {
                        if (procedimento.Ordem == ordem)
                        {
                            procedimento.Resumo = titulo;
                            procedimento.Descricao = descricao;
                        }
                    }
                }
                else
                {
                    int id_procedimento = form_editar.Procedimentos.Where(x => x.Ordem == ordem).Select(x => x.ID_Procedimento).FirstOrDefault();
                    Procedimento procedimento = new Procedimento { ID_Procedimento = id_procedimento, Descricao = descricao, Resumo = titulo };
                    comandos.EditarProcedimento(procedimento);
                    form_editar.AtualizarProcedimentos();
                }

                Dispose();
            }
        }
    }
}

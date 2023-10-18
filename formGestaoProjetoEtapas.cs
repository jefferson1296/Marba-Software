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
    public partial class formGestaoProjetoEtapas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formGestaoFerramentasPlanosAdicionar pai = new formGestaoFerramentasPlanosAdicionar();
        public Etapa etapa = new Etapa();
        public bool cadastramento;

        public List<Checklist> checklist = new List<Checklist>();

        public formGestaoProjetoEtapas()
        {
            InitializeComponent();
        }

        public formGestaoProjetoEtapas(formGestaoFerramentasPlanosAdicionar Pai)
        {
            InitializeComponent();
            pai = Pai;
            cadastramento = true;
        }

        public formGestaoProjetoEtapas(formGestaoFerramentasPlanosAdicionar Pai, Etapa Etapa)
        {
            InitializeComponent();
            pai = Pai;
            etapa = Etapa;
            cadastramento = false;
        }

        private void formGestaoProjetoEtapas_Load(object sender, EventArgs e)
        {
            List<Colaborador> colaboradores = comandos.PreencherComboColaboradores();
            comboBoxResponsavel.DataSource = colaboradores;
            comboBoxResponsavel.DisplayMember = "Nome_Colaborador";
            comboBoxResponsavel.ValueMember = "ID_Colaborador";
            comboBoxResponsavel.SelectedIndex = -1;

            if (cadastramento)
            {
                etapa.Ordem = pai.Projeto.Etapas.Count + 1;
            }
            else
            {
                textBoxDescricao.Text = etapa.O_Que;
                textBoxDescricao.SelectionStart = textBoxDescricao.Text.Length;
                textBoxComo.Text = etapa.Como;
                comboBoxResponsavel.Text = etapa.Quem;
                textBoxPrazo.Text = etapa.Prazo.ToString();
                dateTimePicker.Value = etapa.Previsao_Inicio;

                AtualizarChecklist();
            }
        }

        public void AtualizarChecklist()
        {
            if (pai.cadastramento)
            {
                checklist = pai.Projeto.Checklist.Where(x => x.Referencia == etapa.Ordem).ToList();
            }
            else
            {
                checklist = pai.Projeto.Checklist.Where(x => x.Referencia == etapa.ID_Etapa).ToList();
            }
        }

        private void textBoxPrazo_Enter(object sender, EventArgs e)
        {
            if (textBoxPrazo.Text == "0")
                textBoxPrazo.Text = string.Empty;
        }

        private void textBoxPrazo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxPrazo_Leave(object sender, EventArgs e)
        {
            if (textBoxPrazo.Text == string.Empty)
                textBoxPrazo.Text = "0";
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string como = textBoxComo.Text;
            string responsavel = comboBoxResponsavel.Text;
            int prazo = Convert.ToInt32(textBoxPrazo.Text);
            DateTime previsao_inicio = dateTimePicker.Value.Date;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //else if (como == string.Empty)
            //{
            //    MessageBox.Show("Informe como a atividade deve ser realizada para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else if (responsavel == string.Empty)
            //{
            //    MessageBox.Show("Informe o responsável para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else if (prazo == 0)
            //{
            //    MessageBox.Show("Informe o prazo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else if (previsao_inicio.Date < DateTime.Now.Date)
            //{
            //    MessageBox.Show("Informe uma previsão de início válida!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            else
            {
                //Se estiver cadastrando o projeto e cadastrando a etapa: Insere na lista do projeto, que será cadastrado por completo
                //Se estiver cadastrando o projeto e editando a etapa:    Insere na lista do projeto, que será cadastrado por completo
                //Se estiver editando o projeto e cadastrando a etapa:    Insere na lista do projeto
                //Se estiver editando o projeto e editando a etapa:       Insere diretamente no banco de dados

                etapa.O_Que = descricao;
                etapa.Como = como;
                etapa.Quem = responsavel;
                etapa.Prazo = prazo;
                etapa.Previsao_Inicio = previsao_inicio;

                if (pai.cadastramento)
                {
                    if (cadastramento)
                    {
                        pai.Projeto.Etapas.Add(etapa);
                        pai.Projeto.Checklist.AddRange(checklist);
                    }
                    else
                    {
                        foreach (Etapa Etapa in pai.Projeto.Etapas)
                        {
                            if (Etapa.Ordem == etapa.Ordem)
                            {
                                Etapa.O_Que = descricao;
                                Etapa.Como = como;
                                Etapa.Quem = responsavel;
                                Etapa.Prazo = prazo;
                                Etapa.Previsao_Inicio = previsao_inicio;
                            }
                        }

                        pai.Projeto.Checklist.RemoveAll(x => x.Referencia == etapa.Ordem);
                        pai.Projeto.Checklist.AddRange(checklist);
                    }
                }
                else
                {
                    if (cadastramento)
                    {
                        comandos.AdicionarEtapaDoPlanoDeAcao(etapa, checklist, pai.id_projeto);
                    }
                    else
                    {
                        comandos.EditarEtapaDoPlanoDeAcao(etapa);
                    }

                    pai.AtualizarEtapas();
                    pai.AtualizarChecklist();
                }

                Dispose();
            }
        }

        private void pictureBoxCheck_Click(object sender, EventArgs e)
        {
            formGestaoProjetoEtapasChecklist checklist = new formGestaoProjetoEtapasChecklist(this);
            checklist.ShowDialog();
        }

        private void labelCheck_Click(object sender, EventArgs e)
        {
            formGestaoProjetoEtapasChecklist checklist = new formGestaoProjetoEtapasChecklist(this);
            checklist.ShowDialog();
        }
    }
}

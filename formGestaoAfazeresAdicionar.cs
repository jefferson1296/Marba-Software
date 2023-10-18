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
    public partial class formGestaoAfazeresAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formGestaoAfazeres pai = new formGestaoAfazeres();

        Afazer afazer = new Afazer();
        bool cadastramento;
        DateTime data = new DateTime();

        public formGestaoAfazeresAdicionar()
        {
            InitializeComponent();
        }

        public formGestaoAfazeresAdicionar(DateTime Data)
        {
            InitializeComponent();
            cadastramento = true;
            afazer.Data = Data;
        }

        public formGestaoAfazeresAdicionar(Afazer Afazer)
        {
            InitializeComponent();
            cadastramento = true;
            afazer = Afazer;
        }

        public formGestaoAfazeresAdicionar(int ID_Afazer, formGestaoAfazeres Pai)
        {
            InitializeComponent();
            afazer.ID_Afazer = ID_Afazer;
            cadastramento = false;
            pai = Pai;
        }

        private void formGestaoAfazeresAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                comandos.TrazerInformacoesDoAfazer(afazer);
                data = afazer.Data;

                textBoxDescricao.Text = afazer.Descricao;
                textBoxDetalhes.Text = afazer.Detalhes;
                textBoxTempo.Text = afazer.Minutos.ToString();
                dateTimePicker.Value = afazer.Data;

                textBoxDescricao.SelectionStart = textBoxDescricao.Text.Length;
            }
            else
            {
                if (afazer.ID_Etapa != 0)
                {
                    textBoxDescricao.Text = afazer.Descricao;
                    textBoxDetalhes.Text = afazer.Detalhes;
                }
                else
                {
                    dateTimePicker.Value = afazer.Data;
                }
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string detalhes = textBoxDetalhes.Text;
            int tempo = Convert.ToInt32(textBoxTempo.Text);
            DateTime data = dateTimePicker.Value.Date;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                afazer.Descricao = descricao;
                afazer.Detalhes = detalhes;
                afazer.Minutos = tempo;
                afazer.Data = data;

                if (cadastramento)
                {
                    comandos.AdicionarAfazer(afazer);

                    MessageBox.Show("Lista de afazeres atualizada.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    comandos.EditarAfazer(afazer);

                    if (data.Date != this.data.Date)
                    {
                        int ordem = afazer.Ordem;

                        foreach (Afazer afazer in pai.afazeres)
                        {
                            if (afazer.Ordem > this.afazer.Ordem)
                            {
                                comandos.AlterarOrdemDoAfazer(afazer.ID_Afazer, ordem);
                                ordem++;
                            }
                        }
                    }
                }

                Dispose();
            }
        }

        private void textBoxTempo_Enter(object sender, EventArgs e)
        {
            if (textBoxTempo.Text == "0")
                textBoxTempo.Clear();
        }

        private void textBoxTempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxTempo_Leave(object sender, EventArgs e)
        {
            if (textBoxTempo.Text == string.Empty)
                textBoxTempo.Text = "0";
        }
    }
}

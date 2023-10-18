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
    public partial class formProdutosAjustesPrateleirasExpositoresAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Expositor expositor = new Expositor();
        bool cadastramento;

        bool imagem_alterada;

        public formProdutosAjustesPrateleirasExpositoresAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }
        public formProdutosAjustesPrateleirasExpositoresAdicionar(Expositor Expositor)
        {
            InitializeComponent();
            expositor = Expositor;
            cadastramento = false;
        }

        private void formProdutosAjustesPrateleirasExpositoresAdicionar_Load(object sender, EventArgs e)
        {
            if (!cadastramento)
            {
                try
                {
                    pictureBoxImagem.Image = comandos.ConverterArrayDeBytesParaImagem(expositor.Imagem);
                }
                catch { }

                textBoxDescricao.Text = expositor.Descricao;
                textBoxObs.Text = expositor.Detalhes;
            }

            if (pictureBoxImagem.Image == null)
            {
                pictureBoxImagem.Image = comandos.TrazerImagemPeloNome("SEM FOTO");
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
                expositor.Descricao = descricao;
                expositor.Detalhes = textBoxObs.Text;

                bool permitir = true;

                if (cadastramento)
                {
                    if (pictureBoxImagem.Image != null)
                    {
                        expositor.Imagem = comandos.ConverteImagemParaArrayDeBytes(pictureBoxImagem.Image);

                        if (comandos.VerificarSeNomeDaImagemJaExiste(expositor.Descricao))
                        {
                            MessageBox.Show("Esse nome já está sendo utilizado por outra imagem.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            permitir = false;
                        }
                        else
                        {
                            comandos.CadastrarImagemDoExpositor(expositor);
                        }                  
                    }

                    if (permitir)
                    {
                        comandos.CadastrarExpositor(expositor);
                        Dispose();
                    }
                }
                else
                {
                    if (pictureBoxImagem.Image != null && imagem_alterada)
                    {

                        if(expositor.ID_Imagem != 0)
                        {
                            comandos.EditarImagemDoExpositor(expositor);
                        }
                        else
                        {
                            comandos.CadastrarImagemDoExpositor(expositor);
                        }
                    }

                    if (permitir)
                    {
                        comandos.EditarExpositor(expositor);
                        Dispose();
                    }
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Arquivos de imagens jpg e png|*.jpg; *png";
            dialogo.Multiselect = false;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                string caminho = dialogo.FileName;

                if (caminho != "")
                {
                    try
                    {
                        pictureBoxImagem.Load(caminho);
                        imagem_alterada = true;
                    }
                    catch { }
                }
            }
        }
    }
}

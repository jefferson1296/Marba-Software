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
    public partial class formCatalogoImagens : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        Catalogo produto = new Catalogo();
        Imagem_Produto imagem = new Imagem_Produto();

        List<Imagem_Produto> Imagens = new List<Imagem_Produto>();
        int imagem_atual;

        int percentual;

        public formCatalogoImagens()
        {
            InitializeComponent();
        }
        public formCatalogoImagens(Catalogo Produto)
        {
            InitializeComponent();
            produto = Produto;
        }
        private void formCatalogoImagens_Load(object sender, EventArgs e)
        {
            percentual = 100;

            AtualizarComboImagens();
            AtualizarListaDeImagens();
            AtualizarImagem();

            imagem.Nome = produto.Nome;

            textBoxProduto.Text = imagem.Nome;
            labelVenda.Text = produto.Preco_Venda.ToString("F");
        }



        #region Botões
        private void buttonApagar_Click(object sender, EventArgs e)
        {
            if (imagem_atual > 0)
            {
                ApagarImagem();

                AtualizarComboImagens();
                AtualizarListaDeImagens();

                //comboBoxImagem.SelectedItem = descricao;
            }
        }
        private void buttonInserir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Arquivos de imagens jpg e png|*.jpg; *png";
            dialogo.Multiselect = false;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                imagem.Caminho = dialogo.FileName;

                if (imagem.Caminho != "")
                {
                    try
                    {
                        pictureBoxImagem.Load(imagem.Caminho);
                        comboBoxImagem.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBoxImagem.SelectedIndex = -1;
                        comboBoxImagem.Focus();
                        buttonSalvar.Visible = true;
                    }
                    catch { }
                }
            }
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            string descricao = comboBoxImagem.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe o nome da imagem para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comandos.VerificarSeNomeDaImagemJaExiste(descricao))
            {
                MessageBox.Show("Já existe uma imagem registrada com esse nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                imagem.Descricao = descricao;
                comandos.InserirImagem(imagem);
                comandos.VincularImagemAoProduto(produto.ID_Catalogo);
                buttonSalvar.Visible = false;
                AtualizarComboImagens();
                AtualizarListaDeImagens();
                comboBoxImagem.SelectedItem = descricao;
                comboBoxImagem.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private void buttonExportar_Click(object sender, EventArgs e)
        {
            if (imagem_atual > 0)
            {
                SalvarImagem();
            }
        }
        private void pbProximo_Click(object sender, EventArgs e)
        {
            imagem_atual = Convert.ToInt32(textBoxAtual.Text);

            if (imagem_atual < Imagens.Count)
            {
                imagem_atual = imagem_atual + 1;
                comboBoxImagem.SelectedItem = Imagens.Where(x => x.Index == imagem_atual).Select(x => x.Descricao).FirstOrDefault();
                AtualizarImagem();
            } 
        }
        private void pbAnterior_Click(object sender, EventArgs e)
        {
            imagem_atual = Convert.ToInt32(textBoxAtual.Text);

            if (imagem_atual > 1)
            {
                imagem_atual = imagem_atual - 1;
                comboBoxImagem.SelectedItem = Imagens.Where(x => x.Index == imagem_atual).Select(x => x.Descricao).FirstOrDefault();
                AtualizarImagem();
            }
        }
        #endregion

        #region Eventos

        private void textBoxAtual_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int total = Convert.ToInt32(textBoxTotal.Text);
                int atual = Convert.ToInt32(textBoxAtual.Text);

                if (atual <= total)
                {
                    imagem_atual = atual;
                    AtualizarImagem();
                }
            }
            catch { }
        }

        private void textBoxAtual_Enter(object sender, EventArgs e)
        {
            textBoxAtual.SelectionStart = textBoxAtual.Text.Length;
        }

        private void textBoxAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        private void textBoxAtual_Leave(object sender, EventArgs e)
        {
            if (textBoxAtual.Text == string.Empty)
            {
                if (Imagens.Count > 0)
                {
                    imagem_atual = 1;
                    AtualizarImagem();
                }
                else
                {
                    imagem_atual = 0;
                    textBoxAtual.Text = "0";
                }
            }
            else
            {
                try
                {
                    int total = Convert.ToInt32(textBoxTotal.Text);
                    int atual = Convert.ToInt32(textBoxAtual.Text);

                    if (atual > total)
                    {
                        imagem_atual = total;
                    }
                    else
                    {
                        imagem_atual = atual;
                    }

                    AtualizarImagem();
                }
                catch { }
            }
        }
        private void textBoxDimensao_Leave(object sender, EventArgs e)
        {
            if (textBoxDimensao.Text == string.Empty)
            {
                percentual = 0;
            }
            else
            {
                percentual = Convert.ToInt32(textBoxDimensao.Text);
            }

            textBoxDimensao.Text = percentual.ToString() + "%";

            Image Nova_Imagem = RedimensionarImagem(pictureBoxImagem.Image);
            LimparImagem();
            pictureBoxImagem.Image = Nova_Imagem;

        }

        private void textBoxDimensao_Enter(object sender, EventArgs e)
        {
            if (textBoxDimensao.Text == "0%")
            {
                textBoxDimensao.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxDimensao.Text.Split('%');
                textBoxDimensao.Text = partir[0];
            }
        }

        private void textBoxDimensao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Métodos
        private void comboBoxImagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string descricao = comboBoxImagem.Text;

            if (descricao != string.Empty)
            {
                imagem_atual = Imagens.Where(x => x.Descricao == descricao).Select(x => x.Index).FirstOrDefault();
                AtualizarImagem();
            }
        }

        private void AtualizarComboImagens()
        {
            comboBoxImagem.Items.Clear();
            List<string> Linhas = comandos.PreencherComboImagens(produto.ID_Catalogo);
            foreach (string x in Linhas) { comboBoxImagem.Items.Add(x); }
            comboBoxImagem.DropDownHeight = 120;
        }

        private void AtualizarListaDeImagens()
        {
            Imagens = comandos.ListaDeImagens(produto.ID_Catalogo);
            int total = Imagens.Count;

            if (total > 0)
            {
                imagem_atual = 1;
                comboBoxImagem.SelectedItem = Imagens.Where(x => x.Index == imagem_atual).Select(x => x.Descricao).FirstOrDefault();
                AtualizarImagem();
            }
            else
            {
                imagem_atual = 0;
            }

            textBoxTotal.Text = total.ToString();
        }

        private void AtualizarImagem()
        {
            if (Imagens.Count > 0)
            {
                byte[] array = Imagens.Where(x => x.Index == imagem_atual).Select(x => x.Imagem).FirstOrDefault();

                Image imagem = comandos.ConverterArrayDeBytesParaImagem(array);

                LimparImagem();

                pictureBoxImagem.Image = imagem;
                textBoxAtual.Text = imagem_atual.ToString();
            }
        }

        private void SalvarImagem()
        {
            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.FileName = comboBoxImagem.Text;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                string nome = dialogo.FileName;

                if (nome != "")
                {
                    try
                    {
                        pictureBoxImagem.Image.Save(nome + ".jpg", pictureBoxImagem.Image.RawFormat);
                        MessageBox.Show("Imagem " + nome + " gerada com sucesso!");
                    }
                    catch { }
                }
            }
        }

        private void ApagarImagem()
        {
            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar a imagem do catálogo?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                int id_imagem = Imagens.Where(x => x.Index == imagem_atual).Select(x => x.ID_Imagem).FirstOrDefault();
                comandos.ApagarImagemDoCatalogo(produto.ID_Catalogo, id_imagem);
                LimparImagem();

                if (DialogResult.Yes == MessageBox.Show("A imagem foi apagada do catálogo.\r\n\r\nAlém disso deseja apagar a imagem do sistema?", "Imagem apagada!", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    comandos.ApagarImagem(id_imagem);
                }
            }
        }

        private void LimparImagem()
        {
            if (pictureBoxImagem.Image != null)
            {
                pictureBoxImagem.Image.Dispose();
                pictureBoxImagem.Image = null;
            }
        }

        public Image RedimensionarImagem(Image Imagem)
        {
            // Prevent using images internal thumbnail
            Imagem.RotateFlip(RotateFlipType.Rotate180FlipNone);
            Imagem.RotateFlip(RotateFlipType.Rotate180FlipNone);


            int altura = Imagem.Height / 100 * percentual;
            int largura = Imagem.Width / 100 * percentual;


            Image Nova_Imagem = Imagem.GetThumbnailImage(largura, altura, null, IntPtr.Zero);

            return Nova_Imagem;
        }
        #endregion
    }
}

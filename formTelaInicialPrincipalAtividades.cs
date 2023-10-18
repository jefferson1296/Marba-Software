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
    public partial class formTelaInicialPrincipalAtividades : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool centralizar = false;

        AtividadeLancada atividade = new AtividadeLancada();

        Point coordenada_imagem = new Point();
        List<Colaborador> colaboradores = new List<Colaborador>();
        List<int> registros = new List<int>();

        string colaborador;
        int id_colaborador;

        bool arrastar;
        bool soltar;

        public formTelaInicialPrincipalAtividades()
        {
            InitializeComponent();
        }

        private void formTelaInicialPrincipalAtividades_Load(object sender, EventArgs e)
        {
            coordenada_imagem.X = 15;
            coordenada_imagem.Y = 12;

            colaboradores = comandos.ListaDeColaboradoresDoSetor();
            AtualizarQuadroDeFuncionarios();
        }

        private void AtualizarQuadroDeFuncionarios()
        {
            panelColaboradores.Controls.Clear();

            foreach (Colaborador colaborador in colaboradores)
            {
                PictureBox picture = new PictureBox();
                picture.Location = coordenada_imagem;
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                picture.Name = "pictureBox1";
                picture.Size = new Size(75, 75);
                picture.BackColor = Color.White;
                picture.Image = comandos.ConverterArrayDeBytesParaImagem(colaborador.Foto);
                panelColaboradores.Controls.Add(picture);

                Font minhafonte = new Font("Arial", 6, FontStyle.Regular, GraphicsUnit.Point);
                Font fonte2 = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);

                Label label_nome = new Label();
                label_nome.Font = fonte2;
                label_nome.ForeColor = Color.Black;
                panelColaboradores.Controls.Add(label_nome);

                label_nome.Name = colaborador.ID_Colaborador.ToString();
                label_nome.Text = colaborador.Nome_Colaborador;
                label_nome.AutoSize = true;
                int x = picture.Left + picture.Width / 2 - label_nome.Width / 2;
                int y = coordenada_imagem.Y + picture.Height + 5;
                label_nome.Location = new Point(x, y);

                Label label_matricula = new Label();
                label_matricula.Font = minhafonte;
                label_matricula.ForeColor = Color.Black;
                panelColaboradores.Controls.Add(label_matricula);
                label_matricula.Text = colaborador.Matricula;
                label_matricula.AutoSize = true;
                x = picture.Left + picture.Width / 2 - label_matricula.Width / 2;
                y = coordenada_imagem.Y + picture.Height + 20;
                label_matricula.Location = new Point(x, y);

                Label label_status = new Label();
                label_status.Font = minhafonte;
                label_status.ForeColor = Color.Black;
                panelColaboradores.Controls.Add(label_status);
                label_status.Text = colaborador.Status;
                label_status.AutoSize = true;
                x = picture.Left + picture.Width / 2 - label_status.Width / 2;
                y = coordenada_imagem.Y + picture.Height + 30;
                label_status.Location = new Point(x, y);

                label_nome.Click += new EventHandler(label_Click);
                registros.Add(registros.Count + 1);

                label_nome.MouseDown += new MouseEventHandler(label_MouseDown);
                label_nome.MouseMove += new MouseEventHandler(label_MouseMove);

                coordenada_imagem.X = coordenada_imagem.X + 90;
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;

            //MessageBox.Show("Testando..." + "\r\n" + label.Name);

            id_colaborador = Convert.ToInt32(label.Name);
            colaborador = label.Text;

            arrastar = true;
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;

            //MessageBox.Show("Testando..." + "\r\n" + label.Name);

            id_colaborador = Convert.ToInt32(label.Name);
            colaborador = label.Text;

            arrastar = true;
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastar)
            {
                Label Colaborador = new Label();
                Colaborador.Text = colaborador;
                Colaborador.Location = e.Location;
                Colaborador.DoDragDrop(Colaborador.Text, DragDropEffects.Copy);
                arrastar = false;
            }
        }
    }
}

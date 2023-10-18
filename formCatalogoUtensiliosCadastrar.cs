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
    public partial class formCatalogoUtensiliosCadastrar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        formCatalogoUtensilios pai = new formCatalogoUtensilios();
        public formCatalogoUtensiliosCadastrar()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formCatalogoUtensiliosCadastrar(formCatalogoUtensilios Pai)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
            pai = Pai;
        }
        private void formUtensiliosCadastrar_Load(object sender, EventArgs e)
        {            
            List<string> Categorias = comandos.TrazerCategorias();
            foreach (string x in Categorias) { categoriaComboBox.Items.Add(x); }
            categoriaComboBox.Update();
            categoriaComboBox.SelectedIndex = -1;

            List<string> Materiais = comandos.TrazerMateriaPrima();
            foreach (string x in Materiais) { comboBoxMateriaPrima.Items.Add(x); }
            comboBoxMateriaPrima.Update();
            comboBoxMateriaPrima.SelectedIndex = -1;

            List<string> grupos = comandos.preencherComboGrupos();
            foreach (string x in grupos) { grupoComboBox.Items.Add(x); }
        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            string utensilio = utensilioTextBox.Text;
            string material = comboBoxMateriaPrima.Text;
            string categoria = categoriaComboBox.Text;

            if (utensilio == string.Empty)
            {
                MessageBox.Show("Preencha o utensílio para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (comandos.VerificarSeUtensilioJaExiste(utensilio))
            {
                MessageBox.Show("Já existe um utensílio cadastrado com esse nome!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (material == string.Empty)
            {
                MessageBox.Show("Preencha a matéria-prima para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (categoria == string.Empty)
            {
                MessageBox.Show("Preencha a categoria para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (grupoComboBox.Text == string.Empty)
            {
                MessageBox.Show("Selecione o grupo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ncm = ncmTextBox.Text;
                string cest = cestTextBox.Text;
                string[] partir = grupoComboBox.Text.Split(' ');
                int grupo = Convert.ToInt32(partir[0]);

                Utensilio Utensilio = new Utensilio()
                {
                    Nome_Utensilio = utensilio,
                    Material_Padrao = material,
                    Categoria = categoria,
                    NCM = ncm,
                    CEST = cest,
                    Grupo = grupo
                };

                comandos.CadastrarUtensilio(Utensilio);
                pai.alteracao = true;
                Dispose();
            }
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }
        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            clique = true;
            clickedAt = e.Location;
        }
        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            clique = false;
        }
        #endregion
    }
}

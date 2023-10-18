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
    public partial class formTelaInicialProcedimentosFerramentas : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        List<string> Equipamentos = new List<string>();

        formAtividadesCadastrar form_cadastrar = new formAtividadesCadastrar();
        formAtividadesEditar form_editar = new formAtividadesEditar();

        bool cadastramento;
        string atividade;

        public formTelaInicialProcedimentosFerramentas()
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);
        }
        public formTelaInicialProcedimentosFerramentas(formAtividadesCadastrar Form_cadastrar)
        {
            InitializeComponent();
            form_cadastrar = Form_cadastrar;
            new Sombra().ApplyShadows(this);
            cadastramento = true;
        }

        public formTelaInicialProcedimentosFerramentas(formAtividadesEditar Form_Editar, string Atividade)
        {
            InitializeComponent();
            new Sombra().ApplyShadows(this);

            form_editar = Form_Editar;
            cadastramento = false;
            atividade = Atividade;
        }

        private void formTelaInicialProcedimentosFerramentas_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }
        private void AtualizarDataGrid()
        {
            dataGridFerramentas.Rows.Clear();
            Equipamentos = comandos.ListaDeEquipamentosParaAtividade();

            if (cadastramento)
            {

                foreach (string ferramenta in Equipamentos)
                {
                    dataGridFerramentas.Rows.Add(ferramenta);
                }
            }
            else
            {
                foreach (string ferramenta in Equipamentos)
                {
                    bool contem = form_editar.equipamentos.Contains(ferramenta);
                    dataGridFerramentas.Rows.Add(ferramenta, contem);
                }
            }


        }
        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {

                Dispose();
            
        }

        #region Movimentacao do Formulario
        bool clique;
        Point clickedAt;
        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (clique)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
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

        private void dataGridFerramentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    string ferramenta = dataGridFerramentas.Rows[e.RowIndex].Cells[0].Value.ToString();

                    if (Convert.ToBoolean(dataGridFerramentas.Rows[e.RowIndex].Cells[1].Value) == true)
                    {
                        dataGridFerramentas.Rows[e.RowIndex].Cells[1].Value = false;

                        if (cadastramento)
                        {
                            form_cadastrar.equipamentos.Remove(ferramenta);
                        }
                        else
                        {
                            comandos.ApagarEquipamentoDaAtividade(atividade, ferramenta);
                            form_editar.AtualizarEquipamentos();
                        }
                    }
                    else
                    {
                        dataGridFerramentas.Rows[e.RowIndex].Cells[1].Value = true;

                        if (cadastramento)
                        {
                            form_cadastrar.equipamentos.Add(ferramenta);
                        }
                        else
                        {
                            comandos.AdicionarEquipamentoDaAtividade(atividade, ferramenta);
                            form_editar.AtualizarEquipamentos();
                        }
                    }
                }
            }
            catch { }
        }

        private void avancarButton_Click(object sender, EventArgs e)
        {

                Dispose();
            
        }
    }
}

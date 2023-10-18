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
    public partial class formCatalogoUtensiliosGruposAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formCatalogoUtensiliosGruposAdicionar()
        {
            InitializeComponent();
        }

        private void formUtensiliosGruposAdicionar_Load(object sender, EventArgs e)
        {
            int grupo = comandos.TrazerProximoGrupo();
            grupoTextBox.Text = grupo.ToString();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            GrupoBooleano Grupo = new GrupoBooleano();

            if (utensilioCheckBox.Checked) { Grupo.Utensilio = true; }
            else { Grupo.Utensilio = false; }
            if (especificacaoCheckBox.Checked) { Grupo.Especificacao = true; }
            else { Grupo.Especificacao = false; }
            if (checkBoxMaterial.Checked) { Grupo.Material = true; }
            else { Grupo.Material = false; }
            if (alturaCheckBox.Checked) { Grupo.Altura = true; }
            else { Grupo.Altura = false; }
            if (larguraCheckBox.Checked) { Grupo.Largura = true; }
            else { Grupo.Largura = false; ; }
            if (comprimentoCheckBox.Checked) { Grupo.Comprimento = true; }
            else { Grupo.Comprimento = false; }
            if (diametroCheckBox.Checked) { Grupo.Diametro = true; }
            else { Grupo.Diametro = false; }
            if (capacidadeCheckBox.Checked) { Grupo.Capacidade = true; }
            else { Grupo.Capacidade = false; }
            if (corCheckBox.Checked) { Grupo.Cor = true; }
            else { Grupo.Cor = false; }
            if (estampaCheckBox.Checked) { Grupo.Estampa = true; }
            else { Grupo.Estampa = false; }

            if (comandos.VerificarSeGrupoJaExiste(Grupo))
            {
                MessageBox.Show("Já existe um grupo com essas características.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                comandos.CriarGrupo(Grupo);
            }
        }
    }
}

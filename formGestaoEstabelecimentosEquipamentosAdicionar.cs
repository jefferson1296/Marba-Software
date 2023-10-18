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
    public partial class formGestaoEstabelecimentosEquipamentosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public formGestaoEstabelecimentosEquipamentosAdicionar()
        {
            InitializeComponent();
        }

        private void formGestaoEstabelecimentosEquipamentosAdicionar_Load(object sender, EventArgs e)
        {
            List<string> lista_atividades = comandos.PreencherComboCategoriasDosEquipamentos();
            foreach (string x in lista_atividades) { comboBoxCategoria.Items.Add(x); }
            comboBoxCategoria.DropDownHeight = 120;
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string categoria = comboBoxCategoria.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe o nome do estabelecimento para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (categoria == string.Empty)
            {
                MessageBox.Show("Informe a categoria para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Equipamento Equipamento = new Equipamento { Descricao = descricao, Categoria = categoria };
                comandos.CadastrarEquipamento(Equipamento);
                Dispose();
            }
        }
    }
}

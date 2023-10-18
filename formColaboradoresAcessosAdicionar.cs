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
    public partial class formColaboradoresAcessosAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        Acesso Acesso = new Acesso();
        public formColaboradoresAcessosAdicionar()
        {
            InitializeComponent();
        }

        private void formColaboradoresAcessosAdicionar_Load(object sender, EventArgs e)
        {
            List<string> categorias = comandos.CategoriasDeAcessos();
            foreach (string x in categorias) { comboBoxCategoria.Items.Add(x); }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Acesso.Descricao = textBoxDescricao.Text;

            Acesso.Categoria = comboBoxCategoria.Text;

            comandos.AdicionarPermissaoDeAcesso(Acesso);
            Dispose();
        }
    }
}

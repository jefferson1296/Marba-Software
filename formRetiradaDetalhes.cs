using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MarbaSoftware
{
    public partial class formRetiradaDetalhes : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int id;
        public formRetiradaDetalhes()
        {
            InitializeComponent();
        }
        public formRetiradaDetalhes(int ID)
        {
            InitializeComponent();
            id = ID;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formRetiradaDetalhes_Load(object sender, EventArgs e)
        {
            SqlDataReader leitor = comandos.PreencherInformacoesDaRetirada(id);

            while (leitor.Read())
            {
                textBoxStatus.Text = leitor[0].ToString();
                textBoxRetirada.Text = leitor[1].ToString();
                textBoxVenda.Text = leitor[2].ToString();
                textBoxOperador.Text = leitor[3].ToString();
                textBoxCliente.Text = leitor[4].ToString();
                textBoxData.Text = Convert.ToDateTime(leitor[5].ToString()).ToShortDateString();
                textBoxHora.Text = Convert.ToDateTime(leitor[6].ToString()).ToShortTimeString();
            }
            leitor.Close();

            SqlDataReader leitor1 = comandos.PreencherDataGridDetalhesRetiradas(id);
            while (leitor1.Read())
            {
                string produto = leitor1[0].ToString();
                int quantidade = Convert.ToInt32(leitor1[1]);

                dataGridViewLista.Rows.Add(produto, quantidade);
            }
            leitor1.Close();
        }
    }
}

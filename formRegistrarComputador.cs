using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formRegistrarComputador : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string computador;
        string usuario;
        string id_computador;
        bool cadastramento;

        public formRegistrarComputador()
        {
            InitializeComponent();
        }
        public formRegistrarComputador(string Computador, string Usuario, string Id_computador, bool Cadastramento)
        {
            InitializeComponent();
            computador = Computador;
            usuario = Usuario;
            id_computador = Id_computador;
            cadastramento = Cadastramento;
        }
        private void formRegistrarComputador_Load(object sender, EventArgs e)
        {
            textBoxComputador.Text = computador;
            textBoxUsuario.Text = usuario;
            textBoxID.Text = id_computador;

            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoes();

            comboBoxReparticoes.ValueMember = "ID_Reparticao";
            comboBoxReparticoes.DisplayMember = "Descricao";
            comboBoxReparticoes.DataSource = Reparticoes;

            comboBoxReparticoes.DropDownHeight = 150;

            PrinterSettings.StringCollection impressoras = PrinterSettings.InstalledPrinters;

            foreach (string i in impressoras)
            {
                comboBoxA4.Items.Add(i);
                comboBoxTermica.Items.Add(i);
            }

            string[] portas = SerialPort.GetPortNames();
            foreach (string porta in portas) { comboBoxSerial.Items.Add(porta); }
        }

        private void avancarButton_Click(object sender, EventArgs e)
        {
            bool permitir = false;
            string a4 = comboBoxA4.Text;
            string termica = comboBoxTermica.Text;
            string serial = comboBoxSerial.Text;
            string reparticao = comboBoxReparticoes.Text;

            if (reparticao == string.Empty)
            {
                MessageBox.Show("Informe a repartição para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (a4 == string.Empty || termica == string.Empty)
            {
                if (DialogResult.Yes == MessageBox.Show("O sistema identificou que a impressora padrão não foi definida.\r\nDeseja continuar mesmo assim?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    permitir = true;
                }
            }
            else
            {
                permitir = true;
            }

            if (permitir)
            {
                CPU cpu = new CPU();
                cpu.Computador = computador;
                cpu.Usuario = usuario;
                cpu.ID = id_computador;
                cpu.Impressora_A4 = a4;
                cpu.Impressora_Termica = termica;
                cpu.Porta_Serial = serial;
                cpu.ID_Reparticao = (int)comboBoxReparticoes.SelectedValue;

                comandos.RegistrarComputador(cpu);
                Dispose();
            }
        }
    }
}

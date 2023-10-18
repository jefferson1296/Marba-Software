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
    public partial class formGestaoConfiguracoesDefinicoes : Form
    {
        formGestaoConfiguracoes pai = new formGestaoConfiguracoes();
        ComandosSQL comandos = new ComandosSQL();

        public formGestaoConfiguracoesDefinicoes()
        {
            InitializeComponent();
        }
        public formGestaoConfiguracoesDefinicoes(formGestaoConfiguracoes Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        private void formGestaoConfiguracoesDefinicoes_Load(object sender, EventArgs e)
        {            
            textBoxID.Text = pai.Computador.ID;
            textBoxComputador.Text = pai.Computador.Computador;
            textBoxUsuario.Text = pai.Computador.Usuario;

            List<Reparticao> Reparticoes = comandos.PreencherComboReparticoes();

            comboBoxReparticoes.ValueMember = "ID_Reparticao";
            comboBoxReparticoes.DisplayMember = "Descricao";
            comboBoxReparticoes.DataSource = Reparticoes;

            comboBoxReparticoes.DropDownHeight = 150;
            comboBoxReparticoes.SelectedValue = pai.Computador.ID_Reparticao;

            PrinterSettings.StringCollection impressoras = PrinterSettings.InstalledPrinters;

            foreach (string i in impressoras)
            {
                comboBoxA4.Items.Add(i);
                comboBoxTermica.Items.Add(i);
            }

            comboBoxA4.SelectedItem = pai.Computador.Impressora_A4;
            comboBoxA4.DropDownHeight = 150;
            comboBoxTermica.SelectedItem = pai.Computador.Impressora_Termica;
            comboBoxTermica.DropDownHeight = 150;

            string[] portas = SerialPort.GetPortNames();
            foreach (string porta in portas) { comboBoxSerial.Items.Add(porta); }

            if (!portas.Contains(pai.Computador.Porta_Serial))
            {
                comboBoxSerial.Items.Add(pai.Computador.Porta_Serial);
            }

            comboBoxSerial.SelectedItem = pai.Computador.Porta_Serial;
            comboBoxSerial.DropDownHeight = 150;
        }

        private void comboBoxA4_SelectedIndexChanged(object sender, EventArgs e)
        {
            pai.Computador.Impressora_A4 = comboBoxA4.Text;
            pai.Computador.Edicao = true;
        }

        private void comboBoxTermica_SelectedIndexChanged(object sender, EventArgs e)
        {
            pai.Computador.Impressora_Termica = comboBoxTermica.Text;
            pai.Computador.Edicao = true;
        }

        private void comboBoxSerial_Leave(object sender, EventArgs e)
        {
            pai.Computador.Porta_Serial = comboBoxSerial.Text;
            pai.Computador.Edicao = true;
        }

        private void comboBoxReparticoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            pai.Computador.ID_Reparticao = (int)comboBoxReparticoes.SelectedValue;
            pai.Computador.Edicao = true;
        }
    }
}

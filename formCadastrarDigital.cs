using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formCadastrarDigital : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        public List<Digital> lista_digitais = new List<Digital>();
        string valor;
        string teste;

        int etapa;
        public formCadastrarDigital()
        {
            InitializeComponent();
            serialPortArduino.PortName = comandos.ObterValorDoParametroDeTexto("Porta USB do Computador da Plataforma Digital");
            serialPortArduino.BaudRate = 115200;
        }

        private void formCadastrarDigital_Load(object sender, EventArgs e)
        {
            string[] portas = SerialPort.GetPortNames();
            foreach(string porta in portas) { comboBoxPortas.Items.Add(porta); }
            lista_digitais = comandos.PreencherListaDeDigitais();

            ConectarPortaSerial();
        }

        private void ConectarPortaSerial()
        {
            if (serialPortArduino.IsOpen)
            {

            }
            else
            {
                try
                {
                    serialPortArduino.Open();
                }
                catch
                {
                    MessageBox.Show("Não foi possível identificar o leitor de impressão digital automaticamente.\r\nVerifique se o componente está conectado ao computador.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void serialPortArduino_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            valor = serialPortArduino.ReadExisting();
            Invoke(new EventHandler(TratarDadosRecebidos));
            //
        }

        private void TratarDadosRecebidos(object sender, EventArgs e)
        {
            if (valor == "a\r\n")
            {
                
            }
            else if (valor == "b\r\n")
            {
                MessageBox.Show("Sensor de Impressão Digital não encontrado!\r\nTente novamente." + "(" + valor + ")", "Erro!");
            }
            else if (valor == "c\r\n")
            {
                MessageBox.Show("Comando para função inválida recebido na serial!\r\nTente novamente." + "(" + valor + ")", "Erro!");
            }
            else if (valor == "d\r\n")
            {
                MessageBox.Show("Posição de nova digital a ser armazenada é inválida!\r\nTente novamente." + "(" + valor + ")", "Erro!");
            }
            else if (valor == "e\r\n")
            {
                MessageBox.Show("Erro na captura da imagem. Comando abortado.\r\nReinicie." + "(" + valor + ")", "Erro!");
            }
            else if (valor == "f\r\n") 
            {
            }
            else if (valor == "g\r\n")
            {
                MessageBox.Show("Retire o dedo do sensor.", "Atenção!");
            }
            else if (valor == "h\r\n")
            {
                if (etapa == 1)
                {
                    MessageBox.Show("Encoste o dedo novamente...");
                    etapa++;
                }
            }
            else if (valor == "i\r\n")
            {
                MessageBox.Show("Erro na criação do modelo de impressão digital. Comando abortado.\r\nReinicie.", "Atenção!");
            }
            else if (valor == "j\r\n")
            {
                MessageBox.Show("Erro no armazenamento do modelo de impressão digital", "Atenção!");
            }
            else if (valor == "k\r\n") 
            {
                if (etapa > 1)
                {
                    MessageBox.Show("Digital cadastrada com sucesso!");
                    teste = textBoxN.Text;
                    textBoxN.Clear();
                    etapa = 0;
                }               
            }
            else
            {
                try
                {
                    int digital = Convert.ToInt32(valor);
                    string colaborador = lista_digitais.Where(x => x.Impressao_Digital == digital).Select(x => x.Colaborador).FirstOrDefault();

                    if (digital == Convert.ToInt32(teste))
                    {
                        MessageBox.Show("Última digital cadastrada:\r\n\r\nPosição: " + valor + "Colaborador: " + colaborador, "Digital confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Posição: " + valor + "Colaborador: " + colaborador, "Digital reconhecida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch { }
            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            serialPortArduino.WriteLine("1");
            MessageBox.Show("Envie a posição da digital para continuar.");
            etapa = 1;
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            string n = textBoxN.Text;
            if (n == string.Empty) { MessageBox.Show("Informe um Número para continuar!"); }
            else 
            { 
                serialPortArduino.WriteLine(n);
                MessageBox.Show("Coloque o dedo para cadastrar a digital na posição " + n + ".");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPortArduino.WriteLine("2");
        }

        private void comboBoxPortas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string porta = comboBoxPortas.Text;

            if (!serialPortArduino.IsOpen)
            {
                if (porta != string.Empty)
                {
                    serialPortArduino.PortName = porta;
                    ConectarPortaSerial();
                    if (serialPortArduino.IsOpen)
                    {
                        MessageBox.Show("Leitor de impressão digital conectado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBoxPortas.Enabled = false;
                    }
                }
            }
        }

        private void buttonVerificar_Click(object sender, EventArgs e)
        {
            if (serialPortArduino.IsOpen)
            {
                MessageBox.Show("O leitor de impressão digital está conectado!", "Conectado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("O leitor de impressão digital está desconectado!", "Desconectado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxPortas.Enabled = true;
            }
        }

        private void comboBoxPortas_DropDown(object sender, EventArgs e)
        {
            comboBoxPortas.Items.Clear();
            string[] portas = SerialPort.GetPortNames();
            foreach (string porta in portas) { comboBoxPortas.Items.Add(porta); }
            lista_digitais = comandos.PreencherListaDeDigitais();
        }

        private void comboBoxDispositivos_DropDown(object sender, EventArgs e)
        {
            comboBoxDispositivos.Items.Clear();
            ManagementObjectCollection mReturn;
            ManagementObjectSearcher mSearch;
            mSearch = new ManagementObjectSearcher("Select * from Win32_SerialPort");
            mReturn = mSearch.Get();

            foreach (ManagementObject mObj in mReturn) { comboBoxDispositivos.Items.Add(mObj["Name"].ToString()); }
        }

        private void comboBoxDispositivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDispositivos.SelectedIndex = -1;
        }
    }
}

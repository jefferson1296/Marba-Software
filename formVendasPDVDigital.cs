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
    public partial class formVendasPDVDigital : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        string digital;
        public List<Digital> lista_digitais = new List<Digital>();
        formVendasPDV pai = new formVendasPDV();
        bool fechar;
        public formVendasPDVDigital()
        {
            InitializeComponent();
        }
        public formVendasPDVDigital(formVendasPDV Pai)
        {
            InitializeComponent();
            serialPortArduino.PortName = "COM4";
            serialPortArduino.BaudRate = 115200;
            new Sombra().ApplyShadows(this);
            pai = Pai;
        }

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void serialPortArduino_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            digital = serialPortArduino.ReadExisting();
            Invoke(new EventHandler(TratarDadosRecebidos));
            serialPortArduino.WriteLine("2");
        }
        private void TratarDadosRecebidos(object sender, EventArgs e)
        {
            if (digital == "a\r\n" || digital == "b\r\n" || digital == "c\r\n" || digital == "d\r\n" || digital == "e\r\n" || digital == "i\r\n" || digital == "l\r\n")
            {
                MessageBox.Show("Digital não encontrada!\r\nTente novamente." + "(" + digital + ")", "Erro!");
            }
            else if (digital == "f\r\n") { }
            else
            {
                try
                {
                    int Digital = Convert.ToInt32(digital);
                    int id_colaborador = lista_digitais.Where(x => x.Impressao_Digital == Digital).Select(x => x.ID_Colaborador).FirstOrDefault();

                    string cargo = comandos.TrazerCargoPeloID(id_colaborador);
                    //MessageBox.Show(cargo);
                    if (cargo == "Gerente" || cargo == "Vendedor" || cargo == "Diretor Executivo" || cargo == "Diretor Administrativo" || cargo == "Chefe de Expedição")
                    {
                        pai.concessao = true;
                        fechar = true;
                    }
                    else
                    {
                        MessageBox.Show("Acesso negado.", "Restrito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch { MessageBox.Show("ERRO!"); }
            }
            timer1.Enabled = true;
                
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

        private void formVendasPDVDigital_Load(object sender, EventArgs e)
        {
            lista_digitais = comandos.PreencherListaDeDigitais();
            if (serialPortArduino.IsOpen)
            {
                serialPortArduino.WriteLine("2");
            }
            else
            {
                try
                {
                    serialPortArduino.Open();
                    serialPortArduino.WriteLine("2");
                }
                catch
                {
                    MessageBox.Show("Não foi possível identificar o leitor de Impressão Digital.\r\nVerifique se o componente está conectado ao computador.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fechar) { Dispose(); }
            timer1.Enabled = false;
        }
    }
}

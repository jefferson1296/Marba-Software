using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{
    public partial class formTeste : Form
    {
        public formTeste()
        {
            InitializeComponent();
            serialPort1.PortName = "COM1";
        }

        private void formTeste_Load(object sender, EventArgs e)
        {
            comboBoxPortas.Items.Clear();
            string[] portas = SerialPort.GetPortNames();
            foreach (string porta in portas) { comboBoxPortas.Items.Add(porta); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string comando = "N\r\n" +
            //"D9\r\n" +
            //"S3\r\n" +
            //"JF\r\n" +
            //"ZT\r\n" +
            //"Q480,24\r\n" +
            //"q832\r\n" +
            //"A50,110,0,3,1,1,N,\"Esta e a fonte 3\"\r\n" +
            //"P1\r\n";

            //File.Copy(@"C:\Users\Administrador.WIN-IASFJOKMTG5\Desktop\teste de zpl.prn", "ELGIN L42 Pro");

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ShellExecuteA(this.Handle.ToInt32(), "print", ofd.FileName, null, null, 0);
            }
        }

        [DllImport("shell32.dll", EntryPoint = "ShellExecute")]
        public static extern int ShellExecuteA(int hwnd, string lpOperation,
         string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        private void comboBoxPortas_DropDown(object sender, EventArgs e)
        {
            comboBoxPortas.Items.Clear();
            string[] portas = SerialPort.GetPortNames();
            foreach (string porta in portas) { comboBoxPortas.Items.Add(porta); }
        }

        private void comboBoxPortas_SelectedIndexChanged(object sender, EventArgs e)
        {
           // serialPort1.PortName = comboBoxPortas.Text;
        }

        private void ConectarPortaSerial()
        {
            if (!serialPort1.IsOpen)
            {
                //try
                //{
                    serialPort1.Open();
                //}
                //catch
                //{

                //}
            }
        }
    }
}

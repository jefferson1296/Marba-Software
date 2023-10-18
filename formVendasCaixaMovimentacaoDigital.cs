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
    public partial class formVendasCaixaMovimentacaoDigital : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        int ID_Operador;
        decimal valor;
        bool Operador;
        bool Intermediario;
        int ID_Intermediario;
        string digital;
        string movimentacao;
        int id;
        bool fechar;
        public List<Digital> lista_digitais = new List<Digital>();
        formVendasCaixaMovimentacao pai = new formVendasCaixaMovimentacao();

        public formVendasCaixaMovimentacaoDigital()
        {
            InitializeComponent();
        }
        public formVendasCaixaMovimentacaoDigital(string Movimentacao, decimal Valor, formVendasCaixaMovimentacao Pai)
        {
            InitializeComponent();
            movimentacao = Movimentacao;
            valor = Valor;
            pai = Pai;
            new Sombra().ApplyShadows(this);
            serialPortArduino.PortName = "COM4";
            serialPortArduino.BaudRate = 115200;
        }
        public formVendasCaixaMovimentacaoDigital(int ID, string Movimentacao, decimal Valor, formVendasCaixaMovimentacao Pai)
        {
            InitializeComponent();
            movimentacao = Movimentacao;
            valor = Valor;
            pai = Pai;
            id = ID;
            new Sombra().ApplyShadows(this);
            serialPortArduino.PortName = "COM4";
            serialPortArduino.BaudRate = 115200;
        }

        private void serialPortArduino_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            digital = serialPortArduino.ReadExisting();
            this.Invoke(new EventHandler(TratarDadosRecebidos));
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

                    if (!Operador)
                    {
                        ID_Operador = comandos.TrazerIdDoColaboradorPelaMatricula(Program.matricula);
                        string digital_identificada = comandos.TrazerColaboradorPeloID(id_colaborador);
                        string operador = comandos.TrazerColaboradorPeloID(ID_Operador);

                        if (ID_Operador != id_colaborador)
                        {
                            digital_identificada = comandos.TrazerColaboradorPeloID(id_colaborador);
                            operador = comandos.TrazerColaboradorPeloID(ID_Operador);
                            MessageBox.Show("A digital identificada é diferente do operador do caixa.\r\nDigital identificada: " + digital_identificada + "\r\nOperador de caixa: " + operador + "\r\nTente novamente!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Operador = true;
                            labelColaborador.Text = "INTERMEDIÁRIO";
                            labelColaborador.Left = (panelSuperior.Width - labelColaborador.Width) / 2;
                            MessageBox.Show("Digital identificada!\r\n" + "Operador de caixa:" + digital_identificada + "\r\nInforme o colaborador intermediário.", "Operador de Caixa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (Operador && !Intermediario)
                    {
                        Intermediario = true;
                        ID_Intermediario = id_colaborador;
                        string digital_identificada = comandos.TrazerColaboradorPeloID(ID_Intermediario);

                        if (movimentacao == "Sangria" || movimentacao == "Sobrando")
                        {
                            comandos.SalvarMovimentacaoDoCaixaComDigital(movimentacao, valor, ID_Intermediario);
                            MessageBox.Show("Digital identificada!\r\n" + "Intermediário:" + digital_identificada + "\r\nMovimentação concluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pai.alteracao = true;
                            fechar = true;
                        }
                        else if (movimentacao == "Suprimento")
                        {
                            if (comandos.VerificarSeHaSuprimentoEmAberto())
                            {
                                comandos.SalvarSuprimentoComDigital(id, ID_Intermediario);
                                MessageBox.Show("Digital identificada: " + digital_identificada + "\r\nSuprimento de caixa registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                pai.alteracao = true;
                            }
                            else
                            {
                                MessageBox.Show("Não há nenhum suprimento registrado.\r\n É necessário registrar o suprimento na esfera administrativa antes de registrar no caixa.\r\nEm caso de dúvidas, informe à gestão.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            fechar = true;
                        }
                    }
                }
                catch { }
            }
        }

        private void formVendasMovimentacaoDigital_Load(object sender, EventArgs e)
        {
            labelMovimentacao.Text = movimentacao.ToUpper();
            labelMovimentacao.Left = (panelSuperior.Width - labelMovimentacao.Width) / 2;
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

        private void pictureBoxFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fechar) { Dispose(); }
        }
    }
}

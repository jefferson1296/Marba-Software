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
    public partial class formFinanceiro : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        bool previsoes = false;
        bool lancamentos = false;
        bool fluxo = false;
        bool fin = false;

        bool aviso = false;

        public formFinanceiro()
        {
            InitializeComponent();
        }

        private void buttonPrevisoes2_Click(object sender, EventArgs e)
        {
            if (!previsoes)
            {
                lancamentos = false;
                fluxo = false;
                fin = false;
                previsoes = true;
                DestacarBotao();
            }
        }

        private void buttonFin2_Click(object sender, EventArgs e)
        {
            if (!fin)
            {
                lancamentos = false;
                fluxo = false;
                fin = true;
                previsoes = false;
                DestacarBotao();
            }
        }


        private void DestacarBotao()
        {
            if (previsoes == true)
            {
                formFinanceiroPrevisoes prev = new formFinanceiroPrevisoes() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(prev);
                prev.Show();

                buttonOrcamentos.BackColor = Color.Red;
                buttonOrcamentos.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                buttonOrcamentos.BackColor = Color.White;
                buttonOrcamentos.ForeColor = Color.DarkRed;
            }

            if (lancamentos == true)
            {
                formFinanceiroLancamentos lancamentos = new formFinanceiroLancamentos() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(lancamentos);
                lancamentos.Show();

                buttonLancamentos.BackColor = Color.Red;
                buttonLancamentos.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                buttonLancamentos.BackColor = Color.White;
                buttonLancamentos.ForeColor = Color.DarkRed;
            }

            if (fluxo == true)
            {
                formFinanceiroFluxo fluxo = new formFinanceiroFluxo() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(fluxo);
                fluxo.Show();

                buttonFluxo.BackColor = Color.Red;
                buttonFluxo.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                buttonFluxo.BackColor = Color.White;
                buttonFluxo.ForeColor = Color.DarkRed;
            }

            if (fin == true)
            {
                formFinanceiroDashboard geral = new formFinanceiroDashboard { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                panelCentral.Controls.Clear();
                panelCentral.Controls.Add(geral);
                geral.Show();

                buttonDashboard.BackColor = Color.Red;
                buttonDashboard.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                buttonDashboard.BackColor = Color.White;
                buttonDashboard.ForeColor = Color.DarkRed;
            }

            if (!aviso)
            {
                aviso = true;

                if (comandos.VerificarSeHaBoletosAtrasados())
                {
                    timerAviso.Enabled = true;
                }
            }
        }

        private void formFinanceiro_Load(object sender, EventArgs e)
        {
            lancamentos = true;
            DestacarBotao();
        }

        private void timerAviso_Tick(object sender, EventArgs e)
        {
            timerAviso.Stop();
            //formFinanceiroPrevisoesAtrasados atrasados = new formFinanceiroPrevisoesAtrasados();
            //atrasados.ShowDialog();
        }

        private void buttonLancamentos_Click(object sender, EventArgs e)
        {
            if (!lancamentos)
            {
                lancamentos = true;
                fluxo = false;
                fin = false;
                previsoes = false;
                DestacarBotao();
            }
        }

        private void buttonFluxo_Click(object sender, EventArgs e)
        {
            if (!fluxo)
            {
                lancamentos = false;
                fluxo = true;
                fin = false;
                previsoes = false;
                DestacarBotao();
            }
        }
    }
}

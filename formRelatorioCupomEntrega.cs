﻿using System;
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
    public partial class formRelatorioCupomEntrega : Form
    {
        public formRelatorioCupomEntrega()
        {
            InitializeComponent();
        }

        private void formRelatorioCupomEntrega_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bd_MarbaDataSetEntregas.PreencherCupomEntregas'. Você pode movê-la ou removê-la conforme necessário.

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}

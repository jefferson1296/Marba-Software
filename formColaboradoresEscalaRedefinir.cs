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
    public partial class formColaboradoresEscalaRedefinir : Form
    {
        formColaboradoresEscala pai = new formColaboradoresEscala();
        public formColaboradoresEscalaRedefinir(formColaboradoresEscala Pai)
        {
            InitializeComponent();
            pai = Pai;
        }

        private void buttonRedefinir_Click(object sender, EventArgs e)
        {
            DateTime data = dateTimePicker1.Value.Date;

            pai.Datas = pai.Datas.Where(x => x >= data).ToList();
            pai.definir_horarios = true;
            Dispose();
        }
    }
}

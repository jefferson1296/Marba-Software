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


    public partial class formFinanceiroLancamentosContasAdicionar : Form
    {
        ComandosSQL comandos = new ComandosSQL();

        Conta conta = new Conta();

        bool cadastramento;

        public formFinanceiroLancamentosContasAdicionar()
        {
            InitializeComponent();
            cadastramento = true;
        }

        public formFinanceiroLancamentosContasAdicionar(int ID_Conta)
        {
            InitializeComponent();
            cadastramento = false;
            conta.ID_Conta = ID_Conta;
        }

        private void formFinanceiroFluxoContasAdicionar_Load(object sender, EventArgs e)
        {
            radioButtonInterna.Checked = true;
            ExibirPainelDoBanco();

            List<string> categorias = comandos.PreencherComboCategoriasDasContas();
            foreach (string x in categorias) { comboBoxCategoria.Items.Add(x); }

            comboBoxCategoria.DropDownHeight = 120;
            comboBoxEstabelecimentos.DropDownHeight = 120;
            comboBoxBanco.DropDownHeight = 120;
            comboBoxCodBanco.DropDownHeight = 120;

            AtualizarEstabelecimentos();
            AtualizarBancos();

            if (!cadastramento)
            {
                conta = comandos.TrazerInformacoesDaConta(conta.ID_Conta);
                radioButtonExterna.Checked = conta.Externa;
                textBoxDescricao.Text = conta.Descricao;
                comboBoxCategoria.SelectedItem = conta.Categoria;
                textBoxAgencia.Text = conta.Agencia;
                textBoxConta.Text = conta.N_Conta;
                try { comboBoxEstabelecimentos.SelectedValue = conta.ID_Estabelecimento; } catch { }
                try { comboBoxBanco.SelectedValue = conta.ID_Banco; } catch { }
                try { comboBoxCodBanco.SelectedValue = conta.ID_Banco; } catch { }

            }            
        }

        private void AtualizarEstabelecimentos()
        {
            comboBoxEstabelecimentos.DataSource = null;

            List<Estabelecimento> estabelecimentos = comandos.TrazerEstabelecimentosComerciais();
            comboBoxEstabelecimentos.DataSource = estabelecimentos;
            comboBoxEstabelecimentos.ValueMember = "ID_Estabelecimento";
            comboBoxEstabelecimentos.DisplayMember = "Descricao";

            comboBoxEstabelecimentos.SelectedIndex = -1;
        }

        private void AtualizarBancos()
        {
            comboBoxBanco.DataSource = null;
            comboBoxCodBanco.DataSource = null;

            List<Banco> bancos = comandos.ListaDeBancos();

            comboBoxBanco.DataSource = bancos;
            comboBoxBanco.ValueMember = "ID_Banco";
            comboBoxBanco.DisplayMember = "Descricao";

            comboBoxCodBanco.DataSource = bancos;
            comboBoxCodBanco.ValueMember = "ID_Banco";
            comboBoxCodBanco.DisplayMember = "Cod_Banco";

            comboBoxBanco.SelectedIndex = -1;
            comboBoxCodBanco.SelectedIndex = -1;
        }

        bool alternar_banco;
        bool alternar_cod_banco;

        private void comboBoxBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {          
                if (alternar_cod_banco)
                {
                    comboBoxCodBanco.SelectedValue = comboBoxBanco.SelectedValue;
                    alternar_cod_banco = false;
                }
            }
            catch { }
        }

        private void comboBoxCodBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (alternar_banco)
                {
                    comboBoxBanco.SelectedValue = comboBoxCodBanco.SelectedValue;
                    alternar_banco = false;
                }
            }
            catch { }
        }

        private void comboBoxBanco_DropDown(object sender, EventArgs e)
        {
            alternar_banco = true;
        }

        private void comboBoxCodBanco_DropDown(object sender, EventArgs e)
        {
            alternar_cod_banco = true;
        }

        private void comboBoxCodBanco_Leave(object sender, EventArgs e)
        {
            if (comboBoxCodBanco.Text == string.Empty)
            {
                comboBoxBanco.SelectedIndex = -1;
            }
        }

        private void comboBoxBanco_Leave(object sender, EventArgs e)
        {
            if (comboBoxBanco.Text == string.Empty)
            {
                comboBoxCodBanco.SelectedIndex = -1;
            }
        }

        private void radioButtonExterna_CheckedChanged(object sender, EventArgs e)
        {
            conta.Externa = radioButtonExterna.Checked;
        }

        private void ExibirPainelDoBanco()
        {
            if (comboBoxCategoria.Text == "Banco")
            {
                Height = 353;
            }
            else
            {
                Height = 262;

                comboBoxBanco.SelectedIndex = -1;
                comboBoxCodBanco.SelectedIndex = -1;
                textBoxAgencia.Clear();
                textBoxConta.Clear();
            }

        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            string descricao = textBoxDescricao.Text;
            string categoria = comboBoxCategoria.Text;

            if (descricao == string.Empty)
            {
                MessageBox.Show("Informe a descrição para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (categoria == string.Empty)
            {
                MessageBox.Show("Informe a categoria para continuar.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                conta.Descricao = descricao;
                conta.Categoria = categoria;
                conta.Agencia = textBoxAgencia.Text;
                conta.N_Conta = textBoxConta.Text;

                try { conta.ID_Estabelecimento = (int)comboBoxEstabelecimentos.SelectedValue; }
                catch { conta.ID_Estabelecimento = 0; }

                try { conta.ID_Banco = (int)comboBoxBanco.SelectedValue; }
                catch { conta.ID_Banco = 0; }

                if (cadastramento)
                {
                    comandos.AdicionarConta(conta);
                }
                else
                {
                    comandos.EditarConta(conta);
                }

                Dispose();
            }
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExibirPainelDoBanco();
        }

        private void comboBoxCategoria_Leave(object sender, EventArgs e)
        {
            ExibirPainelDoBanco();
        }
    }
}

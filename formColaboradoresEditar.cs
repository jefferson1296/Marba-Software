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
    public partial class formColaboradoresEditar : Form
    {
        ComandosSQL comandos = new ComandosSQL();
        ValidadorClientes validacao = new ValidadorClientes();
        List<Horario> Horarios = new List<Horario>();
        formColaboradores pai = new formColaboradores();
        int id_colaborador;
        bool cadastramento;
        public formColaboradoresEditar()
        {
            InitializeComponent();
        }
        public formColaboradoresEditar(formColaboradores Pai)
        {
            InitializeComponent();
            pai = Pai;
            cadastramento = true;
        }
        public formColaboradoresEditar(formColaboradores Pai, int ID_Colaborador)
        {
            InitializeComponent();
            pai = Pai;
            id_colaborador = ID_Colaborador;
            cadastramento = false;
        }

        private void formColaboradoresEditar_Load(object sender, EventArgs e)
        {
            List<string> lista_setores = comandos.preencherComboSetores();
            foreach (string x in lista_setores) { comboBoxSetor.Items.Add(x); }

            List<string> estados = comandos.PreencherComboBoxEstado();
            foreach (string x in estados) { comboBoxEstado.Items.Add(x); }

            comboBoxEstado.SelectedItem = "PE";

            comboBoxFilhos.SelectedIndex = 0;

            if (!cadastramento)
            {
                Colaborador colaborador = comandos.TrazerInformacoesDoColaborador(id_colaborador);

                //Informações principais
                textBoxNome.Text = colaborador.Nome_Colaborador;
                textBoxSobrenome.Text = colaborador.Sobrenome;
                maskedTextBoxCPF.Text = colaborador.CPF;
                textBoxRG.Text = colaborador.RG;
                comboBoxEstadoCivil.SelectedItem = colaborador.Estado_Civil;
                dateTimePickerAniversario.Value = colaborador.Aniversario;
                textBoxEmail.Text = colaborador.Email;
                maskedTextBoxTelefone.Text = colaborador.Telefone;
                maskedTextBoxCelular.Text = colaborador.Celular;
                comboBoxFilhos.SelectedItem = colaborador.Filhos.ToString();
                comboBoxFormacao.SelectedItem = colaborador.Formacao;
                textBoxEndereco.Text = colaborador.Endereco;
                textBoxNumero.Text = colaborador.Numero;
                maskedTextBoxCEP.Text = colaborador.CEP;
                textBoxBairro.Text = colaborador.Bairro;
                textBoxCidade.Text = colaborador.Cidade;
                comboBoxEstado.Text = colaborador.Estado;

                //Informações complementares

                if (colaborador.Possui_CNH)
                {
                    textBoxCNH.Text = colaborador.CNH;
                    comboBoxCategoria.Text = colaborador.Categoria_CNH;
                    dateTimePickerValidade.Value = colaborador.Validade_CNH;
                }
                else
                {
                    textBoxCNH.Enabled = false;
                    comboBoxCategoria.Enabled = false;
                    dateTimePickerValidade.Enabled = false;
                }
                textBoxTitulo.Text = colaborador.Titulo_Eleitor;
                textBoxSessao.Text = colaborador.Sessao_Titulo;
                textBoxZona.Text = colaborador.Zona_Titulo;

                //Informações profissionais
                textBoxMatricula.Text = colaborador.Matricula;
                comboBoxSetor.SelectedItem = colaborador.Setor;
                List<string> lista_cargos = comandos.preencherComboCargosPorSetor(colaborador.Setor);
                foreach (string x in lista_cargos) { comboBoxCargo.Items.Add(x); }
                comboBoxCargo.SelectedItem = colaborador.Cargo;
                dateTimePickerAdmissao.Value = colaborador.Data_Admissao;
                comboBoxFerias.SelectedItem = colaborador.Mes_Ferias;
                textBoxComportamento.Text = colaborador.Comportamento.ToString("F");
                textBoxHoras.Text = colaborador.Banco_Horas.ToString("F");

                //Informações financeiras
                textBoxBanco.Text = colaborador.Codigo_Banco;
                textBoxAgencia.Text = colaborador.Agencia_Banco;
                textBoxConta.Text = colaborador.Conta_Banco;
                textBoxPix.Text = colaborador.Chave_Pix;
                textBoxChave.Text = colaborador.Tipo_ChavePix;
                textBoxSalario.Text = colaborador.Salario.ToString("C");
                if (textBoxSalario.Text == "R$0,00") { textBoxSalario.ForeColor = Color.Gray; }
                textBoxCTPS.Text = colaborador.CTPS;
                textBoxSerie.Text = colaborador.Serie_CTPS;
                textBoxPIS.Text = colaborador.PIS;

                //Informações do sistema
                textBoxLogin.Text = colaborador.Login;
                textBoxSenha.Text = colaborador.Senha;
                textBox1.Text = colaborador.Digital1;
                textBox2.Text = colaborador.Digital2;
                textBox3.Text = colaborador.Digital3;
            }
            else
            {
                comboBoxTurno.Enabled = true;
                List<Turno> turnos = comandos.TrazerTurnos();
                comboBoxTurno.DataSource = turnos;
                comboBoxTurno.DisplayMember = "Descricao";
                comboBoxTurno.ValueMember = "ID_Turno";
                comboBoxTurno.SelectedIndex = -1;

                if (!checkBoxPossui.Checked)
                {
                    textBoxCNH.Enabled = false;
                    comboBoxCategoria.Enabled = false;
                    dateTimePickerValidade.Enabled = false;
                }
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (textBoxNome.Text == string.Empty)
            {
                MessageBox.Show("Informe o nome do colaborador para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBoxMatricula.Text == string.Empty)
            {
                MessageBox.Show("Informe a mátricula para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBoxFerias.Text == string.Empty)
            {
                MessageBox.Show("Informe o mês padrão de férias para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBoxMatricula.Text == string.Empty)
            {
                MessageBox.Show("Informe a mátricula para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (maskedTextBoxCPF.Text != string.Empty && !validacao.CPF(maskedTextBoxCPF.Text))
            {
                MessageBox.Show("CPF Inválido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBoxNome.Text == string.Empty || maskedTextBoxCPF.Text == string.Empty)
            {
                MessageBox.Show("É obrigatório informar nome e CPF\r\n para concluir o cadastro.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (comboBoxCargo.Text == string.Empty)
            {
                MessageBox.Show("Informe o cargo para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Colaborador colaborador = new Colaborador();

                //Informações principais
                colaborador.ID_Colaborador = id_colaborador;
                colaborador.Nome_Colaborador = textBoxNome.Text;
                colaborador.Sobrenome = textBoxSobrenome.Text;
                colaborador.CPF = maskedTextBoxCPF.Text;
                colaborador.RG = textBoxRG.Text;
                colaborador.Estado_Civil = comboBoxEstadoCivil.Text;
                colaborador.Aniversario = dateTimePickerAniversario.Value;
                colaborador.Email = textBoxEmail.Text;
                if (textBoxEmail.Text == "exemplo@exemplo.com")
                {
                    colaborador.Email = string.Empty;
                }
                else
                {
                    colaborador.Email = textBoxEmail.Text;
                }
                if (maskedTextBoxTelefone.Text == "(  )      -") { colaborador.Telefone = string.Empty; }
                else { colaborador.Telefone = maskedTextBoxTelefone.Text; }

                if (maskedTextBoxCelular.Text == "(  )      -") { colaborador.Celular = string.Empty; }
                else { colaborador.Celular = maskedTextBoxCelular.Text; }
               
                colaborador.Filhos = Convert.ToInt32(comboBoxFilhos.Text);
                colaborador.Formacao = comboBoxFormacao.Text;
                colaborador.Endereco = textBoxEndereco.Text;
                colaborador.Numero = textBoxNumero.Text;

                if (maskedTextBoxCEP.Text == "     -") { colaborador.CEP = string.Empty; }
                else { colaborador.CEP = maskedTextBoxCEP.Text; }

                colaborador.Bairro = textBoxBairro.Text;
                colaborador.Cidade = textBoxCidade.Text;
                colaborador.Estado = comboBoxEstado.Text;

                //Informações complementares
                colaborador.Possui_CNH = checkBoxPossui.Checked;

                if (colaborador.Possui_CNH)
                {
                    colaborador.CNH = textBoxCNH.Text;
                    colaborador.Categoria_CNH = comboBoxCategoria.Text;
                    colaborador.Validade_CNH = dateTimePickerValidade.Value;
                }

                colaborador.Titulo_Eleitor = textBoxTitulo.Text;
                colaborador.Sessao_Titulo = textBoxSessao.Text;
                colaborador.Zona_Titulo = textBoxZona.Text;

                //Informações profissionais
                colaborador.Matricula = textBoxMatricula.Text;
                colaborador.Setor = comboBoxSetor.Text;
                colaborador.Cargo = comboBoxCargo.Text;
                colaborador.Data_Admissao = dateTimePickerAdmissao.Value;
                colaborador.Mes_Ferias = comboBoxFerias.Text;
                colaborador.Comportamento = Convert.ToDecimal(textBoxComportamento.Text);
                colaborador.Banco_Horas = Convert.ToDecimal(textBoxHoras.Text);

                //Informações financeiras
                colaborador.Codigo_Banco = textBoxBanco.Text;
                colaborador.Agencia_Banco = textBoxAgencia.Text;
                colaborador.Conta_Banco = textBoxConta.Text;
                colaborador.Chave_Pix = textBoxPix.Text;
                colaborador.Tipo_ChavePix = textBoxChave.Text;
                colaborador.Salario = comandos.ConverterDinheiroEmDecimal(textBoxSalario.Text);
                colaborador.CTPS = textBoxCTPS.Text;
                colaborador.Serie_CTPS = textBoxSerie.Text;
                colaborador.PIS = textBoxPIS.Text;

                //Informações do sistema
                colaborador.Login = textBoxLogin.Text;
                colaborador.Senha = textBoxSenha.Text;
                colaborador.Digital1 = textBox1.Text;
                colaborador.Digital2 = textBox2.Text;
                colaborador.Digital3 = textBox3.Text;

                if (cadastramento)
                {
                    string turno = comboBoxTurno.Text;

                    if (turno == string.Empty)
                    {
                        MessageBox.Show("Informe o turno para continuar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        comandos.CadastrarColaborador(colaborador);
                        AdicionarHorariosEmBranco();
                        comandos.AtribuirHorariosDoUltimoColaboradorCadastrado(Horarios, (int)comboBoxTurno.SelectedValue);
                    }
                }
                else
                {
                    comandos.EditarColaborador(colaborador);
                }

                pai.alteracao = true;
                Dispose();
            }

        }

        private void comboBoxSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string setor = comboBoxSetor.Text;
            comboBoxCargo.Items.Clear();
            List<string> lista_setores = comandos.preencherComboCargosPorSetor(setor);
            foreach (string x in lista_setores) { comboBoxCargo.Items.Add(x); }
        }

        #region Formatação
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void textBoxSalario_Enter(object sender, EventArgs e)
        {
            textBoxSalario.ForeColor = Color.Black;
            if (textBoxSalario.Text == "R$0,00")
            {
                textBoxSalario.Text = string.Empty;
            }
            else
            {
                string[] partir = textBoxSalario.Text.Split('$');
                textBoxSalario.Text = partir[1];
            }
        }
        private void textBoxSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') &&
   (e.KeyChar != ',' && e.KeyChar != '.' &&
    e.KeyChar != (Char)13 && e.KeyChar != (Char)8))
            {
                e.KeyChar = (Char)0;
            }
            else
            {
                if (e.KeyChar == '.' || e.KeyChar == ',')
                {
                    if (!textBoxSalario.Text.Contains(','))
                    {
                        e.KeyChar = ',';
                    }
                    else
                    {
                        e.KeyChar = (Char)0;
                    }
                }
            }
        }
        private void textBoxSalario_Leave(object sender, EventArgs e)
        {
            if (textBoxSalario.Text == string.Empty)
            {
                textBoxSalario.Text = "R$0,00";
            }
            else
            {
                textBoxSalario.Text = Convert.ToDouble(textBoxSalario.Text).ToString("C");
            }

            if (textBoxSalario.Text == "R$0,00")
            {
                textBoxSalario.ForeColor = Color.Gray;
            }
        }
        #endregion

        private void checkBoxPossui_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPossui.Checked)
            {
                textBoxCNH.Enabled = true;
                comboBoxCategoria.Enabled = true;
                dateTimePickerValidade.Enabled = true;
            }
            else
            {
                textBoxCNH.Clear();
                textBoxCNH.Enabled = false;
                comboBoxCategoria.SelectedIndex = -1;
                comboBoxCategoria.Enabled = false;
                dateTimePickerValidade.Enabled = false;
            }
        }

        private void checkBoxMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMostrar.Checked)
            {
                textBoxSenha.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxSenha.UseSystemPasswordChar = true;
            }
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "exemplo@exemplo.com")
            {
                textBoxEmail.Text = string.Empty;
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == string.Empty)
            {
                textBoxEmail.Text = "exemplo@exemplo.com";
                textBoxEmail.ForeColor = Color.DarkGray;
            }
        }

        private void AdicionarHorariosEmBranco()
        {
            Turno segunda_servico = new Turno { Dia = "Segunda-feira", Descricao = "Serviço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(segunda_servico);
            Turno segunda_lanche = new Turno { Dia = "Segunda-feira", Descricao = "Lanche", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(segunda_lanche);
            Turno segunda_almoco = new Turno { Dia = "Segunda-feira", Descricao = "Almoço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(segunda_almoco);

            Turno terca_servico = new Turno { Dia = "Terça-feira", Descricao = "Serviço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(terca_servico);
            Turno terca_lanche = new Turno { Dia = "Terça-feira", Descricao = "Lanche", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(terca_lanche);
            Turno terca_almoco = new Turno { Dia = "Terça-feira", Descricao = "Almoço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(terca_almoco);

            Turno quarta_servico = new Turno { Dia = "Quarta-feira", Descricao = "Serviço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(quarta_servico);
            Turno quarta_lanche = new Turno { Dia = "Quarta-feira", Descricao = "Lanche", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(quarta_lanche);
            Turno quarta_almoco = new Turno { Dia = "Quarta-feira", Descricao = "Almoço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(quarta_almoco);

            Turno quinta_servico = new Turno { Dia = "Quinta-feira", Descricao = "Serviço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(quinta_servico);
            Turno quinta_lanche = new Turno { Dia = "Quinta-feira", Descricao = "Lanche", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(quinta_lanche);
            Turno quinta_almoco = new Turno { Dia = "Quinta-feira", Descricao = "Almoço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(quinta_almoco);

            Turno sexta_servico = new Turno { Dia = "Sexta-feira", Descricao = "Serviço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(sexta_servico);
            Turno sexta_lanche = new Turno { Dia = "Sexta-feira", Descricao = "Lanche", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(sexta_lanche);
            Turno sexta_almoco = new Turno { Dia = "Sexta-feira", Descricao = "Almoço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(sexta_almoco);

            Turno sabado_servico = new Turno { Dia = "Sábado", Descricao = "Serviço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(sabado_servico);
            Turno sabado_lanche = new Turno { Dia = "Sábado", Descricao = "Lanche", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(sabado_lanche);
            Turno sabado_almoco = new Turno { Dia = "Sábado", Descricao = "Almoço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(sabado_almoco);

            Turno domingo_servico = new Turno { Dia = "Domingo", Descricao = "Serviço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(domingo_servico);
            Turno domingo_lanche = new Turno { Dia = "Domingo", Descricao = "Lanche", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(domingo_lanche);
            Turno domingo_almoco = new Turno { Dia = "Domingo", Descricao = "Almoço", Inicio = string.Empty, Termino = string.Empty };
            Horarios.Add(domingo_almoco);
        }
    }
}

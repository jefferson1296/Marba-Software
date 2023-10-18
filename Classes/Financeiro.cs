using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbaSoftware
{

    public class Banco
    {
        public int ID_Banco { get; set; }
        public string Descricao { get; set; }
        public string Cod_Banco { get; set; }
    }

    public class Conta
    {
        public int ID_Conta { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Saldo { get; set; }
        public string Agencia { get; set; }
        public string N_Conta { get; set; }
        public string Estabelecimento { get; set; }
        public int ID_Estabelecimento { get; set; }
        public int ID_Banco { get; set; }
        public bool Externa { get; set; }
    }

    public class Venda
    {
        public int ID_Venda { get; set; }
        public string Tipo { get; set; }
        public string Cliente { get; set; }
        public string CPF_Cliente { get; set; }
        public string Operador { get; set; }
        public List<ProdutoVenda> Produtos { get; set; }
        public List<Pagamento> Pagamentos { get; set; }
        public List<Combo> Combos { get; set; }
        public DateTime Data { get; set; }
        public decimal Juros { get; set; }
        public decimal Desconto { get; set; }
        public string Tabela { get; set; }
    }   

    public class Venda_Por_Hora
    {
        public decimal Valor { get; set; }
        public string Hora { get; set; }
    }

    public class Venda_Por_Forma
    {
        public decimal Valor { get; set; }
        public string Forma_Pagamento { get; set; }
    }

    public class Previsao
    {
        public int ID_Previsao { get; set; }
        public string Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string Responsavel { get; set; }
        public int ID_CatFin { get; set; }
        public string Categoria_Financeira { get; set; }
        public string Categoria_Contabil { get; set; }
    }

    public class Movimentacao
    {
        public int ID_Movimentacao { get; set; }
        public DateTime Data { get; set; }
        public DateTime Data_Prevista { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal Valor_Previsto { get; set; }
        public string Status { get; set; }
        public string Matricula { get; set; }
        public int ID_CatFin { get; set; }
        public string Categoria_Financeira { get; set; }
        public string Saldo { get; set; }
        public string Conta { get; set; }
        public int ID_Conta { get; set; }
        public bool Orcamento { get; set; }
        public bool Previsto { get; set; }
    }

    public class Categoria_Financeira
    {
        public int ID { get; set; }
        public string Categoria { get; set; }
        public int ID_Parente { get; set; }
        public int ID_CatCon { get; set; }
        public string Tipo { get; set; }
    }

    public class FluxoDeCaixa
    {
        public int ID { get; set; }
        public int ID_Parente { get; set; }
        public string Categoria { get; set; }
        public decimal Valor1 { get; set; }
        public decimal Esperado1 { get; set; }
        public decimal AV1 { get; set; }
        public decimal AH2 { get; set; }
        public decimal Valor2 { get; set; }
        public decimal Esperado2 { get; set; }
        public decimal AV2 { get; set; }
        public decimal AH3 { get; set; }
        public decimal Valor3 { get; set; }
        public decimal Esperado3 { get; set; }
        public decimal AV3 { get; set; }
        public decimal AH4 { get; set; }
        public decimal Valor4 { get; set; }
        public decimal Esperado4 { get; set; }
        public decimal AV4 { get; set; }
    }

    public class Categoria_Contabil
    {
        public int ID_CatCon { get; set; }
        public string Categoria { get; set; }
    }

    public class Licitacao
    {
        public string Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Motivo { get; set; }
        public string Status { get; set; }
        public string Data_Aprovacao { get; set; }
        public string Responsavel { get; set; }
    }

    public class Despesa
    {
        public int ID_Despesa { get; set; }
        public int ID_Estabelecimento { get; set; }
        public string Estabelecimento { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string Categoria_Financeira { get; set; }
        public int ID_CatFin { get; set; }
        public int Dia { get; set; }
        public string Data { get; set; }
        public string Responsavel { get; set; }
        public bool Dia_Util { get; set; }
        public bool Ultimo_Dia { get; set; }
        public bool Mesmo_Dia { get; set; }
        public bool Antes_do_Dia { get; set; }
        public bool Depois_do_Dia { get; set; }
    }

    public class Boleto
    {
        public int ID_Boleto { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Vencimento { get; set; }
        public string Data_Registro { get; set; }
        public string Responsavel { get; set; }
        public int ID_Pedido { get; set; }
        public string Status { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public string Fornecedor { get; set; }
        public string Identificador { get; set; }
        public string Parcela { get; set; }
    }

    public class Cartao
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Vencimento { get; set; }
        public string Data_Registro { get; set; }
        public string Responsavel { get; set; }
        public string Status { get; set; }
        public string Nome_Cartao { get; set; }
    }

    public class Recebivel
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Vencimento { get; set; }
        public string Data_Registro { get; set; }
        public string Responsavel { get; set; }
        public int ID_Pedido { get; set; }
        public string Status { get; set; }
        public string Tipo { get; set; }
    }

    public class Saldo
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }

    public class MovimentacaoCaixa
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Hora { get; set; }
        public string Operador { get; set; }
        public string Intermedio { get; set; }
        public string Recebedor { get; set; }
        public string Status { get; set; }
    }

    public class Entrega
    {
        public string Cliente { get; set; }
        public string Endereco { get; set; }
        public string Recebedor { get; set; }
        public string Numero { get; set; }
        public string Referencia { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public decimal Valor { get; set; }
    }

    public class Transferencia
    {
        public int ID_Origem { get; set; }
        public int ID_Destino { get; set; }
        public decimal Valor { get; set; }  
        public DateTime Data { get; set; }
    }

    public class Informacoes_Vendas
    {
        public decimal Receita_Vendas { get; set; }
        public decimal CMV { get; set; }
        public int Qtd_Vendas { get; set; }
        public int Produtos_Vendidos { get; set; }
        public decimal Descontos { get; set; }
        public decimal Ticket_Medio { get; set; }
        public decimal Produtos_Por_Venda { get; set; }
        public decimal Maior_Venda_Dia { get; set; }
        public decimal Preco_Por_Produto { get; set; }
        public decimal Lucro_Bruto { get; set; }
        public decimal Margem_Lucro { get; set; }
        public DateTime Data { get; set; }
        public string Dia_da_semana { get; set; }
        public bool Simulacao { get; set; }
    }

    public class Meta
    {
        public int ID_Meta { get; set; }
        public string Periodo { get; set; }
        public decimal Mes { get; set; }
        public decimal Domingo { get; set; }
        public decimal Segunda { get; set; }
        public decimal Terca { get; set; }
        public decimal Quarta { get; set; }
        public decimal Quinta { get; set; }
        public decimal Sexta { get; set; }
        public decimal Sabado { get; set; }
        public int ID_Estabelecimento { get; set; }
    }

    public class MetaDiaria
    {
        public int ID_Meta { get; set; }
        public DateTime Dia { get; set; }
        public string Dia_da_semana { get; set; }
        public decimal Meta { get; set; }
        public decimal Vendido { get; set; }
        public decimal Simulador { get; set; }
        public decimal Equilibrio { get; set; }
        public string Status { get; set; }
    }

    public class Simulador
    {
        public DateTime Dia { get; set; }
        public string Dia_da_semana { get; set; }
        public decimal Despesas { get; set; }
        public decimal Receitas { get; set; }
        public decimal Saldo_Dia { get; set; }
        public decimal Saldo_Total { get; set; }
        public string Tipo { get; set; }
    }

    public class SuggestComboBox : ComboBox
    {
        #region fields and properties

        private readonly ListBox _suggLb = new ListBox { Visible = false, TabStop = false };
        private readonly BindingList<string> _suggBindingList = new BindingList<string>();
        private Expression<Func<ObjectCollection, IEnumerable<string>>> _propertySelector;
        private Func<ObjectCollection, IEnumerable<string>> _propertySelectorCompiled;
        private Expression<Func<string, string, bool>> _filterRule;
        private Func<string, bool> _filterRuleCompiled;
        private Expression<Func<string, string>> _suggestListOrderRule;
        private Func<string, string> _suggestListOrderRuleCompiled;

        public int SuggestBoxHeight
        {
            get { return _suggLb.Height; }
            set { if (value > 0) _suggLb.Height = value; }
        }
        /// <summary>
        /// If the item-type of the ComboBox is not string,
        /// you can set here which property should be used
        /// </summary>
        public Expression<Func<ObjectCollection, IEnumerable<string>>> PropertySelector
        {
            get { return _propertySelector; }
            set
            {
                if (value == null) return;
                _propertySelector = value;
                _propertySelectorCompiled = value.Compile();
            }
        }

        ///<summary>
        /// Lambda-Expression to determine the suggested items
        /// (as Expression here because simple lamda (func) is not serializable)
        /// <para>default: case-insensitive contains search</para>
        /// <para>1st string: list item</para>
        /// <para>2nd string: typed text</para>
        ///</summary>
        public Expression<Func<string, string, bool>> FilterRule
        {
            get { return _filterRule; }
            set
            {
                if (value == null) return;
                _filterRule = value;
                _filterRuleCompiled = item => value.Compile()(item, Text);
            }
        }

        ///<summary>
        /// Lambda-Expression to order the suggested items
        /// (as Expression here because simple lamda (func) is not serializable)
        /// <para>default: alphabetic ordering</para>
        ///</summary>
        public Expression<Func<string, string>> SuggestListOrderRule
        {
            get { return _suggestListOrderRule; }
            set
            {
                if (value == null) return;
                _suggestListOrderRule = value;
                _suggestListOrderRuleCompiled = value.Compile();
            }
        }

        #endregion

        /// <summary>
        /// ctor
        /// </summary>
        public SuggestComboBox()
        {
            // set the standard rules:
            _filterRuleCompiled = s => s.ToLower().Contains(Text.Trim().ToLower());
            _suggestListOrderRuleCompiled = s => s;
            _propertySelectorCompiled = collection => collection.Cast<string>();

            _suggLb.DataSource = _suggBindingList;
            _suggLb.Click += SuggLbOnClick;

            ParentChanged += OnParentChanged;
        }

        /// <summary>
        /// the magic happens here ;-)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (!Focused) return;

            _suggBindingList.Clear();
            _suggBindingList.RaiseListChangedEvents = false;
            _propertySelectorCompiled(Items)
                 .Where(_filterRuleCompiled)
                 .OrderBy(_suggestListOrderRuleCompiled)
                 .ToList()
                 .ForEach(_suggBindingList.Add);
            _suggBindingList.RaiseListChangedEvents = true;
            _suggBindingList.ResetBindings();

            _suggLb.Visible = _suggBindingList.Any();

            if (_suggBindingList.Count == 1 &&
                        _suggBindingList.Single().Length == Text.Trim().Length)
            {
                Text = _suggBindingList.Single();
                Select(0, Text.Length);
                _suggLb.Visible = false;
            }
        }

        /// <summary>
        /// suggest-ListBox is added to parent control
        /// (in ctor parent isn't already assigned)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnParentChanged(object sender, EventArgs e)
        {
            Parent.Controls.Add(_suggLb);
            Parent.Controls.SetChildIndex(_suggLb, 0);
            _suggLb.Top = Top + Height;
            _suggLb.Left = Left;
            _suggLb.Width = Width;
            _suggLb.Font = new Font("Segoe UI", 9);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            // _suggLb can only getting focused by clicking (because TabStop is off)
            // --> click-eventhandler 'SuggLbOnClick' is called
            if (!_suggLb.Focused)
                HideSuggBox();
            base.OnLostFocus(e);
        }
        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            _suggLb.Top = Top + Height;
            _suggLb.Left = Left;
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            _suggLb.Width = Width;
        }

        private void SuggLbOnClick(object sender, EventArgs eventArgs)
        {
            Text = _suggLb.Text;
            Focus();
        }

        private void HideSuggBox()
        {
            _suggLb.Visible = false;
        }

        protected override void OnDropDown(EventArgs e)
        {
            HideSuggBox();
            base.OnDropDown(e);
        }

        #region keystroke events

        /// <summary>
        /// if the suggest-ListBox is visible some keystrokes
        /// should behave in a custom way
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (!_suggLb.Visible)
            {
                base.OnPreviewKeyDown(e);
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (_suggLb.SelectedIndex < _suggBindingList.Count - 1)
                        _suggLb.SelectedIndex++;
                    return;
                case Keys.Up:
                    if (_suggLb.SelectedIndex > 0)
                        _suggLb.SelectedIndex--;
                    return;
                case Keys.Enter:
                    Text = _suggLb.Text;
                    Select(0, Text.Length);
                    _suggLb.Visible = false;
                    return;
                case Keys.Escape:
                    HideSuggBox();
                    return;
            }

            base.OnPreviewKeyDown(e);
        }

        private static readonly Keys[] KeysToHandle = new[]
                    { Keys.Down, Keys.Up, Keys.Enter, Keys.Escape };
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // the keysstrokes of our interest should not be processed be base class:
            if (_suggLb.Visible && KeysToHandle.Contains(keyData))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }

}

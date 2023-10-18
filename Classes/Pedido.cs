using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbaSoftware
{
    public class Pedido
    {
        public int ID_Pedido { get; set; }
        public string Fornecedor { get; set; }
        public int Qtd_Produtos { get; set; }
        public DateTime Solicitacao { get; set; }
        public DateTime Previsao_Entrega { get; set; }
        public string Status { get; set; }
    }

    public class PedidoProdutos
    {
        public int ID_ProdutoVariacao { get; set; }
        public int ID_ProdutoPedido { get; set; }
        public string Codigo { get; set; }
        public string Produto { get; set; }
        public int Ideal { get; set; }
        public int Atual { get; set; }
        public int Caixa { get; set; }
        public int Quantidade { get; set; }
        public int Pedido { get; set; }
        public decimal Base_Custo { get; set; }
        public decimal Aliquota_ICMS { get; set; }
        public decimal Aliquota_IPI { get; set; }
        public decimal ICMS { get; set; }
        public decimal IPI { get; set; }
        public decimal Preco { get; set; }
        public decimal Preco_Total { get; set; }
        public string Tipo { get; set; }
        public string Tipo_Conjunto { get; set; }
        public string Status { get; set; }
        public bool Confirmacao { get; set; }
    }
}

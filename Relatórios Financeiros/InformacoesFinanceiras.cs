using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbaSoftware.Relatórios_Financeiros
{
    public class InformacoesFinanceiras
    {
        decimal Ticket_Medio { get; set; }
        decimal Receita_Vendas { get; set; }
        decimal CMV { get; set; }
        decimal Lucro_Bruto { get; set; }
        decimal Pagamentos_Realizados { get; set; }
        decimal Produtos_Vendidos { get; set; }
        decimal Vendas_Realizadas { get; set; }
        decimal Despesas_Variaveis { get; set; }
        decimal Despesas_Fixas { get; set; }
    }
}

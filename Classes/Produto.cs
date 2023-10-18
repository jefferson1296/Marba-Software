using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbaSoftware
{
    public class Capsula
    {
        public int ID_Capsula { get; set; }
        public string Nome_Utensilio { get; set; }
        public string Nome_Sistema { get; set; }
        public int Altura_Min { get; set; }
        public int Altura_Max { get; set; }
        public string Altura_Un { get; set; }
        public int Largura_Min { get; set; }
        public int Largura_Max { get; set; }
        public string Largura_Un { get; set; }
        public int Comprimento_Min { get; set; }
        public int Comprimento_Max { get; set; }
        public string Comprimento_Un { get; set; }
        public int Diametro_Min { get; set; }
        public int Diametro_Max { get; set; }
        public string Diametro_Un { get; set; }
        public int Capacidade_Min { get; set; }
        public int Capacidade_Max { get; set; }
        public string Capacidade_Un { get; set; }
        public string Cor { get; set; }
        public string Estampa { get; set; }
        public string Especificacao { get; set; }
        public string Material { get; set; }
        public decimal Menor_Preco { get; set; }
        public decimal Maior_Preco { get; set; }
        public string Conjunto { get; set; }
        public decimal Ativo { get; set; }
        public decimal Saldo { get; set; }
        public decimal Valor_Estoque { get; set; }
        public string Status { get; set; }
        public bool Catalogo { get; set; }
        public string Observacao { get; set; }
        public int Ideal_Produtos { get; set; }
    }
    public class Catalogo : Produto_Variacao
    {
        public int ID_Catalogo { get; set; }
        public int ID_Capsula { get; set; }
        public string Nome { get; set; }
        public bool Instagram { get; set; }
        public bool Whatsapp { get; set; }
        public int Estoque_Ideal { get; set; }
        public decimal Preco_Venda { get; set; }
        public bool Promocao { get; set; }
        public decimal Preco_Promocional { get; set; }
        public string Nome_Preco { get; set; }
        public string Linha { get; set; }
    }
    public class Imagem_Produto : Catalogo
    {
        public int Index { get; set; }
        public int ID_Imagem { get; set; }
        public string Caminho { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
    }
    public class Conjunto
    {
        public string Nome_Conjunto { get; set; }
        public string Tipo_Conjunto { get; set; }
        public string Tipo_Venda { get; set; }
        public string Fabricante { get; set; }
        public int Qtd_Produtos { get; set; }
        public decimal Custo_Base { get; set; }
        public decimal Aliquota_ICMS { get; set; }
        public decimal Aliquota_IPI { get; set; }
        public string Cod_Extra { get; set; }
    }
    public class Produto : Conjunto
    {
        public int ID_Produto { get; set; }
        public string Nome_Produto { get; set; }
        public string Cod_Barras { get; set; }
        public string Utensilio { get; set; } //Na tabela está como ID
        public new string Fabricante { get; set; } //Na tabela está como ID
        public string MateriaPrima { get; set; } //Na tabela está como ID
        public int ID_Conjunto { get; set; }
        public string Altura { get; set; }
        public string Largura { get; set; }
        public string Comprimento { get; set; }
        public string Diametro { get; set; }
        public string Capacidade { get; set; }
        public DateTime Data_Cadastramento { get; set; }
        public string Especificacao { get; set; }
        public new string Cod_Extra { get; set; }
        public decimal Preco_Base { get; set; }
        public new decimal Aliquota_IPI { get; set; }
        public new decimal Aliquota_ICMS { get; set; }
        public int Caixa { get; set; }
        public string Tipo { get; set; }
        //public bool Acabamento { get; set; }
    }
    public class Produto_Variacao : Produto
    {
        public int ID_ProdutoVariacao { get; set; }
        public string Cor { get; set; } //Na tabela está como ID
        public string Estampa { get; set; }
        public bool Ativacao { get; set; }
        public bool Disponibilidade { get; set; }
        public bool Imprimir_Codigo { get; set; }
        public List<Fornecedor> Fornecedores { get; set; }
        public bool Catalogado { get; set; }
        public string Status { get; set; }
    }
    public class Produto_Lote : Catalogo
    {
        public int ID_ProdutoLote { get; set; }
        public int ID_Lote { get; set; }
        public string Fornecedor { get; set; }
        public int Quantidade { get; set; }
        public string Status { get; set; }
        public int ID_Localizacao { get; set; }
        public string Localizacao { get; set; }
        public string Acabamento { get; set; }
        public bool Acabamento_bool { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
    }
    public class Produto_Direcionamento : Produto_Lote
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public bool Confirmacao { get; set; }
    }

    public class Direcionamento
    {
        public int ID_Direcionamento { get; set; }
        public int ID_Colaborador { get; set; }
        public string Colaborador { get; set; }
        public DateTime Registro { get; set; }
        public bool Confirmacao { get; set; }
        public string Status { get; set; }
    }

    public class Produto_Quarentena : Produto_Lote
    {
        public string Etiqueta { get; set; }
        public new string Acabamento { get; set; }
        public string Condicionamento { get; set; }
        public bool Confirmacao { get; set; }
    }
    public class Status : Produto_Lote
    {
        public int ID_Status { get; set; }
        public string Data { get; set; }
        public string Colaborador { get; set; }
    }
    public class Fabricante
    {
        public int ID_Fabricante { get; set; }
        public string Nome_Fabricante { get; set; }
        public string CNPJ { get; set; }
        public DateTime Cadastramento { get; set; }
        public string Endereco { get; set; }
    }
    public class Peca : Produto
    {
        public int ID_Peca { get; set; }
        public string Nome_Peca { get; set; }
        public int Quantidade { get; set; }
    }
    public class PecaAvulsa : Peca
    {
        public int ID_PecaAvulsa { get; set; }
        public string Setor { get; set; }
        public string Observacao { get; set; }
    }
    public class Acabamento : Produto
    {
        public int ID_Acabamento { get; set; }
        public string Descricao { get; set; }
    }
    public class ProdutoAcabamento
    {
        public int ID_Produto { get; set; }
        public string Nome_Produto { get; set; }
        public int Estoque_Atual { get; set; }
        public string Acabamento { get; set; }
        public int Sem_Acabamento { get; set; }
        public string Tipo_Acabamento { get; set; }
        public int Percentual { get; set; }
        public int Quantidade { get; set; }
        public int Quantidade_Realizada { get; set; }
        public bool Confirmacao { get; set; }
    }
    public class ProdutoEntrada : Produto_Variacao
    {
        public int Quantidade { get; set; }
        public bool Conferido { get; set; }
    }
    public class ProdutoEtiqueta
    {
        public string Fornecedor { get; set; }
        public string Produto { get; set; }
        public string Codigo { get; set; }
        public int Quantidade { get; set; }
        public string Venda { get; set; }
        public string Venda_Promocional { get; set; }
        public bool Imprimir { get; set; }
        public bool Promocao { get; set; }
        public string Codigo128 { get; set; }
        public string Cod_Extra { get; set; }
        public decimal Desconto { get; set; }
    }
    public class Utensilio
    {
        public int ID_Utensilio { get; set; }
        public string Nome_Utensilio { get; set; }
        public string Preco_Custo { get; set; }
        public string Ativacao { get; set; }
        public string Disponibilidade { get; set; }
        public string Categoria { get; set; }
        public string Material_Padrao { get; set; }
        public int qtd_Produtos { get; set; }
        public int qtd_Ativos { get; set; }
        public int Grupo { get; set; }
        public string NCM { get; set; }
        public string CEST { get; set; }

    }
    public class ProdutoVenda
    {
        public int Index { get; set; }
        public string Codigo { get; set; }
        public int ID_Produto { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Custo { get; set; }
        public bool Promocao { get; set; }
        public decimal Preco { get; set; }
        public decimal Preco_Promocional { get; set; }
        public decimal Total { get; set; }
        public decimal Desconto { get; set; }
        public decimal Subtotal { get; set; }
        public string Tipo { get; set; }
        public string Hora { get; set; }
        public int ID_Combo { get; set; }
        public int ID_Categoria { get; set; }
    }

    public class Combo
    {
        public int ID_Combo { get; set; }
        public string Descricao { get; set; }
        public int Multiplicador { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
    }

    public class Fornecedor
    {
        public int ID_Fornecedor { get; set; }
        public string Nome_Fornecedor { get; set; }
        public int Reposicao { get; set; }
        public DateTime Data_Cadastramento { get; set; }
        public string Frete { get; set; }
        public string Forma_Pagamento { get; set; }
        public int Entrega { get; set; }

        public string Endereco { get; set; }
        public string Representante { get; set; }
        public string Fone_Representante { get; set; }
        public string Email { get; set; }
        public string Fone_Fabrica { get; set; }
        public decimal IPI { get; set; }
        public decimal ICMS { get; set; }

        public string Troca { get; set; }
        public decimal Pedido_Minimo { get; set; }

        public bool Disponibilidade { get; set; }
        public bool Ativacao { get; set; }
    }
    public class GrupoBooleano
    {
        public int Grupo { get; set; }
        public bool Utensilio { get; set; }
        public bool Capacidade { get; set; }
        public bool Altura { get; set; }
        public bool Largura { get; set; }
        public bool Comprimento { get; set; }
        public bool Especificacao { get; set; }
        public bool Cor { get; set; }
        public bool Material { get; set; }
        public bool Diametro { get; set; }
        public bool Estampa { get; set; }
    }
    public class Prateleira
    {
        public int ID_Prateleira { get; set; }
        public string Localizacao { get; set; }
        public string Altura { get; set; }
        public string Largura { get; set; }
        public string Comprimento { get; set; }
        public string Estabelecimento { get; set; }
        public int ID_Reparticao { get; set; }
        public string Reparticao { get; set; }
        public string Armazenamento { get; set; }
        public string Expositor { get; set; }
        public string Produto { get; set; }
        public List<Produto> Produtos { get; set; }
    }
    public class Avaria
    {
        public int ID_Avaria { get; set; }
        public int ID_Produto { get; set; }
        public int ID_Responsavel { get; set; }
        public int ID_Colaborador { get; set; }
        public int Quantidade { get; set; }
        public string Nome_Sistema { get; set; }
        public string Fornecedor { get; set; }
        public string Setor { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
    }
    public class Balanco
    {
        public string Codigo { get; set; }
        public int ID_Produto { get; set; }
        public string Nome_Sistema { get; set; }
        public int Quantidade_Atual { get; set; }
        public int Quantidade { get; set; }
    }
    public class Reposicao
    {
        public int ID_Reposicao { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public DateTime Registro { get; set; }
        public string Status { get; set; }
        public int ID_Responsavel { get; set; }
        public string Responsavel { get; set; }
        public int Intervalo { get; set; }
        public DateTime Primeira { get; set; }
        public DateTime Ultima { get; set; }
        public DateTime Proxima { get; set; }
    }
    public class ProdutoReposicao
    {
        public int ID_Produto { get; set; }
        public int ID_ProdutoVariacao { get; set; }
        public string Nome_Produto { get; set; }
        public string Cod_Barras { get; set; }
        public string Local_Origem { get; set; }
        public int Qtd_Ideal { get; set; }
        public int Qtd_Atual { get; set; }
        public int Qtd_Origem { get; set; }
        public int CMR { get; set; }
        public string Local_Destino { get; set; }
        public int Quantidade { get; set; }
        public int Confirmacao { get; set; }
        public string Motivo { get; set; }
    }
    public class Cliente
    {
        public int ID_Cliente { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Especial { get; set; }
        public string Nascimento { get; set; }
        public string CEP { get; set; }
    }
    public class HabitoDoCliente
    {
        public int ID_Cliente { get; set; }
        public int ID_Habito { get; set; }
        public string Habito { get; set; }
    }
    public class Almoxarifado
    {
        public int ID_Almoxarifado { get; set; }
        public string Item { get; set; }
        public string Categoria { get; set; }
        public int Estoque_Atual { get; set; }
        public int Estoque_Ideal { get; set; }
        public int Estoque_Minimo { get; set; }
        public decimal Custo { get; set; }
        public string Status { get; set; }
        public int Periodo_Reposicao { get; set; }
        public DateTime Proxima_Reposicao { get; set; }
        public bool Restricao { get; set; }
        public bool Comprar { get; set; }
    }
    public class ContadorDeMoeda
    {
        public string Valor { get; set; }
        public int Quantidade { get; set; }
    }
    public class Apetrecho
    {
        public int ID_Apetrecho { get; set; }
        public string Nome_Apetrecho { get; set; }
        public string Colaborador { get; set; }
        public string Equipamento { get; set; }
        public int ID_Colaborador { get; set; }
        public string Status { get; set; }
        public string Tipo { get; set; }
        public int Ordem { get; set; }
    }
    public class Ajuste
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public int Produtos { get; set; }
        public string Responsavel { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
    }
    public class Transferencias_Estoque : Ajuste
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
    }
    public class ProdutoLocalizacao : Catalogo
    {
        public int ID_ProdutoLocalizacao { get; set; }
        public int ID_Prateleira { get; set; }
        public string Estabelecimento { get; set; }
        public string Localizacao { get; set; }
        public string Setor { get; set; }
        public int Qtd_Ideal { get; set; }
        public int CMR { get; set; }
        public int ID_Reparticao { get; set; }
        public string Reparticao { get; set; }
        public string Estabelecimento_Origem { get; set; }
        public int ID_Reparticao_Origem { get; set; }
        public string Reparticao_Origem { get; set; }
        public int ID_Identificacao { get; set; }
        public string Identificacao { get; set; }
        public bool Identificado { get; set; }
    }
    public class Linha
    {
        public int ID_Linha { get; set; }
        public string Descricao { get; set; }
        public string Marketing { get; set; }
        public decimal Markup { get; set; }
        public decimal Lucro { get; set; }
        public bool Ativacao { get; set; }
    }
    public class Armazenamento
    {
        public int ID_Armazenamento { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
    }
    public class Expositor
    {
        public int ID_Expositor { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public byte[] Imagem { get; set; }
        public int ID_Imagem { get; set; }
    }

    public class Entrada
    {
        public int ID_Lote { get; set; }
        public DateTime Data { get; set; }
        public string Fornecedor { get; set; }
        public int ID_Pedido { get; set; }
        public bool Analise { get; set; }
    }

    public class Quarentena
    {
        public int ID_Quarentena { get; set; }
        public int ID_Lote { get; set; }
        public string Status { get; set; }
        public string Descricao { get; set; }
        public string Responsavel { get; set; }
        public string Fornecedor { get; set; }
        public bool Conclusao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
    }

    public class Categoria
    {
        public int ID_Categoria { get; set; }
        public string Descricao { get; set; }
        public decimal Cliente1 { get; set; }
        public decimal Cliente2 { get; set; }
        public decimal Cliente3 { get; set; }
        public decimal Revendedor1 { get; set; }
        public decimal Revendedor2 { get; set; }
        public decimal Revendedor3 { get; set; }
    }

    public class Tabela_Descontos
    {
        public int ID_Tabela { get; set; }
        public string Descricao { get; set; }
        public decimal Inicio { get; set; }
        public decimal Termino { get; set; }
    }

    public class Vale_Troca
    {
        public int ID_Troca { get; set; }
        public int ID_Venda { get; set; }
        public string Status { get; set; }
        public DateTime Validade { get; set; }
        public decimal Valor  { get; set; }
    }
}

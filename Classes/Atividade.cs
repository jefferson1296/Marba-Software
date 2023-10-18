using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbaSoftware
{
    public class Curso
    {
        public int ID_Curso { get; set; }
        public string Descricao { get; set; }
        public string Cargo { get; set; }
        public int Atividades { get; set; }
        public string Nivel { get; set; }
    }

    public class Sessao
    {
        public int ID_Sessao { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
    }

    public class Materia : Curso
    {
        public int ID_Materia { get; set; }
        public string Tipo { get; set; }
        public decimal Horas { get; set; }
        public int ID_Sessao { get; set; }
        public string Sessao { get; set; }
        public int Ordem { get; set; }
    }

    public class Aula : Materia
    {
        public int ID_Aula { get; set; }
        public DateTime Data { get; set; }
    }

    public class Treinamento : Curso
    {
        public int ID_Treinamento { get; set; }
        public int Colaboradores { get; set; }
    }

    public class Processo
    {
        public int ID_Processo { get; set; }
        public string Descricao { get; set; }
        public int Atividades { get; set; }
    }

    public class Atividade : Processo
    {
        public int ID_Atividade { get; set; }
        public int Ordem { get; set; }
        public int Tempo { get; set; }
        public string Setor { get; set; }
        public string Cargo { get; set; }
        public int Prioridade { get; set; }
        public string Resultado { get; set; }
        public string Categoria { get; set; }
        public string Observacao { get; set; }
        public bool Rotina { get; set; }
        public int Intervalo { get; set; }
        public DateTime Proxima_Execucao { get; set; }
        public string Responsavel { get; set; }
        public string Nome_Colaborador { get; set; }
    }

    public class AtividadeLancada : Atividade //Lançadas
    {
        public int ID_AtividadeLancada { get; set; }
        public int ID_Colaborador { get; set; }
        public string Status { get; set; }
        public DateTime Data_Registro { get; set; }
        public string Responsaveis { get; set; }
        public int Dias { get; set; }
        public bool Delegavel { get; set; }
    }

    public class AtividadeDelegada : AtividadeLancada
    {
        public int ID_AtividadeDelegada { get; set; }
        public int Index { get; set; }
    }

    public class AtividadeStatus : AtividadeDelegada //Status
    {
        public int ID_AtividadeStatus { get; set; }
        public string Inicio { get; set; }
        public string Termino { get; set; }
        public string Lancamento { get; set; }
    }

    public class AtividadeRealizada : Atividade
    {
        public int Index { get; set; }
        public DateTime Previsao_Inicio { get; set; }
        public DateTime Previsao_Termino { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public string Status { get; set; }
        public string Mandante { get; set; }
        public int ID_Colaborador { get; set; }
        public string Colaborador { get; set; }
        public bool Aviso { get; set; }   
        public string Especificacao { get; set; }
        public int Ordem { get; set; }
        public string Informacoes { get; set; }
    }

    public class AtividadeEspecificacao
    {
        public string Atividade { get; set; }
        public string Especificacao { get; set; }
        public int Tempo { get; set; }
    }

    public class Hora_Extra
    {
        public string Tipo { get; set; }
        public int Tempo { get; set; }
        public string Periodo { get; set; }
        public int ID_Colaborador { get; set; }
        public int ID_Responsavel { get; set; }
        public DateTime Data { get; set; }
        public DateTime Data_Registro { get; set; }
        public double Extra_100 { get; set; }
        public double Extra_50 { get; set; }
    }

    public class Procedimento
    {
        public int ID_Procedimento { get; set; }
        public string Descricao { get; set; }
        public string Resumo { get; set; }
        public int Ordem { get; set; }
    }

    public class Acao_Corretiva
    {
        public int ID_Correcao { get; set; }
        public string Correcao { get; set; }
    }

    public class Expediente
    {
        public string Status { get; set; }
        public int ID_Colaborador { get; set; }
        public string Colaborador { get; set; }
        public string Data { get; set; }

        public DateTime Previsao_Inicio { get; set; }
        public DateTime Previsao_Termino { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public DateTime Previsao_Lanche_Inicio { get; set; }
        public DateTime Previsao_Lanche_Termino { get; set; }
        public DateTime Lanche_Inicio { get; set; }
        public DateTime Lanche_Termino { get; set; }
        public DateTime Previsao_Almoco_Inicio { get; set; }
        public DateTime Previsao_Almoco_Termino { get; set; }
        public DateTime Almoco_Inicio { get; set; }
        public DateTime Almoco_Termino { get; set; }
        public string Estabelecimento { get; set; }
    }
    public class Expediente_do_Dia
    {
        public string Colaborador { get; set; }
        public string Status { get; set; }
        public string Inicio { get; set; }
        public string Termino { get; set; }
        public string Lanche { get; set; }
        public string Almoco { get; set; }
    }

    public class Horario_Individual
    {
        public string Dia { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }
        public string Estabelecimento { get; set; }
        public string Inicio { get; set; }
        public string Almoco { get; set; }
        public string Lanche { get; set; }
        public string Termino { get; set; }
        public string Horas { get; set; }
    }

    public class Escala
    {
        public int ID_Colaborador { get; set; }
        public string Folga { get; set; }
        public string segServicoInicio { get; set; }
        public string segServicoTermino { get; set; }
        public string segLancheInicio { get; set; }
        public string segLancheTermino { get; set; }
        public string segAlmocoInicio { get; set; }
        public string segAlmocoTermino { get; set; }
        public string sabServicoInicio { get; set; }
        public string sabServicoTermino { get; set; }
        public string sabLancheInicio { get; set; }
        public string sabLancheTermino { get; set; }
        public string sabAlmocoInicio { get; set; }
        public string sabAlmocoTermino { get; set; }
        public string domServicoInicio { get; set; }
        public string domServicoTermino { get; set; }
        public string domLancheInicio { get; set; }
        public string domLancheTermino { get; set; }
        public string domAlmocoInicio { get; set; }
        public string domAlmocoTermino { get; set; }
    }

    public class Horario
    {
        public int ID_Horario { get; set; }
        public int ID_Colaborador { get; set; }
        public string Descricao { get; set; }
        public string Dia { get; set; }
        public string Inicio { get; set; }
        public string Termino { get; set; }
        public bool Folga { get; set; }
    }

    public class Turno : Horario
    {
        public int ID_HorarioTurno { get; set; }
        public int ID_Turno { get; set; }
        public bool Rodizio { get; set; }
    }

    public class Data
    {
        public int ID_Data { get; set; }
        public string Dia { get; set; }
        public string Descricao { get; set; }
        public bool Promocao { get; set; }
        public string Observacao { get; set; }
        public string Loja { get; set; }
        public string Tipo { get; set; }
    }

    public class Projeto
    {
        public int ID_Projeto { get; set; }
        public int ID_Colaborador { get; set; }
        public string Colaborador { get; set; }

        public string Detalhes { get; set; }
        public string Status { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public string Resultado_Esperado { get; set; }


        public string Descricao { get; set; }

        //Novos
        public string O_Que { get; set; }
        public string Por_Que { get; set; }
        public string Onde { get; set; }
        public List<Etapa> Etapas { get; set; }
        public List<Custo> Custos  { get; set; }
        public List<Checklist> Checklist { get; set; }
    }

    public class Etapa : Projeto
    {
        public string Projeto { get; set; }
        public int ID_Etapa { get; set; }
        public int Ordem { get; set; }


        //Novos
        public new string Descricao { get; set; }
        public string Como { get; set; }
        public string Quem { get; set; }
        public int Prazo { get; set; }
        public DateTime Previsao_Inicio { get; set; }
        public new DateTime Inicio { get; set; }
        public DateTime Previsao_Termino { get; set; }
        public new DateTime Termino { get; set; }
        public bool Conclusao { get; set; }
        public string Resultado { get; set; }
    }

    public class Checklist
    {
        public int ID { get; set; }
        public int Referencia { get; set; }
        public int Ordem { get; set; }
        public string Descricao { get; set; }
        public bool Confirmacao { get; set; }
    }

    public class Custo
    {
        public int ID { get; set; }
        public int Ordem { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
    }

    public class Digital
    {
        public int Impressao_Digital { get; set; }
        public int ID_Colaborador { get; set; }
        public string Colaborador { get; set; }
    }

    public class Notificacao
    {
        public int Ordem { get; set; }
        public int ID_Notificacao { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public DateTime Hora { get; set; }
        public int Visto { get; set; }
    }

    public class Colaborador
    {
        public int ID_Colaborador { get; set; }
        public string Nome_Colaborador { get; set; }
        public string Sobrenome { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set; }
        public DateTime Aniversario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Mes_Ferias { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
        public DateTime Data_Admissao { get; set; }
        public string Formacao { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public decimal Comportamento { get; set; }
        public string Codigo_Banco { get; set; }
        public string Agencia_Banco { get; set; }
        public string Conta_Banco { get; set; }
        public string Chave_Pix { get; set; }
        public string Tipo_ChavePix { get; set; }
        public string CTPS { get; set; }
        public string Serie_CTPS { get; set; }
        public string PIS { get; set; }
        public string Titulo_Eleitor { get; set; }
        public string Zona_Titulo { get; set; }
        public string Sessao_Titulo { get; set; }
        public string CNH { get; set; }
        public string Categoria_CNH { get; set; }
        public DateTime Validade_CNH { get; set; }
        public int Filhos { get; set; }
        public string Matricula { get; set; }
        public string Folga { get; set; }
        public string Digital1 { get; set; }
        public string Digital2 { get; set; }
        public string Digital3 { get; set; }
        public string Celular { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Estado_Civil { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public decimal Banco_Horas { get; set; }
        public bool Possui_CNH { get; set; }
        public byte[] Foto { get; set; }
        public string Status { get; set; }
        public string Reparticao { get; set; }
        public bool Ativacao { get; set; }
    }

    public class Acesso
    {
        public int ID_Acesso { get; set; }
        public string Descricao { get; set; }
        public int ID_Colaborador { get; set; }
        public bool Permissao { get; set; }
        public bool Requisito { get; set; }
        public int ID_Requisito { get; set; }
        public string Categoria { get; set; }
        public string Status { get; set; }
    }

    public class Licenca
    {
        public int ID_Licenca { get; set; }
        public string Matricula { get; set; }
        public int ID_Colaborador { get; set; }
        public string Colaborador { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public string Tipo { get; set; }
    }

    public class Parametro
    {
        public int ID_Parametro { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }
        public bool Edicao { get; set; } //Utilizado apenas para editar configurações
    }

    public class Estabelecimento
    {
        public int ID_Estabelecimento { get; set; }
        public string Descricao { get; set; }
        public int Metros { get; set; }
        public string Categoria { get; set; }
        public string Status { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Equipamentos { get; set; }
        public int Colaboradores { get; set; }
    }

    public class Reparticao : Estabelecimento
    {
        public int ID_Reparticao { get; set; }
        public int ID_Gerente { get; set; }
        public string Estabelecimento { get; set; }
        public string Setor { get; set; }
    }

    public class Equipamento
    {
        public int ID_Equipamento { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
    }

    public class Depreciacao : Equipamento
    {
        public decimal Percentual { get; set; }
    }

    public class Identificacao
    {
        public int ID_Identificacao { get; set; }
        public string Descricao { get; set; }
        public string Setor { get; set; }
        public bool Auto_Impressao { get; set; }
    }

    public class Abreviacao
    {
        public int ID_Abreviacao { get; set; }
        public string Texto { get; set; }
        public string Descricao { get; set; }
    }

    public class Regulamento
    {
        public int ID_Regulamento { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public DateTime Registro { get; set; }
    }

    public class Topico_Regulamento
    {
        public string Topico { get; set; }
        public string Detalhes { get; set; }
        public int Ordem { get; set; }
    }

    public class SWOT
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
    }

    public class Assunto
    {
        public int ID_Assunto { get; set; }
        public string Descricao { get; set; }
        public DateTime Registro { get; set; }
        public bool Impressao{ get; set; }
    }

    public class Afazer
    {
        public int ID_Afazer { get; set; }
        public int Ordem { get; set; }
        public int ID_Etapa { get; set; }
        public string Descricao { get; set; }
        public string Detalhes { get; set; }
        public int Minutos { get; set; }
        public int ID_Colaborador { get; set; }
        public bool Conclusao { get; set; }
        public DateTime Registro { get; set; }
        public DateTime Data { get; set; }

    }

    public class ComparadorGenerico<T> : IEqualityComparer<T>
    {
        public Func<T, T, bool> MetodoEquals { get; }
        public Func<T, int> MetodoGetHashCode { get; }
        private ComparadorGenerico(
            Func<T, T, bool> metodoEquals,
            Func<T, int> metodoGetHashCode)
        {
            this.MetodoEquals = metodoEquals;
            this.MetodoGetHashCode = metodoGetHashCode;
        }

        public static ComparadorGenerico<T> Criar(
            Func<T, T, bool> metodoEquals,
            Func<T, int> metodoGetHashCode)
                => new ComparadorGenerico<T>(
                        metodoEquals,
                        metodoGetHashCode
                    );

        public bool Equals(T x, T y)
            => MetodoEquals(x, y);

        public int GetHashCode(T obj)
            => MetodoGetHashCode(obj);
    }

    public static class DistinctExtension
    {
        public static IEnumerable<TSource> Distinct<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, TSource, bool> metodoEquals,
            Func<TSource, int> metodoGetHashCode)
                => source.Distinct(
                    ComparadorGenerico<TSource>.Criar(
                        metodoEquals,
                        metodoGetHashCode)
                        );
    }


}

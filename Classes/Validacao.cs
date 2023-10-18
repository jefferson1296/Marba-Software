using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbaSoftware
{    
    public class Validacao
    {
        public int Index { get; set; }
        public string Utensilio { get; set; }
        public string Produto { get; set; }
        public double Custo { get; set; }
        public string Status { get; set; }
        public string Ativacao { get; set; }
        public string Disponibilidade { get; set; }
        public string _Validacao { get; set; }
    }
    public class AtualizarProduto
    {
        public int Index { get; set; }
        public string Produto { get; set; }
    }
    public class Pagamento
    {
        public int ID_Pagamento { get; set; }
        public decimal Valor { get; set; }
        public decimal Pago { get; set; }
        public decimal Troco { get; set; }
        public string Forma { get; set; }
        public string Bandeira { get; set; }
        public int Parcelas { get; set; }
        public decimal Juros { get; set; }
    }

    public class FormasDePagamento
    {
        public double Dinheiro { get; set; }
        public double Credito { get; set; }
        public double Debito { get; set; }
        public double Pix { get; set; }
        public double Transferencia { get; set; }
        public double TEF { get; set; }
        public double Vale { get; set; }
    }
    public class InformacoesFechamento
    {
        public decimal Dinheiro { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Pix { get; set; }
        public decimal Transferencia { get; set; }
        public decimal TEF { get; set; }
        public decimal PICPAY { get; set; }
        public decimal Vale { get; set; }
        public decimal Sangrias { get; set; }
        public decimal Suprimentos { get; set; }
        public decimal Sobrando { get; set; }
        public decimal Abertura{ get; set; }
        public decimal Total { get; set; }
        public decimal Quebra { get; set; }
    }
    public class RestricoesDeAcesso
    {
        public string Descricao { get; set; }
        public bool Acesso { get; set; }
    }
    public class ValidadorClientes
    {
        //CRIANDO MÉTODOS:
        public bool CPF(string numero)//TIPO DE RETORNO: bool PARA MOSTRAR VERDADEIRO OU FALSO QUANDO O MÉTODO RECEBER UMA string;
        {
            bool verificar = false;
            try
            {
                
                bool digito1 = false;
                bool digito2 = false;
                string cpf;

                string[] mascara = numero.Split('.');
                string[] dig = mascara[2].Split('-');
                cpf = mascara[0] + mascara[1] + dig[0] + dig[1];

                //VALIDAÇÃO DO PRIMEIRO DÍGITO DO CPF
                string[] cpf1 = new string[11]; //SIGNIFICA QUE cpf1 É UM VETOR DA VARIÁVEL cpf QUE CONTÉM 11 DÍGITOS

                for (int i = 0; i < cpf.Length; i++) //i SE INICIARÁ COM 0 E ENQUANTO i < QUE O CUMPRIMENTO DA VARIÁVEL string cpf
                {
                    cpf1[i] = cpf.Substring(i, 1); //A POSIÇÃO i DO VETOR cpf1 SERÁ IGUAL A POSIÇÃO ESPECIFICADA DA STRING cpf (i) E TERÁ UM CUMPRIMENTO ESPECIFICADO  (1)
                }

                int[] multiplicadores1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 }; //VETOR DE 9 POSIÇÕES PARA ARMAZENAR OS MULTIPLICADORES
                                                                                    //NESSE CASO JÁ ESTAMOS INDICANDO OS NÚMEROS (tipo int) QUE FICARÃO EM CADA UMA DAS 9 POSIÇÕES
                int[] resultados1 = new int[9]; //VETOR DE 9 POSIÇÕES PARA ARMAZENAR O RESULTADO DA MULTIPLICAÇÃO DOS NÚMEROS DIGITADOS PELOS MULTIPLCIADORES

                for (int i = 0; i < 9; i++)
                {
                    resultados1[i] = Convert.ToInt32(cpf1[i]) * multiplicadores1[i]; //MULTIPLICANDO OS DIGITOS PELOS MULTIPLICADORES
                }
                int totalTabela = 0; //RESULTADO DA SOMA DAS MULTIPLICAÇÕES
                for (int i = 0; i < 9; i++) //ESSE FOR SIGNIFICA QUE A SOMA SE REPETIRÁ 9 VEZES
                {
                    totalTabela = totalTabela + resultados1[i]; //REPETE A SOMA DAS MULTPIPLICAÇÕES ATÉ SOMAR OS 9 RESULTADOS
                }

                int parteInteira = totalTabela / 11; //PARTE INTEIRA DO QUOCIENTE DA DIVISÃO totalTabela / 11
                int restoDaDivisao = totalTabela % 11; //RETORNA O RESTO DA DIVISÃO totalTabela / 11
                int primeiroDigito;
                if (restoDaDivisao < 2) //CONFORME A FÓRMULA DE OBTER O DÍGITO DO CPF, SE O RESTO DA DIVISÃO FOR MENOR QUE 2...
                {
                    primeiroDigito = 0; //...O PROGRAMA IRÁ ATRIBUIR 0 AO PRIMEIRO DÍGITO
                }
                else //SE O RESTO DA DIVISÃO FOR IGUAL OU MAIOR QUE 2 (else restoDaDivisao <2)...  
                {
                    primeiroDigito = 11 - restoDaDivisao; //...O PRIMEIRO DÍGITO DEVERÁ SER 11 - restoDaDivisao
                }

                //COMPARAÇÃO FINAL ENTRE O 9° CARACTER DIGITADO (PRIMEIRO DÍGITO DO CPF DIGITADO) E O PRIMEIRO DÍGITO DO CPF CALCULADO
                if (primeiroDigito != Convert.ToInt32(cpf1[9])) //SE O primeiroDigito Primeiro dígito calculado) FOR DIFERENTE DA CONVERSÃO DO VETOR cpf1[9] (Primeiro dígito informado) 
                {
                    digito1 = false; //
                }
                else
                {
                    digito1 = true; //
                }

                //VALIDAÇÃO DO SEGUNDO DÍGITO DO CPF
                int[] multiplicadores2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] resultados2 = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    resultados2[i] = Convert.ToInt32(cpf1[i]) * multiplicadores2[i];
                }
                int totalTabela2 = 0;

                for (int i = 0; i < 10; i++)
                {
                    totalTabela2 = totalTabela2 + resultados2[i];
                }
                int parteInteira2 = totalTabela2 / 11;
                int restoDaDivisao2 = totalTabela2 % 11;

                int segundoDigito;
                if (restoDaDivisao2 < 2)
                {
                    segundoDigito = 0;
                }
                else
                {
                    segundoDigito = 11 - restoDaDivisao2;
                }
                if (Convert.ToInt32(cpf1[10]) != segundoDigito)
                {
                    digito2 = false;
                }
                else
                {
                    digito2 = true;
                }

                //COMPARAÇÃO FINAL DO RESULTADO DOS 2 DÍGITOS
                if (digito1 == true && digito2 == true)
                {
                    verificar = true;
                }
                else
                {
                    verificar = false;
                }
            }
            catch
            {

            }
            return (verificar);
        }
        public bool Telefone(string numero)
        {
            bool verificar = false;
            try
            {
                int posicao = numero.IndexOf('9', 5, 1); //COMANDO UTILIZADO PARA ENCONTRAR UM CARACTER ESPECÍFICO, NUMA POSIÇÃO ESPECÍFICA. O ÚLTIMO NÚMERO SE REFERE A POSIÇÃO QUE SERÁ VERIFICADA EM RELAÇÃO A POSIÇÃO ESPECIFICADA
                                                         //NO NOSSO EXEMPLO QUEREMOS ENCONTRAR O "9" NA POSIÇÃO 5 . "POSIÇÃO 0 = "(" , 1 = "8", 2 = "1", 3 = ")", 4 = " ", 5 = 9"" 
                                                         //SE O numero.IndexOf NÃO ENCONTRAR UM 9 NA QUARTA POSIÇÃO, ELE RETORNA "-1", SE ENCONTRAR UM 9, RETORNA 5;
                if (posicao == 5) //SIGNIFICA QUE TEM UM NÚMERO 9 NA 5ª POSIÇÃO, LOGO É UM NÚMERO DE CELULAR VÁLIDO
                                  //SE O numero.IndexOf RETORNOU 5, SIGINIFICA QUE ENCONTROU UM 9 NA 5ª POSIÇÃO
                {
                    if (numero.Length == 15) //SE TIVER 15 DIGITOS DE CUMPRIMENTO = (81) 99999-9999
                    {
                        verificar = true;
                    }
                    else
                    {
                        verificar = false;
                    }
                }
                else
                {
                    if (numero.Length == 14) //SE NÃO TIVER UM NÚMERO 9 NA QUARTA POSIÇÃO
                    {
                        verificar = true;
                    }
                    else
                    {
                        verificar = false;
                    }
                }
            }
            catch { }
            return (verificar);
        }
        public bool Email(string endereco)
        {
            bool verificar = false;
            try
            {
                verificar = endereco.Contains("@") && endereco.Contains(".com");
            }
            catch { }
            return (verificar);
        }
    }
}

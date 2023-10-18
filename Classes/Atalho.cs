using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarbaSoftware
{
    public static class Atalho
    {
        public static string PrimeiraLetraMaiuscula(this string inserir)
        {
            if (String.IsNullOrEmpty(inserir))
                throw new ArgumentException("Insira uma palavra");
            return inserir.Length > 1 ? char.ToUpper(inserir[0]) + inserir.Substring(1) : inserir.ToUpper();
        }

        public static decimal ToDecimal(this int valor)
        {
            Convert.ToDecimal(valor);
            return valor;
        }
    }
}

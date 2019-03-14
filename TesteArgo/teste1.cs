using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteArgo
{
    public class teste1
    {
        public int Somar(int n1, int n2)
        {
			int soma;
			soma = n1 + n2;

            return soma;
        }

        public int Subtrair(int n1, int n2)
        {
			int resultado;
			resultado = n1 - n2;

			return resultado;
        }

        public decimal Media(params int[] valores)
        {
			decimal total = 0;
			decimal media = 0;

			for (int i = 0; i < valores.Length; i++)
			{
				total += valores[i];
			};

			media = total / valores.Length;

            return media;
        }

    }
}

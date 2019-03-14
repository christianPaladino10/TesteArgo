using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteArgo
{
    public class teste2
    {
        public List<int> CriarLista(int quantidade)
        {
			var listaInt = new List<int>();

			for (int i = 0; i < quantidade; i++)
			{
				listaInt.Add(i);
			}

			return listaInt;
		}

        public List<int> OrdenarLista(params int[] valores)
        {
			var listaInt = valores.OrderBy(x => x).ToList();

			return listaInt;
		}
    }
}

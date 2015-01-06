using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsandoWebServices
{
    [Serializable]
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}

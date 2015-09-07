using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exemplo01
{
    public enum Populacao
    {
        Ate50Mil,
        Acima50Mil,
        Acima100Mil,
        Acima200Mil
    }
    public class Registro
    {
        public string Nome { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public bool Capital { get; set; }
        public Populacao Populacao { get; set; }
        public DateTime DataEmancipacao { get; set; }
    }
}

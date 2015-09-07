using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo03
{
    public class Carro : Terrestre
    {
        public int QtdePortas;
        public bool Conversivel;
        public int CapacidadeBagageiro;

        public void Acelerar()
        {
            throw new System.NotImplementedException();
        }

        public void Freiar()
        {
            throw new System.NotImplementedException();
        }
    }
}

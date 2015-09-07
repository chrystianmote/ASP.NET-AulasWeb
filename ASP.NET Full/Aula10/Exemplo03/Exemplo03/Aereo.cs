using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo03
{
    public class Aereo : Veiculo
    {
        private int TetoVoo;

        public int TetoVoo1
        {
            get { return TetoVoo; }
            set
            {
                if ((value >= 50) && (value <= 200))
                {
                    TetoVoo = value;
                }
                else
                {
                    throw new Exception("O Teto de Vôo deve estar entre 50 e 200.");
                }

            }
        }
        public TipoDecolagemVeiculoAereo TipoDecolagem;
        public int AlturaAtual;

        private int _VelocidadeCruzeiro;
        public int VelocidadeCruzeiro
        {
            get
            {
                return _VelocidadeCruzeiro;
            }
            set
            {
                if (value > 20)
                {
                    _VelocidadeCruzeiro = value;
                }
                else
                {
                    throw new Exception("A velocidade de cruzeiro deve ser maior do que 20.");
                }
            }

        }
    }
}

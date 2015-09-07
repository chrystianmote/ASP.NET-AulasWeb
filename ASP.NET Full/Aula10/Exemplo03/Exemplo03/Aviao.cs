using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Exemplo03
{
    public class Aviao : Aereo
    {
        public TipoPropulsaoAviao TipoPropulsao;
        private int _TaxaSubida;

        public int TaxaSubida
        {
            get { return _TaxaSubida; }
            set 
            {
                if (value > 0)
                {
                    _TaxaSubida = value;
                }
                else
                {
                    throw new Exception("Taxa de subida inválida!");
                }
            }
        }
        private int _TaxaDescida;

        public int TaxaDescida
        {
            get { return _TaxaDescida; }
            set 
            {
                if (value > 0)
                {
                    _TaxaDescida = value;
                }
                else
                {
                    throw new Exception("Taxa de descida inválida!");
                }
            }
        }

        public Aviao()
        {
            this.VelocidadeAtual = 0;
            this.AlturaAtual = 0;
            this.TipoDecolagem = TipoDecolagemVeiculoAereo.Horizontal;
            Console.WriteLine("Novo Avião criado com sucesso!");
            Console.WriteLine("Velocidade atual: {0}", this.VelocidadeAtual);
            Console.WriteLine("Altura atual: {0}", this.AlturaAtual);
        }

        public void Aterrisar()
        {
            Console.Clear();
            Console.WriteLine("Aterrisagem iniciada...");
            Thread.Sleep(2000);
            Console.Clear();
            while (this.AlturaAtual > 0)
            {
                this.AlturaAtual -= this.TaxaDescida/5;
                Console.WriteLine("ALtura atual: {0}", this.AlturaAtual);
                Thread.Sleep(2000);
                Console.Clear();
            }
            Console.WriteLine("Aterrisagem concluida!");
            Thread.Sleep(2000);
            this.VelocidadeAtual = 0;
        }

        public void Decolar()
        {
            Console.Clear();
            Console.WriteLine("Decolagem iniciada...");
            Thread.Sleep(2000);
            while (this.AlturaAtual < this.TetoVoo1)
            { 
                this.AlturaAtual += this.TaxaSubida/5;
                Console.WriteLine("ALtura atual: {0}",this.AlturaAtual);
                Thread.Sleep(200);
                Console.Clear();
            }
            Console.WriteLine("Decolagem concluida!");
            Thread.Sleep(2000);
            this.VelocidadeAtual = this.VelocidadeCruzeiro;
        }

        public void Voar(int Tempo)
        {
            Console.Clear();
            Console.WriteLine("Iniciando Vôo...");
            Thread.Sleep(2000);
            Console.Clear();
            for (int i = 0; i < Tempo; i++)
            {
                Console.WriteLine("Distância percorrida: {0}", (i+1)*this.VelocidadeAtual);
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.WriteLine("Vôo Concluido!");
            Thread.Sleep(2000);
        }
    }
}

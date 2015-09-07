using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo01
{
    class Program
    {
        static void Main(string[] args)
        {
            //comandos para saída de dados
            Console.WriteLine("Programa SuperPowerTotal");
            Console.WriteLine("Programa criado por {0} em {1}.", "Saulo Pacífico", DateTime.Now);

            //reserva um espaço em memória para guardar texto
            string nome;
            
            //Solicita ao usuário a digitação do nome (apenas instrução de uso de programa)
            Console.Write("Digite seu nome completo: ");
            
            //lê uma informação digitada e guarda na variável "nome"
            nome = Console.ReadLine();

            //escreve uma mensagem para o usuário incluindo o valor armazenado na variável "nome"
            Console.WriteLine("Olá, {0}! você está no meu programa!", nome);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exemplo07
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;

            //incrementa a variável em uma unidade (num = num + 1)
            num++;
            Console.WriteLine(num);
            //soma do valor 5 a variável (num = num recebe +5)
            num += 5;
            Console.WriteLine(num);
            //multiplica a variável por 2 (num = num * 2)
            num *= 2;
            Console.WriteLine(num);
            //subtrai a variável em 1 unidade (num = num - 1)
            num--;
            Console.WriteLine(num);
            //subtrai 3 do valor da variável (num = num - 3)
            num -= 3;
            Console.WriteLine(num);

            Console.WriteLine("Este \"texto\" está ente aspas.");
        }
    }
}

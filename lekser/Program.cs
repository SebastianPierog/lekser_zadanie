using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekser
{
    class Program
    {
        static void Main(string[] args)
        {
            string expresion = "1  +  (2 *34)/ 506 +7809";
            Lekser lex = new Lekser();
            (bool res, int indexEnd) = lex.Analyse(expresion);
            if (res)
            {
                Console.WriteLine("Rozpoznano wyrazenie");

            }
            else
            {
                int index;
                Console.WriteLine("Błąd analizy leksykalnej :(");
                Console.WriteLine("Nieznany token: {1}, na pozyacji {0}",
                   index = lex.SignArrary.Count > 0 ? indexEnd : 0,
                   expresion.Substring(index, expresion.Length - index > 10 ? 10 : expresion.Length - index));
            }
            foreach (Token token in lex.SignArrary)
            {
                Console.WriteLine($"<{token.Name}, {token.Argument}>");
            }
            Console.ReadLine();
        }
    }
}

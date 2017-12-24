using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            long a;
            bool type;
            do
            {
                Console.WriteLine("Please, type the integer number from 1 to 20");
                type = Int64.TryParse(Console.ReadLine(), out a);
            }
            while (a < 1 || a > 20);
                Console.WriteLine("{0}!={1}", a, Math.Exp(a));
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
      /*  public static long Factorial(long a)
            {
            a=Math.Exp()
                long rez = a;
                if (a == 0) return 1;
                else
                {
                    for (int i = 1; i <= a - 1; i++)
                    {
                        rez = i * rez;
                    }
                    return rez;
                }
            }
*/

        }
    }





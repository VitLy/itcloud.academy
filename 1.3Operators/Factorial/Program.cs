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
            int a = 0;
            do
            {
                try
                {
                    Console.WriteLine("Please, type the integer number from 1 to 20");
                    a = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    a = 0;
                    break;
                }
            }
            while (a < 1 || a > 20);
            Console.WriteLine("{0}!={1}",a,Factorial(a));
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
        public static long Factorial(long _a)
        {
            long _rez = _a;
            if (_a == 0) return 1;
            else
            {
                for (int i = 1; i <= _a-1; i++)
                {
                    _rez = i * _rez;
                }
                return _rez;
            }
        }


    }
}





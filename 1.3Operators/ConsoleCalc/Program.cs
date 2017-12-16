using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int chose = 0;
            float x, y = 0f;
            bool correctInput = false;
            Console.WriteLine("Num 1 - Multiplication");
            Console.WriteLine("Num 2 - Divide");
            Console.WriteLine("Num 3 - Addition");
            Console.WriteLine("Num 4 - Subtraction");
            Console.WriteLine("Num 5 - Exponentiation");
            Console.WriteLine("Num 6 - Exit");
            Console.WriteLine("Please, choose number from one to five to continue...");
            do
            {
                correctInput = Int32.TryParse(Console.ReadLine(), out chose);
                Console.WriteLine("Please, choose number from one to five to continue...");
            }
            while (chose < 1 || chose > 6 && correctInput);
            Console.Clear();
            x = GetNum();
            y = GetNum();
            float z1;

            switch (chose)
            {
                case 1:
                    {
                        z1 = Mul(x, y);
                        Print("Multiplication", x.ToString(), y.ToString(), z1.ToString());
                        break;
                    }
                case 2:
                    {
                        z1 = Div(x, y);
                        Div(x, y);
                        Print("Divide", x.ToString(), y.ToString(), z1.ToString());
                        break;
                    }
                case 3:
                    {
                        z1 = Add(x, y);
                        Print("Addition", x.ToString(), y.ToString(), z1.ToString());
                        break;
                    }
                case 4:
                    {
                        z1 = Sub(x, y);
                        Print("Subtraction", x.ToString(), y.ToString(), z1.ToString());
                        break;
                    }
                case 5:
                    {
                        z1 = Exp(x, y);
                        Print("Exponentiation", x.ToString(), y.ToString(), z1.ToString());
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Thank for you choose! See you!");
                        break;
                    }
            }
        }
        public static float GetNum()
        {
            bool isTrueInput = true;
            float a = 0f;
            Console.WriteLine("Please, choose number:");

            do
            {

                isTrueInput = float.TryParse(Console.ReadLine(), out a);
                if (!isTrueInput) Console.WriteLine("Error, repeat please");
            }
            while (!isTrueInput);
            return a;
        }


        public static float Mul(float x, float y)
        {
            return x * y;
        }
        public static float Div(float x, float y)
        {
            return x / y;
        }
        public static float Add(float x, float y)
        {
            return x + y;
        }
        public static float Sub(float x, float y)
        {
            return x - y;
        }
        public static float Exp(float x, float y)
        {
            float rez = 1;
            if (y == 0) return 1;
            else
            {
                while (y >= 1)
                {
                    rez = x * rez;
                    y = y - 1;
                }
                return rez;
            }
        }
        public static void Print(string _oper, string _x, string _y, string _result)
        {
            Console.Clear();
            Console.WriteLine("You chose:");
            Console.WriteLine("Operation:" + _oper);
            Console.WriteLine("Num1:" + _x);
            Console.WriteLine("Num2:" + _y);
            Console.WriteLine("Result:" + _result);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game_bulls_and_cows_ver2
{
    class Program
    {
        enum Level       // set steps
        {
            easy = 7,
            normal = 8,
            hard = 9
        }
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int bulls = 0; ; //count of bulls in current number from computer
            int cows = 0; //count of cows in current number from computer
            string number;  // current number from computer          
            int step = 1; // current move
            int countwinComp = 0;
            int countwinPlayer = 0;
            Level currentLevel;

            // Prepear start data
            List<string> allComb = new List<string>();     // list of all possible significant 
            // Start Game
            int game = 0;
            do
            {
                game++;
                step = 0;
                bulls = 0;
                cows = 0;
                DisplayRule();
                PrepearAllComb(allComb);
                currentLevel = ChooseLevel();
                //             string path = @"D:\My\Programm\ITCloud\HomeWork\1.3Operators\Game bulls and cows_ver2\hisory.txt";
                while ((bulls != 4) && (step <= (int)(currentLevel)))
                {

                    DisplayStatistic(step, currentLevel, countwinPlayer, countwinComp);
                    try
                    {
                        number = allComb[RandomNumber(allComb.Count)];
                    }
                    catch 
                    {
                        bulls = 4;
                        break;
                    }
                    Console.WriteLine("maybe this number is: {0}  ?", number);
                    do
                    {
                        bulls = GetCountBullsCows("bulls");
                        cows = GetCountBullsCows("cows ");
                    }
                    while ((Math.Abs(bulls) + Math.Abs(cows)) > 4);
                    //    File.AppendAllText(path, game.ToString() + "|" + number.ToString() + "|" + bulls.ToString() + "," +
                   // cows.ToString() + "|");
                    Optimization(allComb, number, bulls, cows);
                    for (int j = 0; j <= allComb.Count - 1; j++)
                    {
                        if (!(bulls.ToString() + cows.ToString()).Equals(CalcBullsCows(allComb[j], number)))
                        {
                            allComb.RemoveAt(j);
                        }
                    }
                    step++;
                }
                if (bulls == 4)
                {
                    Console.WriteLine("You Lose!!!, Computer Win");
                    countwinComp++;
                }
                else
                {
                    Console.WriteLine("Congratulation, You Win!!!");
                    countwinPlayer++;
                }
                Console.Write("Press any Key  to start or Esc to Exit .....");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void Optimization(List<string> allComb, string number, int bulls, int cows)
        {
            if (bulls + cows == 4 && bulls != 4)  //delete all records, which dont consist digit from number !!!!!!!!!!!!Сейчас оставляет, оставить только сочетание всех 4 цифр в числе
            {
                for (int j = 0; j <= allComb.Count - 1; j++)
                    for (int i = 0; i < 4; i++)
                    {
                        string k = allComb[j];
                        if ((number[i] != k[0]) & (number[i] != k[1]) & (number[i] != k[2]) & (number[i] != k[3]))
                        {
                            allComb.RemoveAt(j);
                            j--;
                            break;
                        }
                    }
            }
            if (bulls == 0 & cows == 0) //delete all records, which consist bulls or cows from number
            {
                for (int j = 0; j <= allComb.Count - 1; j++)
                    for (int i = 0; i < 4; i++)
                    {
                        string k = allComb[j];
                        if ((number[i] == k[0]) || (number[i] == k[1]) || (number[i] == k[2]) || (number[i] == k[3]))
                        {
                            allComb.RemoveAt(j);
                            j--;
                            break;
                        }
                    }
            }
            if (bulls == 0 & cows > 0) //delete all records, where same digit placed on the place as digits in number
            {
                for (int j = 0; j <= allComb.Count - 1; j++)
                {
                    string k = allComb[j];
                    if ((k[0] == number[0]) || (k[1] == number[1]) || (k[2] == number[2]) || (k[3] == number[3]))
                    {
                        allComb.RemoveAt(j);
                        j--;
                    }
                }
            }
        }
        private static void PrepearAllComb(List<string> allComb)
        {
            string number = "";
            int countVariation = 0;
            for (int i = 123; i < 9999; i++)               // will make it
            {
                number = FilterAllComb(i);                 //Metod FilterAllComb can be check off for repeat digits in number  
                if (number != "0")
                {
                    allComb.Add(number);
                    countVariation++;
                }                                         // have made it
            }
        }
        private static int RandomNumber(int countVariation)
        {
            return rnd.Next(0, countVariation);
        }

        private static string CalcBullsCows(string num1, string num2)
        {
            int b = 0; // bulls
            int c = 0; // cows
            int t = 0; // totals
                       //find bulls
            for (int i = 0; i <= 3; i++)
                if (num1[i].Equals(num2[i])) b++;
            //find bulls+cows
            for (int i = 0; i <= 3; i++)
                for (int j = 0; j <= 3; j++)
                {
                    if (num1[i].Equals(num2[j])) t++;
                }
            c = t - b;
            return ((b.ToString()) + (c.ToString()));
        }
        private static int GetCountBullsCows(string animal)
        {
            int animals = 0;
            bool flagCorrectInput1 = false;
            do
            {
                Console.Write($"{animal}: ");
                flagCorrectInput1 = Int32.TryParse(Console.ReadLine(), out animals);
            }
            while (!flagCorrectInput1 || animals.ToString().Length <= 0 || animals.ToString().Length > 5);
            return animals;
        }

        private static void DisplayStatistic(int step, Level currentLevel, int countwinPlayer, int countwinComp)
        {
            Console.Clear();
            Console.WriteLine("Game 'Bulls and Cows'");
            Console.WriteLine("Score:");
            Console.WriteLine("Player: {0}", countwinPlayer);
            Console.WriteLine("Computer: {0}", countwinComp);
            Console.WriteLine("lavel: {0}", currentLevel);
            Console.WriteLine("Step: {0}", step);
            Console.SetCursorPosition(0, 7);
        }
        private static Level ChooseLevel()
        {
            int level;
            bool correctInput;
            do
            {
                Console.WriteLine("Select level (0-easy,1-normal,2-hard):");
                correctInput = Int32.TryParse(Console.ReadLine(), out level);
            }
            while (level != 0 & level != 1 & level != 2);
            switch (level)
            {
                case 0:
                    return Level.easy;
                case 1:
                    return Level.normal;
                default:
                    return Level.hard;
            }
        }
        private static void DisplayRule()
        {
            Console.Clear();
            Console.WriteLine("It is roole of the game 'buls and cows':");
            Console.WriteLine("You will play with computer. You may think of number from four not repeat digits.");
            Console.WriteLine("Computer try to gues your number and will give you it version of number.");
            Console.WriteLine("You may give answer at format: (digit1,digi2), where: ");
            Console.WriteLine("digit1 - computer has guesed digits and these digits are placed on correct places");
            Console.WriteLine("digit2 - computer has guesed digit2 digits bat these digits are placed on incorrect places");
            Console.WriteLine("If Computer do not gueses number for 7-9 (easy-hard level) steps, Player wins, else Computer wins");
            Console.SetCursorPosition(0,10);
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine("Think of a number, but rather write it separately on paper.......");
            Console.WriteLine(" ");
            Console.ResetColor();
            Console.WriteLine("Press 'Enter'  to start or 'Esc' to Exit .....");
            Console.ReadLine();
            Console.Clear();
        }
        private static string FilterAllComb(int i)           // create not repeat digit in number
        {
            string k;   //number from 4 digits
            if (i.ToString().Length == 3) k = "0" + (i.ToString());
            else k = i.ToString();
            {
                bool flag = true;
                for (i = 0; i <= 2; i++)
                    for (int j = i + 1; j <= 3; j++)
                    {
                        if (k[i] == k[j])
                        {
                            flag = false;
                            return "0";
                        }
                    }
                return k;
            }
        }
    }
}

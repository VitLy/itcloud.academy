using BlackJack_2;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_2
{
    enum Players
    {
        Both = 0, Player = 1, Computer = 2
    }
    struct Game
    {
        // 0 field=Card,2=cost,3=placed{0-CardDesk,1-Players,2-Computers}
        static string[,] CardDesk = new string[36, 3];
        int ScorePlayer;
        int ScoreComputer;
        //      static Players First;
        static int CountGames;
        static int GameScorePlayer;
        static int GameScoreComputer;
        static Random rnd = new Random();

        public int ScorePlayers(Players gamer)
        {
            if (gamer == Players.Player)
                return ScorePlayer;
            else if (gamer == Players.Computer)
                return ScoreComputer;
            else return 0;
        }
        public static int GameScorePl { get => GameScorePlayer; set => GameScorePlayer = value; }
        public static int GameScoreComp { get => GameScoreComputer; set => GameScoreComputer = value; }
        public static int CountGame { get => CountGames; set => CountGames = value; }

        public Game(Players firstPlayer)
        {
            ScorePlayer = 0;
            ScoreComputer = 0;
            CardDesk = new string[,] {
            { "Ace", "11", "0" }, { "King", "4", "0" }, { "Lady", "3", "0" }, { "Jack", "2", "0" }, { "Ten", "10", "0" }, { "Nine", "9", "0" }, { "Eight", "8", "0" }, { "Seven", "7", "0" }, { "Six", "6", "0" },
            { "Ace", "11", "0" }, { "King", "4", "0" }, { "Lady", "3", "0" }, { "Jack", "2", "0" }, { "Ten", "10", "0" }, { "Nine", "9", "0" }, { "Eight", "8", "0" }, { "Seven", "7", "0" }, { "Six", "6", "0" },
            { "Ace", "11", "0" }, { "King", "4", "0" }, { "Lady", "3", "0" }, { "Jack", "2", "0" }, { "Ten", "10", "0" }, { "Nine", "9", "0" }, { "Eight", "8", "0" }, { "Seven", "7", "0" }, { "Six", "6", "0" },
            { "Ace", "11", "0" }, { "King", "4", "0" }, { "Lady", "3", "0" }, { "Jack", "2", "0" }, { "Ten", "10", "0" }, { "Nine", "9", "0" }, { "Eight", "8", "0" }, { "Seven", "7", "0" }, { "Six", "6", "0" }
        };
        }
        public bool Take(Players gamer)
        {
            int k = 0;
            do
                k = rnd.Next(35);
            while (CardDesk[k, 2] != "0");
            if (gamer == Players.Player)
            {
                CardDesk[k, 2] = "1";
                ScorePlayer = ScorePlayer + Int32.Parse(CardDesk[k, 1]);
                return true;
            }
            else if (gamer == Players.Computer)
            {
                CardDesk[k, 2] = "2";
                ScoreComputer = ScoreComputer + Int32.Parse(CardDesk[k, 1]);
                return true;
            }
            else return false;
        }
        public void DisplayCard(Players gamer)
        {
            Console.WriteLine("{0} card are:|{1}", gamer.ToString(), PrintCard(gamer));
            Console.WriteLine("{0} score are:|{1}", gamer.ToString(), ScorePlayers(gamer));
        }

        public string PrintCard(Players gamer)
        {
            string card = "";
            for (int i = 0; i < 35; i++)
            {
                if (CardDesk[i, 2] == ((int)gamer).ToString())
                {
                    if (i <= 8) card = card + CardDesk[i, 0] + "_peak |";
                    else if ((i > 8) && (i <= 17)) card = card + CardDesk[i, 0] + "_cross |";
                    else if ((i > 17) && (i <= 27)) card = card + CardDesk[i, 0] + "_diamond |";
                    else if ((i > 27) && (i <= 36)) card = card + CardDesk[i, 0] + "_heart |";
                }
            }
            return card;
        }
        public void PrintWin(int ScorePl, int ScoreComp)
        {
            if ((ScoreComp > 21) & (ScorePl > 21))
            {
                if (ScorePl > ScoreComp)
                {
                    Console.Clear();
                    Game.GameScoreComp++;
                    Console.WriteLine("You Loose!");
                    DisplayCard(Players.Player);
                    ScorePlayers(Players.Computer);
                    DisplayCard(Players.Computer);
                    ScorePlayers(Players.Computer);
                }
                else if (ScorePl < ScoreComp)
                {
                    Console.Clear();
                    Game.GameScorePl++;
                    Console.WriteLine("Congratulations, You Win!");
                    DisplayCard(Players.Player);
                    ScorePlayers(Players.Computer);
                    DisplayCard(Players.Computer);
                    ScorePlayers(Players.Computer);
                }
                else
                {
                    Console.Clear();
                    Game.GameScorePl++;
                    Game.GameScoreComp++;
                    Console.WriteLine("Drow, You both Win!");
                    DisplayCard(Players.Player);
                    ScorePlayers(Players.Computer);
                    DisplayCard(Players.Computer);
                    ScorePlayers(Players.Computer);
                }
            }
            else if ((ScorePl <= 21) & (ScoreComp <= 21))
            {
                if (ScorePl > ScoreComp)
                {
                    Console.Clear();
                    Game.GameScorePl++;
                    Console.WriteLine("Congratulations, You Win!");
                    DisplayCard(Players.Player);
                    ScorePlayers(Players.Computer);
                    DisplayCard(Players.Computer);
                    ScorePlayers(Players.Computer);
                }
                if (ScorePl < ScoreComp)
                {
                    Console.Clear();
                    Game.GameScoreComp++;
                    Console.WriteLine("You Loose!");
                    DisplayCard(Players.Player);
                    ScorePlayers(Players.Computer);
                    DisplayCard(Players.Computer);
                    ScorePlayers(Players.Computer);
                }
                if (ScorePl == ScoreComp)
                {
                    Console.Clear();
                    Game.GameScorePl++;
                    Game.GameScoreComp++;
                    Console.WriteLine("Drow, You both Win!");
                    DisplayCard(Players.Player);
                    ScorePlayers(Players.Computer);
                    DisplayCard(Players.Computer);
                    ScorePlayers(Players.Computer);
                }
            }
            else if ((ScorePl <= 21) & (ScoreComp > 21))
            {
                Console.Clear();
                Game.GameScorePl++;
                Console.WriteLine("Congratulations, You Win!");
                DisplayCard(Players.Player);
                ScorePlayers(Players.Computer);
                DisplayCard(Players.Computer);
                ScorePlayers(Players.Computer);
            }
            else if ((ScorePl > 21) & (ScoreComp <= 21))
            {
                Console.Clear();
                Game.GameScoreComp++;
                Console.WriteLine("You Loose!");
                DisplayCard(Players.Player);
                ScorePlayers(Players.Computer);
                DisplayCard(Players.Computer);
                ScorePlayers(Players.Computer);
            }
            Thread.Sleep(2000);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        bool correctInput = false;
        Players userKey = Players.Both;
        int pause = 2500;
        int count;
        do
        {
            Console.Write("Choose who goes first(1-Player first,2-Computer first):");
            correctInput = Players.TryParse(Console.ReadLine(), out userKey);
            Console.Clear();
        }
        while ((!correctInput) || ((userKey != Players.Player) & userKey != Players.Computer));
        Start:
        count = 2;
        Console.Clear();
        Game One = new Game(userKey);
        Game.CountGame++;
        One.Take(Players.Player);
        One.Take(Players.Computer);
        One.Take(Players.Player);
        One.Take(Players.Computer);
        // test AA
        if ((One.ScorePlayers(Players.Player) == 22) & (One.ScorePlayers(Players.Computer) != 22)) One.PrintWin(21, One.ScorePlayers(Players.Computer));
        else if ((One.ScorePlayers(Players.Player) != 22) & (One.ScorePlayers(Players.Computer) == 22)) One.PrintWin(One.ScorePlayers(Players.Player), 21);
        else if ((One.ScorePlayers(Players.Player) == 22) & (One.ScorePlayers(Players.Computer) == 22)) One.PrintWin(21, 21);
        else //AA dont have any players, lets start main game
        {
            if (userKey == Players.Player) //Turn Players
            {
                One.DisplayCard(Players.Player);
                Console.WriteLine("Will you take one more card?");
                Console.WriteLine("\n");
                Console.WriteLine("Press 'Y' to take");
                Console.WriteLine("or any key to finish.....");
                while (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    One.Take(Players.Player);
                    One.DisplayCard(Players.Player);
                    Console.WriteLine("Will you take one more card?");
                    Console.WriteLine("\n");
                    Console.WriteLine("Press 'Y' to take");
                    Console.WriteLine("or any key to finish.....");
                }
                //Turn Computer
                Console.WriteLine("Computer turn..... ");
                Thread.Sleep(pause);
                Console.Clear();
                while (One.ScorePlayers(Players.Computer) < 16)
                {
                    One.Take(Players.Computer);
                    count++;
                }
                Console.WriteLine("The computer is finished. It has {0} cards on its hands",count);
                One.PrintWin(One.ScorePlayers(Players.Player), One.ScorePlayers(Players.Computer));
            }
            if (userKey == Players.Computer)//Turn Computer
            {
                Console.WriteLine("Computer turn..... ");
                Thread.Sleep(pause);
                Console.Clear();
                while (One.ScorePlayers(Players.Computer) < 16)
                {
                    One.Take(Players.Computer);
                    count++;
                }
                Console.WriteLine("The computer is finished. It has {0} cards on its hands", count);
                One.DisplayCard(Players.Player);//Turn Players
                Console.WriteLine("Will you take one more card?");
                Console.WriteLine("\n");
                Console.WriteLine("Press 'Y' to take");
                Console.WriteLine("or any key to finish.....");
                while (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.Clear();
                    One.Take(Players.Player);
                    One.DisplayCard(Players.Player);
                    Console.WriteLine("Will you take one more card?");
                    Console.WriteLine("\n");
                    Console.WriteLine("Press 'Y' to take");
                    Console.WriteLine("or any key to finish.....");

                }
                One.PrintWin(One.ScorePlayers(Players.Player), One.ScorePlayers(Players.Computer));
            }
        }
        // Print statistics
        Console.Clear();
        Console.WriteLine("№ of games:{0}. Players {1} - {2} Computer", Game.CountGame, Game.GameScorePl, Game.GameScoreComp);
        if (userKey == Players.Computer) userKey = Players.Player;
        else userKey = Players.Computer;
        Console.WriteLine("Will you continue?");
        Console.WriteLine("\n");
        Console.WriteLine("Press 'Enter' to continue");
        Console.WriteLine("or any key to finish.....");
        if (Console.ReadKey().Key == ConsoleKey.Enter) goto Start;
        else
        {
            Console.Clear();
            Console.WriteLine("Thank you! Bye-bye!");
            Thread.Sleep(pause+300);
        }


    }
}

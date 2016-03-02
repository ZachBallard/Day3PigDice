using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3PigDice
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Exit = false;


            int numOfPlayers = 0;
            int aiStyle = 0;
            int whoFirst = 0;
            var playerValue = new[] { 0, 0, 0, 0 };
            var playerNames = new[] { "", "", "", "" };

            bool isComputerPlaying = false;
            bool isBanking = false;

            while (Exit == false)
            {
                //Welcome
                Welcome();
                //select 1-4 player
                numOfPlayers = getNumPlayers();
                //select dumb average careful smart AI
                if (numOfPlayers == 1)
                {
                    isComputerPlaying = true;
                    numOfPlayers = 2;
                    aiStyle = getAIStyle();
                }
                //what are the players names?
                if (isComputerPlaying == false)
                {
                    for (int i = 0; i < numOfPlayers; i++)
                    {

                        playerNames[i] = getPlayerName(i);
                    }
                }
                else
                {
                    playerNames[0] = getPlayerName(1);
                    playerNames[1] = "Computer";
                }

                //See who goes first - roll die and compair for higher
                whoFirst = getOrderResults(numOfPlayers, ref playerValue);

                for (int i = 0; i < numOfPlayers; i++)
                {
                    Console.WriteLine($"{playerNames[i]} got a {playerValue[i]}");
                }

                Console.WriteLine($"\n{playerNames[whoFirst]} will go first!");

                bool isGameOver = false;

                while (isGameOver == false)
                {

                    while (true)
                    {
                        
                        //display roll
                        //check if current has 100
                        //check if roll was 1
                        //would you like to bank or roll?
                    }

                    //change player
                }
            }
        }
        private static void Welcome()
        {
            Console.WriteLine(@"                                         _          _           ");
            Console.WriteLine(@" \    / _  |  _  _  ._ _   _   _|_  _   |_) o  _   | \ o  _  _  ");
            Console.WriteLine(@"  \/\/ (/_ | (_ (_) | | | (/_   |_ (_)  |   | (_|  |_/ | (_ (/_ ");
            Console.WriteLine(@"            __              _                  _|               ");
            Console.WriteLine(@" __ |_       /  _.  _ |_   |_)  _. | |  _. ._ _|   The Iron Yard");
            Console.WriteLine(@"    |_) \/  /_ (_| (_ | |  |_) (_| | | (_| | (_|    (3/2/2016)  ");
            Console.WriteLine(@"        /                                            ^^^^^^^^   ");
            Console.WriteLine(@"################################################################");
        }

        private static int getNumPlayers()
        {
            string userInput = "";

            while (true)
            {
                Console.WriteLine("\nHow many players will there be?");
                Console.WriteLine("(1) vs Computer (2) Player (3) Player (4) Player");
                userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    return 1;
                }
                else if (userInput == "2")
                {
                    return 2;
                }
                else if (userInput == "3")
                {
                    return 3;
                }
                else if (userInput == "4")
                {
                    return 4;
                }
                else
                {
                    Console.WriteLine("\nThat wasn't a valid selection. Try again.");
                }
            }

        }

        private static int getAIStyle()
        {
            string userInput = "";

            while (true)
            {
                Console.WriteLine("\nWould sort of AI would you like to play against?");
                Console.WriteLine("(r)andom (t)ypical (c)areful (w)ise");
                userInput = Console.ReadLine();

                if (userInput == "r")
                {
                    return 1;
                }
                else if (userInput == "t")
                {
                    return 2;
                }
                else if (userInput == "c")
                {
                    return 3;
                }
                else if (userInput == "w")
                {
                    return 4;
                }
                else
                {
                    Console.WriteLine("\nThat wasn't a valid selection. Try again.");
                }
            }
        }

        private static string getPlayerName(int whichPlayer)
        {
            string userInput = "";

            Console.WriteLine($"\nPlayer {whichPlayer}, what should we call you?");
            userInput = Console.ReadLine();
            return userInput;
        }

        private static bool bankOrRoll()
        {
            string userInput = "";

            while (true)
            {
                Console.WriteLine("\nWould you like to (b)ank your points or (r)oll again?");
                userInput = Console.ReadLine();

                if (userInput == "b")
                {
                    return true;
                }
                else if (userInput == "r")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("\nThat wasn't a valid selection. Try again.");
                }
            }
        }

        private static int getOrderResults(int numOfPlayers, ref int[] playerValue)
        {
            int whoFirst = 0;

            while (true)
            {
                for (int i = 0; i < numOfPlayers; i++)
                {
                    playerValue[i] = rollDie();
                }

                for (int i = 0; i < numOfPlayers; i++)
                {
                    for (int j = i + 1; j < numOfPlayers; j++)
                    {
                        if (playerValue[j] == playerValue[i])
                        {
                            while (playerValue[j] == playerValue[i])
                            {
                                playerValue[j] = rollDie();
                                playerValue[i] = rollDie();
                            }
                        }

                        if (playerValue[j] > playerValue[i])
                        {
                            whoFirst = j;
                        }
                        else
                        {
                            whoFirst = i;
                        }
                    }

                    return whoFirst;
                }
            }
        }

        private static int rollDie()
        {
            int result = 0;
            Random random = new Random();

            result = random.Next(1, 6);
            return result;
        }
    }
}

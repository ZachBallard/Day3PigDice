using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3PigDice
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            bool Exit = false;


            int numOfPlayers = 0;
            int aiStyle = 0;
            int whoFirst = 0;
            var playerValue = new[] { 0, 0, 0, 0 };
            var playerNames = new[] { "", "", "", "" };

            bool isComputerPlaying = false;

            while (Exit == false)
            {
                Welcome();

                //get number of players
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
                    playerNames[0] = getPlayerName(0);
                    playerNames[1] = "Computer";
                }

                Console.Clear();

                Console.WriteLine("\nLet's see who goes first!");
                whoFirst = getOrderResults(numOfPlayers, ref playerValue);

                for (int i = 0; i < numOfPlayers; i++)
                {
                    displayDieGraphics(playerValue[i]);
                    Console.WriteLine($"\n{playerNames[i]} got a {playerValue[i]}");
                }

                Console.WriteLine($"\n{playerNames[whoFirst]} will go first!");
                Console.WriteLine("--> Type anything to continue <--");
                Console.ReadLine();

                resetPlayerValues(ref playerValue);

                gamePlay(whoFirst, numOfPlayers, playerNames, playerValue);
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

                switch (userInput)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        return int.Parse(userInput);
                    default:
                        Console.WriteLine("\nThat wasn't a valid selection. Try again.");
                        break;
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

            //give all players a value
            for (int i = 0; i < numOfPlayers; i++)
            {
                playerValue[i] = rollDie();
            }

            for (int i = 0; i < numOfPlayers; i++)
            {
                while (playerValue[i] == playerValue[i++])
                {
                    playerValue[i++] = rollDie();
                    playerValue[i] = rollDie();
                }
                if (playerValue[i] > playerValue[i++])
                {
                    whoFirst = i;
                }
                else
                {
                    whoFirst = i++;
                }
            }

            return whoFirst;
        }

        private static int rollDie()
        {
            int result = 0;

            result = random.Next(1, 6);
            return result;
        }

        private static int nextPlayer(int currentPlayer, int numOfPlayers)
        {
            if (currentPlayer++ < numOfPlayers)
            {
                return currentPlayer++;
            }
            else
            {
                return 0;
            }
        }

        private static bool bankOrRollAI()
        {
            //unfinished ai choices
            return true;
        }

        private static void resetPlayerValues(ref int[] playerValue)
        {
            for (int i = 0; i < 4; i++)
            {
                playerValue[i] = 0;
            }
        }

        private static void displayDieGraphics(int currentRoll)
        {
            /* Console.WriteLine();
             Console.WriteLine(@" _________ ");
             Console.WriteLine(@"|         |");

             switch (currentRoll)
             {
                 case 1:
                     Console.WriteLine(@"|         |");
                     Console.WriteLine(@"|    0    |");
                     Console.WriteLine(@"|         |");
                     break;

             }

             Console.WriteLine(@"|_________|");
             */
            if (currentRoll == 1)
            {
                Console.WriteLine();
                Console.WriteLine(@" _________ ");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|    0    |");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|_________|");
            }
            else if (currentRoll == 2)
            {
                Console.WriteLine();
                Console.WriteLine(@" _________ ");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|  0   0  |");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|_________|");
            }
            else if (currentRoll == 3)
            {
                Console.WriteLine();
                Console.WriteLine(@" _________ ");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|    0    |");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|  0   0  |");
                Console.WriteLine(@"|_________|");
            }
            else if (currentRoll == 4)
            {
                Console.WriteLine();
                Console.WriteLine(@" _________ ");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|  0   0  |");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|  0   0  |");
                Console.WriteLine(@"|_________|");
            }
            else if (currentRoll == 5)
            {
                Console.WriteLine();
                Console.WriteLine(@" _________ ");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|  0   0  |");
                Console.WriteLine(@"|    0    |");
                Console.WriteLine(@"|  0   0  |");
                Console.WriteLine(@"|_________|");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(@" _________ ");
                Console.WriteLine(@"|         |");
                Console.WriteLine(@"|  0   0  |");
                Console.WriteLine(@"|  0   0  |");
                Console.WriteLine(@"|  0   0  |");
                Console.WriteLine(@"|_________|");
            }
        }

        private static void gamePlay(int whoFirst, int numOfPlayers, string[] playerNames, int[] playerValue)
        {
            bool isGameOver = false;
            int currentPlayer = whoFirst;
            bool isBanking = false;

            while (isGameOver == false)
            {
                int currentRoll = 0;
                int currentPot = 0;

                Console.Clear();

                while (isBanking == false)
                {
                    Console.Clear();
                    Console.WriteLine();

                    for (int i = 0; i < numOfPlayers; i++)
                    {
                        Console.WriteLine($"{playerNames[i]} has got {playerValue[i]} points");
                    }

                    Console.WriteLine($"\nIt's {playerNames[currentPlayer]}'s turn!");

                    currentRoll = rollDie();

                    displayDieGraphics(currentRoll);

                    currentPot = currentPot + currentRoll;

                    //check if 1
                    if (currentRoll == 1)
                    {
                        Console.WriteLine($"\n{playerNames[currentPlayer]} you have rolled a 1 and lost your turn!");
                        Console.WriteLine("--> Type anything to continue <--");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\n{playerNames[currentPlayer]} you have {currentPot} on the line!");
                    }

                    //check if 100
                    if (playerValue[currentPlayer] == 100)
                    {
                        Console.Clear();
                        Console.WriteLine($"\n{playerNames[currentPlayer]} is the winner!");
                        break;
                    }

                    if (playerNames[currentPlayer] != "Computer")
                    {
                        isBanking = bankOrRoll();
                    }
                    else
                    {
                        isBanking = bankOrRollAI();
                    }

                    if (isBanking == true)
                    {
                        playerValue[currentPlayer] = playerValue[currentPlayer] + currentPot;
                    }
                }

                isBanking = false;
                currentPlayer = nextPlayer(currentPlayer, numOfPlayers);
            }
        }

    }
}

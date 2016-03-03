﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3PigDice
{
    class Program
    {
        static Random random = new Random();
        static bool Exit = false;

        static void Main(string[] args)
        {
            int numOfPlayers = 0;
            int aiStyle = 0;
            int whoFirst = 0;
            var playerValue = new[] { 0, 0, 0, 0 };
            var playerNames = new[] { "", "", "", "" };

            bool isComputerPlaying = false;

            while (Exit == false)
            {
                Console.Clear();
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

                Console.WriteLine("\nLet's see who goes first!\nWe roll until we get a player's number...");

                whoFirst = getOrderResults(numOfPlayers);

                displayDieGraphics(whoFirst + 1);

                Console.WriteLine($"\n{playerNames[whoFirst]} will go first!");
                Console.WriteLine("--> Type anything to continue <--");
                Console.ReadLine();

                gamePlay(whoFirst, numOfPlayers, playerNames, playerValue, aiStyle);
            }
        }
        private static void Welcome()
        {
            Console.WriteLine(@"                                          _          _          ");
            Console.WriteLine(@"| |  |  _  ||  _  _   _ _   _   _|_  _   |_) 0  _   | \ 0  _  _ ");
            Console.WriteLine(@"\_/\_/ (/_ || (_ (_) | | | (|_   |  (_)  |   | (_|  |_/ | (_ (|_");
            Console.WriteLine(@"            ___              _                  _|              ");
            Console.WriteLine(@" __ |_       //  _   _ |_   |_)  _  | |  _   _ _|  The Iron Yard");
            Console.WriteLine(@" __ |_| \/  //_ (_| (_ | |  |_) (_| | | (_| | (_|   (3/2/2016)  ");
            Console.WriteLine(@"       _/                                            ^^^^^^^^   ");
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

        private static int getOrderResults(int numOfPlayers)
        {
            return random.Next(0, (numOfPlayers - 1));
        }

        private static int rollDie()
        {
            int result = 0;

            result = random.Next(1, 6);
            return result;
        }

        private static int nextPlayer(int currentPlayer, int numOfPlayers)
        {
            if ((currentPlayer + 1) < numOfPlayers)
            {
                return currentPlayer + 1;
            }
            else
            {
                return 0;
            }
        }

        private static bool bankOrRollAI(int aiStyle, int[] playerValue, int currentPot)
        {
            switch (aiStyle)
            {
                case 4:
                    if (currentPot + playerValue[1] >= 100)
                    {
                        return true;
                    }
                    if (currentPot >= 16 && playerValue[0] <= 90)
                    {
                        return true;
                    }
                    if (currentPot + playerValue[1] >= playerValue[0] && playerValue[1] <= 80)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case 3:
                    return true;
                case 2:
                    if (currentPot + playerValue[1] >= 100)
                    {
                        return true;
                    }
                    if (currentPot <= 12 && playerValue[0] <= 90)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    if (currentPot + playerValue[1] >= 100)
                    {
                        return true;
                    }
                    int willBank = random.Next(0, 1);
                    if (willBank == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        private static void gamePlay(int whoFirst, int numOfPlayers, string[] playerNames, int[] playerValue, int aiStyle)
        {
            int currentPlayer = whoFirst;
            bool isBanking = false;

            while (true)
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

                    if (playerNames[currentPlayer] != "Computer")
                    {
                        isBanking = bankOrRoll();
                    }
                    else
                    {
                        isBanking = bankOrRollAI(aiStyle, playerValue, currentPot);
                    }

                    if (isBanking == true)
                    {
                        playerValue[currentPlayer] = playerValue[currentPlayer] + currentPot;
                    }
                }

                //check if 100
                if (playerValue[currentPlayer] >= 100)
                {
                    Console.Clear();
                    if (playerNames[currentPlayer] != "Computer")
                    {
                        Console.WriteLine(@" _      _   _                                 |0| ");
                        Console.WriteLine(@"|0|    |0| |0|                                |0| ");
                        Console.WriteLine(@"|0| /\ |0|  _   ____     ____     ___   ____  |0| ");
                        Console.WriteLine(@"\0 \||/ 0/ |0| |0 __0\  |0 __0\  / 0_| |0 _0|  _  ");
                        Console.WriteLine(@" \0/  \0/  |0| |0|  |0| |0|  |0| |/___ |0|    |0| ");
                        Console.WriteLine("################################################  ");
                    }
                    else
                    {
                        Console.WriteLine($"Better luck next time...");
                    }
                    Console.WriteLine($"\n{playerNames[currentPlayer]} is the winner!");

                    Console.WriteLine("--> Type anything to continue <--");
                    Console.ReadLine();
                    Exit = willExit();
                    break;
                }

                //Pause screen if computer on select
                if (playerNames[currentPlayer] == "Computer" && isBanking == true)
                {
                    Console.WriteLine("\nThe Computer thinks it is better to bank now...");
                    Console.WriteLine("--> Type anything to continue <--");
                    Console.ReadLine();

                }
                if (playerNames[currentPlayer] == "Computer" && isBanking == false)
                {
                    Console.WriteLine("\nThe Computer is going to risk a roll...");
                    Console.WriteLine("--> Type anything to continue <--");
                    Console.ReadLine();
                }
                isBanking = false;
                currentPlayer = nextPlayer(currentPlayer, numOfPlayers);
            }
        }

        private static bool willExit()
        {
            string userInput = "";

            while (true)
            {
                Console.WriteLine("\nWould you like to play again? (y)es or (n)o");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "y":
                        return false;
                    case "n":
                        return true;
                    default:
                        Console.WriteLine("\nThat wasn't a valid selection. Try again.");
                        break;
                }
            }
        }
    }
}

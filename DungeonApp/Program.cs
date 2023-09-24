using System;
using DungeonLibrary;

namespace Dungeon_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Title and intro
            TitleScreen();

            #region Character Selection
            //Create a character object
            //Prompt user for character name   



            //Prompt user to a hero name
            //Prompt user to select a class


            #endregion


            #region Player Menu

            //Game loop:
            bool exit = false;

            do
            {
                bool reload = false;
                do
                {
                    //Prompt the user:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nPlease choose an action:\n" +
                                   "A) Attack\n" +
                                   "R) Run away\n" +
                                   "P) Player Info\n" +
                                   "M) Monster Info\n" +
                                   "X) Exit\n"
                                   );
                    //Capture user's menu selection
                    Console.ResetColor();
                    string menuSelection = Console.ReadKey(true).Key.ToString();//Executes upon input without user hitting enter.
                    Console.Clear();
                    switch (menuSelection)
                    {
                        case "A":
                            Console.WriteLine("Combat!");


                            break;
                        case "R":
                            Console.WriteLine("Run Away!");

                            break;
                        case "P":
                            Console.WriteLine("Player Info");
                            break;
                        case "M":
                            Console.WriteLine("Monster Info");
                            break;
                        case "E":
                        case "X":
                            Console.WriteLine("Until Next Time!");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");

                            break;


                    }
                } while (!reload && !exit);

            } while (!exit);
            #endregion
            //TODO Prompt player for hero name    


            //TODO create a menu for a player
            //Would like the player to select a class.
            //Would like the class to dispaly buffs
            //Would like the player to choose a dungeon map

            //Once the player selects name, class, and dungeon map
            //TODO Create a loop that allows the game to continue until the user exits

            //TODO create a class libraray to hold class types
            //TODO create an abstract parent class. This will define the blueprint for building a player and monster

            //TODO Instantiate a player object in the game

            //TODO Create a method that generates a new setting of the player in case they want to run or leave the dungone

            //TODO Build an instance of a challenger in each new setting

            //TODO Create a menu  of options for the player that runs code based on their selection. Use recursion to continue to provide the player the menu while they are in each room

            //TODO Create methods to house the functionality for executing a challenge/battle seuence. The methods should employ logic to determine the winner of the battle. Information about the outcome of the challenge/battle to the player

            //TODO Keep track of a player's score and display that information to them during the game when a player views their character information and at the end of the game.

            //TODO Create a class library project that will store custom classes that are blueprint for creating different types of challenges/challengers (i.e. monsters.)

            //TODO Customize your dungon app by including extra pieces of functionaity. Need to make 5 unique customizations at a min

            //TODO Write at least 5 unit tests for methods in your application

            //TODO Ensure all code is pushed to the GitHub repository

            //TODO Link to the project from your personal site via one of the following methods: Link to repo and embed a video of the game play.



        }

        //TitleScreen() method to prompt the user with the intro to the game.
        public static void TitleScreen()
        {
            Console.WriteLine(@"

                MMMMMO' ...,oXMMMMMMMMMMMMMMXo,... 'OMMMMM
                MMMMMK,      ;OWMMMMMMMMMMWO;      ,KMMMMM
                MMMMMN:   .'  .c0WMMMMMMW0c.  '.   :NMMMMM
                MMMMMWk'  .;:'  .oKMMMMKo.  ':;.  'kWMMMMM
                MMMMMMMXd,  .;:'  'kX0d'  ':;.  ,dXMMMMMMM
                MMMMMMMMMNx;. .;:;;c,.  ':;. .;kNMMMMMMMMM
                MMMMMMMMMMMNO:..:d;. .':;. .:ONMMMMMMMMMMM
                MMMMMMMMMMMMMW0o;. ':c;. .cOWMMMMMMMMMMMMM
                MMMMMMMWKXWMMXo. ':;.  .cc;oXMMWKKWMMMMMMM
                MMMMMMXl..;oko'':;. ':::c:''oko;..lXMMMMMM
                MMMMMWKo'    'cd;.;xXNO;.;dc'.   'oKWMMMMM
                MMMNOdxO0o'    ,oONMMMMNOo,    'o0OxdONMMM
                MMNdoKNO:';:'   'OWMMMMWO'   ':;':ONKodNMM
                MM0d00:.  .xKx,  :XMMMMX:  ,xKx.  .:00d0MM
                M0oclc,..lKWMMXxdKWMMMMWKdxXMMWKl..,clco0M
                M.    :kKWMMMMMMMMMMMMMMMMMMMMMMWKk:    .M
                M     :XMMMMMMMMMMMMMMMMMMMMMMMMMMX:     M
                Ml.  ,OWMMMMMMMMMMMMMMMMMMMMMMMMMMWO,  .lM
                ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
                ************ DUNGEON HEROES **************
                ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
                -------- Press Any Key to Continue -------
                ");
            Console.ResetColor();



            Console.ReadLine();

        }

    }
}
﻿using System;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Linq;
using DungeonLibrary;

namespace Dungeon_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string characterName;
            //Default character stats
            int hitChance = 10;
            int block = 30;
            int maxLife = 75;
            int initiative = 5;
            int characterLevel = 1;
            int characterExp = 0;

          
            //Title and intro
            TitleScreen();

            #region Character Selection


            //Prompt user for character name   
            Console.Write("Name your Character: ");
            characterName = Console.ReadLine();           


            #endregion
            #region Race Selection
            bool validSelection = false;
            int userChoice;

            do
            {
                Console.WriteLine("Choose your race: ");
                Console.WriteLine(
                    $"1): Human\n" +
                    $"2) Elf\n" +
                    $"3) Dwarf\n" +
                    $"4) Gnome\n"
                    );

                int.TryParse(Console.ReadLine(), out userChoice);
                if (userChoice > 0 && userChoice < 5)
                {
                    Race selectedRace = (Race)userChoice;                    
                    validSelection = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice.");
                }

            } while (!validSelection);


            //Clear Console
            Console.Clear();
            #endregion

            //Prompt user with starting character info
            
            Console.WriteLine();
            Player player = new Player(characterName, hitChance, block, maxLife, (Race)userChoice, initiative, characterLevel, characterExp);
            Console.WriteLine(player);

            #region Player Menu

            //Game loop:

            //Check for initiative
            bool isInitiativeSet = false;
            int playerInitiative;
            int monsterInitiative;
            //Check for monster spawn
            bool isMonsterSpawned = false;
            //Allows player to exit
            bool exit = false;
            //Using the default Monster() a generatedMonster of type Monster will be initialize
            Monster generatedMonster = new Monster();
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
                            if (!isInitiativeSet && isMonsterSpawned)
                            {
                                //roll a random number
                                Random rand = new Random();
                                Random rand2 = new Random();
                                //Initializes monster initiative
                                generatedMonster.Initiative = rand2.Next(1,21);
                                //Initializes player initiative
                                player.Initiative = rand.Next(1,21);
                                //Set to true to keep player from rerolling
                                isInitiativeSet=true;
                            }


                            if (isInitiativeSet)
                            {
                                Console.WriteLine("Combat! " + $"{player.Name} Initiative is: {player.Initiative}" + $" {generatedMonster.Name} Initiative is {generatedMonster.Initiative}");
                                Combat.DoAttack(player, generatedMonster, player.Initiative, generatedMonster.Initiative);
                            }
                            else
                            {
                                Console.WriteLine("There is no monster spawned yet!");
                            }

                            break;
                        case "R":
                            //TODO need to add damaage from foe and a despawn
                            //Reset initiative
                            isInitiativeSet = false;
                            Console.WriteLine("You run!");
                            //Allows a new Monster to Generate
                            isMonsterSpawned = false;

                            break;
                        case "P":
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            break;
                        case "M":
                            
                            if (!isMonsterSpawned)
                            {

                                 Monster generateMonster = GenerateMonster(hitChance, block, maxLife,        initiative, characterLevel, characterExp);
                                generatedMonster = generateMonster;
                                Console.WriteLine($"{generatedMonster}\nThe Enemy has Spawned!");
                                isMonsterSpawned = true;

                            }
                            else 
                            {
                               Console.WriteLine($"{generatedMonster}");

                               Console.WriteLine($"Must defeat your current foe before fighting another."); 
                             }
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
            
            //**Would like the class to dispaly buffs
            //**Would like the player to choose a dungeon map
            
            //TODO Create a loop that allows the game to continue until the user exits                
                      

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

        //Generates random monster
        public static Monster GenerateMonster(int hitChance,int block, int maxLife, int initiative, int characterLevel, int characterExp)
        {
            // Monster monster = getRandomMonster();
            List<string> monsterName = new List<string>
                                {
                                    "Arkoth",
                                    "Brondar",
                                    "Crixus",
                                    "Drakar",
                                    "Evox",
                                    "Faelar",
                                    "Gorthok",
                                    "Harkon",
                                    "Ithril",
                                    "Jarkus",
                                    "Kornar",
                                    "Lorthos",
                                    "Morthak",
                                    "Norix",
                                    "Orthar",
                                    "Praxus",
                                    "Quoril",
                                    "Raxus",
                                    "Sorloth",
                                    "Trakar",
                                    "Uxar",
                                    "Vortar",
                                    "Warlox",
                                    "Xaros",
                                    "Yrthak",
                                    "Zorath",
                                    "Aerix",
                                    "Borak",
                                    "Cronar",
                                    "Dorthos",
                                    "Eryth",
                                    "Falkor",
                                    "Groth",
                                    "Hyrak",
                                    "Indar",
                                    "Joril",
                                    "Karn",
                                    "Lorax",
                                    "Moros",
                                    "Nyrak",
                                    "Orox",
                                    "Pyrak",
                                    "Qyrix",
                                    "Ronar",
                                    "Styrix",
                                    "Tharok",
                                    "Urth",
                                    "Varix",
                                    "Wroth",
                                    "Xyril"
                                };

            int monsterRace;
             
            Random random = new Random();
            //Select random number for the race
            monsterRace = random.Next(5, 12);
            Race monsterSelectedRace = (Race)monsterRace;

            //Generate random monster name
            Random rand = new Random();
            int i = rand.Next(50);
            string name = monsterName[i];

            Monster monster = new Monster(name, hitChance, block, maxLife, monsterSelectedRace, initiative, characterLevel, characterExp);

            return monster;
        }
            
        

    }
}
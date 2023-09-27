using DungeonLibrary;
using System.CodeDom.Compiler;
using System.Numerics;
using System.Threading;
using System.Xml.Linq;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            #region Title/Introduction
            TitleScreen();
            #endregion

            #region Player Creation
            //Prompt user for character name   
            Console.Write("Name your Character: ");
            string characterName = Console.ReadLine();


            bool validSelection = false;
            int userChoice;         
            //Loop for player Race selection
            do
            {
                Console.WriteLine("Choose your race: ");
                Console.WriteLine(
                    $"1) Human\n" +
                    $"2) Elf\n" +
                    $"3) Dwarf\n" +
                    $"4) Gnome\n"
                    );
                //User picks and the value is stored in the userChoice variable
                int.TryParse(Console.ReadLine(), out userChoice);
                if (userChoice > 0 && userChoice < 5)
                {                                      
                    validSelection = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice.");
                }

            } while (!validSelection); //end of menu

            //Clear Console
            Console.Clear();

            bool isWeaponSelected = false;
            int selector;

            //Generate a blank player object for customization
            Player player = new Player();
            //Loop for player Race selection
            do
            {

                string name = "";
                int minDamage = 0;
                int maxDamage = 0;
                int bonusHitChance = 0;
                bool isTwoHanded = false;


                Console.WriteLine("Choose your weapon: ");
                Console.WriteLine(
                        $"1) Axe\n" +
                        $"2) Bow\n" +
                        $"3) Dagger\n" +
                        $"4) Hammer\n" +
                        $"5) Mace\n" +
                        $"6) Staff\n" +
                        $"7) Sword\n"
                    );

                //Capture user's menu selection
                string menuSelection = Console.ReadKey(true).Key.ToString();//Executes upon input
                switch(menuSelection)
                {
                    case "D1":
                        
                        Weapon weapon = new Weapon(name, minDamage, maxDamage, bonusHitChance, isTwoHanded,     WeaponType.Axe);
                        Player customPlayer = new(characterName, 70, 5, 40, (Race)userChoice, weapon);
                        player = customPlayer;
                        isWeaponSelected = true;
                        break;

                    case "D2":

                        Weapon weapon2 = new Weapon(name, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Bow);
                        Player customPlayer2 = new(characterName, 70, 5, 40, (Race)userChoice, weapon2);
                        player = customPlayer2;
                        isWeaponSelected = true;
                        break;

                    case "D3":

                        Weapon weapon3 = new Weapon(name, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Dagger);
                        Player customPlayer3 = new(characterName, 70, 5, 40, (Race)userChoice, weapon3);
                        player = customPlayer3;
                        isWeaponSelected = true;
                        break;

                    case "D4":

                        Weapon weapon4 = new Weapon(name, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Hammer);
                        Player customPlayer4 = new(characterName, 70, 5, 40, (Race)userChoice, weapon4);
                        player = customPlayer4;
                        isWeaponSelected = true;
                        break;

                    case "D5":

                        Weapon weapon5 = new Weapon(name, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Mace);
                        Player customPlayer5 = new(characterName, 70, 5, 40, (Race)userChoice, weapon5);
                        player = customPlayer5;
                        isWeaponSelected = true;
                        break;
                    case "D6":

                        Weapon weapon6 = new Weapon(name, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Staff);
                        Player customPlayer6 = new(characterName, 70, 5, 40, (Race)userChoice, weapon6);
                        player = customPlayer6;
                        isWeaponSelected = true;
                        break;

                    case "D7":

                        Weapon weapon7 = new Weapon(name, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Sword);
                        Player customPlayer7 = new(characterName, 70, 5, 40, (Race)userChoice, weapon7);
                        player = customPlayer7;
                        isWeaponSelected = true;
                        break;
                }

            } while (!isWeaponSelected);           


                    
            #endregion

            //Game loop:
            bool exit = false;
            do
            {
                //generate a room
                string room = GetRoom();
                Console.WriteLine(room);
                //generate a monster in the room
                Monster monster = Monster.GetMonster();
                Console.Write("\nIn this room: ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(monster.Name);
                Console.ResetColor();
                //Encounter loop:
                bool reload = false;//reload = true to "reload" a room and a monster
                do
                {
                    #region Menu
                    //prompt the user:
                    Console.Write("\nPlease choose an action:\n" +
                                  "A) Attack\n" +
                                  "R) Run away\n" +
                                  "P) Player Info\n" +
                                  "M) Monster Info\n" +
                                  "X) Exit\n");
                    //Capture user's menu selection
                    string menuSelection = Console.ReadKey(true).Key.ToString();//Executes upon input without hitting enter
                    //Clear the console AFTER user input
                    Console.Clear();

                    //using branching logic to act upon the user's menu selection
                    switch (menuSelection)
                    {
                        case "A":
                            Console.WriteLine("Combat!");
                            //if the monster is dead, DoBattle returns true and reloads the room.
                            reload = Combat.DoBattle(player, monster);
                            break;

                        case "R":
                            Console.WriteLine("Run Away!");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;

                        case "P":
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            break;

                        case "M":
                            Console.WriteLine("Monster Info");
                            Console.WriteLine(monster);
                            break;

                        case "X":
                        case "E":
                            Console.WriteLine("No one likes a quitter...");
                            //exit both loops
                            exit = true;
                            break;
                        default:
                            //invalid input.
                            Console.WriteLine("You have chosen poorly...");
                            break;
                    }//end switch
                    #endregion

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Your soul is mine...\a");

                        exit = true;//leave both loops.
                    }
                } while (!reload && !exit);
                //if exit = true, both loops will terminate.
                //If reload = true, only the inner loop will terminate.

            } while (!exit); //exit == false
            Console.WriteLine($"You have defeated {player.Score} monster{(player.Score == 1 ? "." : "s.")}");
        }//end Main()
        //Custom method called GetRoom()
        private static string GetRoom()
        {
            //String array of room descriptions         
            //build an array:

            string[] rooms =
            {
                "The walls are adorned with portraits of fearsome dragons, while a stuffed unicorn head hangs above the fireplace.",
                "An enormous crystal chandelier hangs from the ceiling, casting a rainbow of colors across the room.",
                "A giant mushroom serves as the centerpiece of the room, surrounded by whimsical fairy lights.",
                "The floor is covered in a thick layer of soft, green moss, making it feel like you're walking on a forest floor.",
                "A bookshelf filled with magical tomes lines one wall, while a cauldron bubbles away in the corner.",
                "A suit of armor stands guard at the entrance, but it seems to be nodding off on the job.",
                "A large stone fireplace dominates the room, but instead of wood, it's filled with shimmering gold coins.",
                "A giant spiderweb stretches across the ceiling, with a creepy-crawly arachnid lurking nearby.",
                "A bed shaped like a giant clamshell takes up most of the space, complete with a fluffy pearl-white comforter.",
                "A gargoyle perched on the windowsill keeps watch over the room, occasionally shooting a jet of water out of its mouth."
            };

            //Build a Random
            Random rand = new Random();

            //select a random number from 0 to the last index of rooms.
            int randIndex = rand.Next(rooms.Length);

            //retrieve the value of that index into a string variable
            string room = rooms[randIndex];

            //return that room to the Main()
            return room;
            //Refactoring means rewriting code to be more concise, readable, or performant:
            //return rooms[new Random().Next(rooms.Length)];

        }//end GetRoom()

     
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

        }//end TitleScreen()               

    }//end class
}//end namespace
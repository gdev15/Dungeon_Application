using DungeonLibrary;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Threading;
using System.Xml.Linq;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int emptyValue;

            #region Title/Introduction
            TitleScreen();
            #endregion

            

            #region Player Creation
            //Prompt user for character name   
            Console.Write("\n\tName your Character: ");
            string characterName = Console.ReadLine();

            //Adding Recursion method
            int counter = 0;

            Console.WriteLine(); //Spacing
            Console.Write("\t");
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect(characterName, counter);
           

            bool validSelection = false;
            int userChoice = 0;         
            //Loop for player Race selection
            do
            {

                TypingEffect(" choose your race: ", counter);
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(
                    $"\t1) Human\n" +
                    $"\t2) Elf\n" +
                    $"\t3) Dwarf\n" +
                    $"\t4) Gnome\n"
                    );

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // The 'true' argument suppresses the key from being displayed in the console

                //Digits only
                if (char.IsDigit(keyInfo.KeyChar))
                {

                    userChoice = int.Parse(keyInfo.KeyChar.ToString());
                    #region Prompts Selected Race
                    if (userChoice == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\tHuman\n");
                        Console.ResetColor();
                        validSelection = true;
                    }
                    if (userChoice == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\tElf\n");
                        Console.ResetColor();
                        validSelection = true;
                    }
                    if (userChoice == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\tDwarf\n");
                        Console.ResetColor();
                        validSelection = true;
                    }
                    if (userChoice == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\tGnome\n");
                        Console.ResetColor();
                        validSelection = true;
                    }
                    #endregion

                 
                }
                else
                {
                    Console.WriteLine("Invalid input. Please press a number key.");
                    
                }

            } while (!validSelection); //end of menu

            //Clear Console

            #region Weapon Selection and Instantiate Player Object
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
                string weaponName = WeaponNameGenerator(); //Generates a random weapon name

                Console.WriteLine("\tChoose your weapon: ");
                Console.WriteLine(
                        $"\t1) Axe\n" +
                        $"\t2) Bow\n" +
                        $"\t3) Dagger\n" +
                        $"\t4) Hammer\n" +
                        $"\t5) Mace\n" +
                        $"\t6) Staff\n" +
                        $"\t7) Sword\n"
                    );

                //Capture user's menu selection
                string menuSelection = Console.ReadKey(true).Key.ToString();//Executes upon input
                switch(menuSelection)
                {
                    case "D1":
                        minDamage = 2;
                        maxDamage = 8;
                        
                        Weapon weapon = new Weapon(weaponName, minDamage, maxDamage, bonusHitChance, isTwoHanded,     WeaponType.Axe);
                        Player customPlayer = new(characterName, 70, 5, 40, 0, (Race)userChoice, weapon, minDamage, maxDamage);
                        player = customPlayer;
                        isWeaponSelected = true;
                        break;

                    case "D2":
                        minDamage = 1;
                        maxDamage = 10;                      
                        Weapon weapon2 = new Weapon(weaponName, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Bow);
                        Player customPlayer2 = new(characterName, 70, 5, 40, 0, (Race)userChoice, weapon2, minDamage, maxDamage);
                        player = customPlayer2;
                        isWeaponSelected = true;
                        break;

                    case "D3":
                        minDamage = 3;
                        maxDamage = 5;
                        Weapon weapon3 = new Weapon(weaponName, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Dagger);
                        Player customPlayer3 = new(characterName, 70, 5, 40, 0,(Race)userChoice, weapon3, minDamage, maxDamage);
                        player = customPlayer3;
                        isWeaponSelected = true;
                        break;

                    case "D4":
                        minDamage = 2;
                        maxDamage = 12;
                        Weapon weapon4 = new Weapon(weaponName, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Hammer);
                        Player customPlayer4 = new(characterName, 70, 5, 40, 0,(Race)userChoice, weapon4, minDamage, maxDamage);
                        player = customPlayer4;
                        isWeaponSelected = true;
                        break;

                    case "D5":
                        minDamage = 2;
                        maxDamage = 10;
                        Weapon weapon5 = new Weapon(weaponName, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Mace);
                        Player customPlayer5 = new(characterName, 70, 5, 40, 0,(Race)userChoice, weapon5, minDamage, maxDamage);
                        player = customPlayer5;
                        isWeaponSelected = true;
                        break;
                    case "D6":
                        minDamage = 1;
                        maxDamage = 8;
                        Weapon weapon6 = new Weapon(weaponName, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Staff);
                        Player customPlayer6 = new(characterName, 70, 5, 40,0, (Race)userChoice, weapon6, minDamage, maxDamage);
                        player = customPlayer6;
                        isWeaponSelected = true;
                        break;

                    case "D7":
                        minDamage = 2;
                        maxDamage = 10;
                        Weapon weapon7 = new Weapon(weaponName, minDamage, maxDamage, bonusHitChance, isTwoHanded, WeaponType.Sword);
                        Player customPlayer7 = new(characterName, 70, 5, 40,0, (Race)userChoice, weapon7, minDamage, maxDamage);
                        player = customPlayer7;
                        isWeaponSelected = true;
                        break;
                }

            } while (!isWeaponSelected);

            #endregion

            #endregion

            Console.Clear(); //Clear first scene

            #region Player Spawning
            //Add the player Spanwing Here Before being able to go into a room..

            Console.WriteLine($"{player.Name} has entered the world of Zethal");

            Thread.Sleep(1000);
            LoadScreen(100);
            LoadScreen(100);







            #endregion

            Console.Clear(); //Clear second
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
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.Cyan;
        
            Thread.Sleep(100);
            Console.Write("\tW");
            Thread.Sleep(100);
            Console.Write("e");
            Thread.Sleep(100);
            Console.Write("l");
            Thread.Sleep(100);
            Console.Write("c");
            Thread.Sleep(100);
            Console.Write("o");
            Thread.Sleep(100);
            Console.Write("m");
            Thread.Sleep(100);
            Console.Write("e");

            Thread.Sleep(100);
            Console.Write(" ");
            Thread.Sleep(100);
            Console.Write("H");
            Thread.Sleep(100);
            Console.Write("e");
            Thread.Sleep(100);
            Console.Write("r");
            Thread.Sleep(100);
            Console.Write("o");
            Thread.Sleep(100);
            Console.Write("!");            
            Console.ResetColor();


        }//end TitleScreen()

        public static void RaceMenuPrompt(string characterName)
        {            
     
            Console.ResetColor();
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Here my idea is to make a recursion method or loop to go through the characters within the character name to slowling prompt it out to the user.
            Thread.Sleep(100);
            Console.Write("\tW");
            Thread.Sleep(100);
            Console.Write("e");
            Thread.Sleep(100);
            Console.Write("l");
            Thread.Sleep(100);
            Console.Write("c");
            Thread.Sleep(100);
            Console.Write("o");
            Thread.Sleep(100);
            Console.Write("m");
            Thread.Sleep(100);
            Console.Write("e");

            Thread.Sleep(100);
            Console.Write(" ");
            Thread.Sleep(100);
            Console.Write("H");
            Thread.Sleep(100);
            Console.Write("e");
            Thread.Sleep(100);
            Console.Write("r");
            Thread.Sleep(100);
            Console.Write("o");
            Thread.Sleep(100);
            Console.Write("!");
            Console.ResetColor();


        }//end TitleScreen()

        //Generate Random Weapon Name
        public static string WeaponNameGenerator()
        {
            //Array of weapon names
            string[] nameList = new string[]
            {
                "Dawnbreaker",
                "Voidtouched",
                "Tempest Whisper",
                "Rune",
                "Frostfire",
                "Mysticbane",
                "Lunar Shard",
                "Eclipsed Edge",
                "Stormcaller's",
                "Netherfang",
                "Solstice",
                "Cinderflame",
                "Spiritbond",
                "Oblivion",
                "Eagle's Talon",
                "Shadowspine",
                "Dragon's Breath",
                "Abyssal Crescent",
                "Celestial Star",
                "Inferno's Kiss",
            };

            int i = new Random().Next(0, 20);

            string nameSelected = nameList[i];
            return nameSelected;

        }//end Weapon Name Generator

        //Recursion Implementation
        public static void TypingEffect(string content, int counter)
        {
            // Base case: if counter is equal to the length of the string, return
            if (counter == content.Length) return; 

            char resultingChar = content[counter];
            Thread.Sleep(100);
            Console.Write(resultingChar);


            // Recursive call
            TypingEffect(content, counter + 1);
        }

        //LoadScreen to show visual loading where timout is the int in ms
        public static void LoadScreen(int timeOut)
        {
            Console.Write(".");
            Thread.Sleep(timeOut);
            Console.Write(".");
            Thread.Sleep(timeOut);
            Console.Write(".");
            Thread.Sleep(timeOut);
            Console.Write(".");
            Thread.Sleep(timeOut);
            Console.Write(".");
            Thread.Sleep(timeOut);
            Console.Write(".");
        }
    }//end class
}//end namespace
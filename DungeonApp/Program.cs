using DungeonLibrary;
namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Title/Introduction
            Console.WriteLine("Hello, World!");
            #endregion

            #region Player Creation
            // - possible expansion - Display a list of pre-created weapons and let them pick one.
            // - recommendation: GetWeapon() in the Weapon class that returns a Weapon.
            Weapon wep = new("Long Sword", 1, 8, 10, false, WeaponType.Sword);

            // - possible expansion: Let the player pick their own name and even their own race.
            Player player = new("Leeroy Jenkins", 70, 5, 40, Race.Elf, wep);
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
        //Custom method called GetRoom() -> Ref Magic8Ball lab.
        private static string GetRoom()
        {
            //Mini-Lab: build a string array of room descriptions
            //Return a random string from that collection.

            //build an array:
            //Collection Initialization Syntax:
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
    }//end class
}//end namespace
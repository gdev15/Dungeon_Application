using System;
using DungeonLibrary;

namespace DungeonApp
{
    internal class Test
    {
        static void Main(string[] args)
        {


            /* #region Race Selection Menu
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
                     Console.WriteLine(userChoice);
                     Race selectedRace = (Race)userChoice;
                     Console.WriteLine($"You selected: {selectedRace}");
                     validSelection = true;
                 }else
                 {
                     Console.WriteLine("Invalid Choice.");
                 }

             } while (!validSelection);

             #endregion

             Player player = new Player("Mojo", 1, 1, 1, (Race)userChoice, 1, 1, 1);

             Console.WriteLine(player);
         }*/

        }
    }
}

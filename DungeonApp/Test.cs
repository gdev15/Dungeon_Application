using System;
using DungeonLibrary;

namespace DungeonApp
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Player player = new Player("Mojo", 1, 1, 1, Race.Dwarf, 1, 1, 1);

            Console.WriteLine(player);
        }
    }
}

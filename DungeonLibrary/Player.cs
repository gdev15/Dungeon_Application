using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //Properties
        public Race PlayerRace {  get; set; }

        //Constructor with overload
        public Player(string name, int hitChance, int block, int maxLife, Race playerRace, int initiative, int characterLevel, int characterExp) : base(name, hitChance, block, maxLife, initiative, characterLevel, characterExp)
        {
            PlayerRace = playerRace;
            switch(PlayerRace)
            {
                case Race.Human:
                    break;
                case Race.Elf: 
                    break;            
                case Race.Dwarf:
                    break;
                case Race.Gnome: 
                    break;
                case Race.Troll: 
                    break;
                case Race.Orc:  
                    break;
                case Race.Goblin:
                    break;
                case Race.Demon:
                    break;
                case Race.Dragon:
                    break;
                case Race.Elemental: 
                    break;
                case Race.Undead: 
                    break;
                
            }

        }

        //Using the implementation of the override ToString() in the Character class to add the character race for the user to see
        public override string ToString()
        {
            return base.ToString() + $"Race: {PlayerRace}\n";
        }

    }

}

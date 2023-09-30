using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Demon : Monster
    {
  
        //PROPS
   
        public int InitiativeBonus {  get; set; }


        //Default CTOR
        public Demon() { }
        //CTORS        
        public Demon(string name, int hitChance, int block, int maxLife, int initiative, int minDamage, int maxDamage, string description, int initiativeBonus) : base(name, hitChance, block, maxLife, initiative, minDamage, maxDamage, description)
        {
            Random rand = new Random();
            InitiativeBonus = initiativeBonus;
            Initiative += InitiativeBonus + rand.Next(1,21);
        
        }

        public override string ToString()
        {
            return base.ToString() + $"\nInitiative Bonus: +{InitiativeBonus}";
        }

        public override int CalcInitiative()
        {
            
            return Initiative + InitiativeBonus;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Demon : Monster
    {
        int _initiative = 1;
        //PROPS
        public int Initiative { get { return _initiative; } set { _initiative = value; } }
       

        //CTORS        
        public Demon(string name, int hitChance, int block, int maxLife, int initiative, int minDamage, int maxDamage, string description, int _initiative) : base(name, hitChance, block, maxLife, initiative, minDamage, maxDamage, description)
        {
            Initiative += initiative;
        
        }

        public override string ToString()
        {
            return base.ToString() + $"\nInitiative: +{Initiative}";
        }

        public override int CalcInitiative()
        {
            return Initiative;
        }
    }
}

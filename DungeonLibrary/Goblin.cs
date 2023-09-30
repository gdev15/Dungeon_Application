using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Goblin : Monster
    {
        //PROPS
        public int HitBuff { get; set; }

        //Default constructor
        public Goblin() { }
        //CTORS        
        public Goblin(string name, int hitChance, int block, int maxLife, int initiative, int minDamage, int maxDamage, string description, int hitBuff) : base(name, hitChance, block, maxLife, initiative, minDamage, maxDamage, description)
        {       
            
            HitBuff = hitBuff;
            HitChance += HitBuff;
         
        }

        public override string ToString()
        { 
            return base.ToString() + $"\nHit Chance Bonus: +{HitBuff}%";
        }

        //Override method to Calc the Dmg buff
        public override int CalcHitChance()
        {
            int result = base.CalcHitChance() + HitBuff;
            return result;
        }

    }
}

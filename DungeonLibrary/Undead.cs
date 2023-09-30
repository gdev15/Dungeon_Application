using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Undead : Monster
    {
        //PROPS
        public int HitBuff { get; set; }

        //Default CTOR for unit testing
        public Undead() { }

        //CTORS        
        public Undead(string name, int hitChance, int block, int maxLife, int initiative, int minDamage, int maxDamage, string description, int hitBuff) : base(name, hitChance, block, maxLife, initiative, minDamage, maxDamage, description)
        {
            HitBuff = hitBuff;
            HitChance += HitBuff;
           
        }

        public override string ToString()
        {
            return base.ToString() + $"\nHit Buff Bonus: +{HitBuff}%";
        }

    
        public override int CalcHitChance()
        {
            int result = base.CalcHitChance() + HitBuff;        
            return result;
        }



    }
}


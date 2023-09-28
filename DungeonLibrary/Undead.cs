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


        //CTORS        
        public Undead(string name, int hitChance, int block, int maxLife, int initiative, int minDamage, int maxDamage, string description, int hitBuff) : base(name, hitChance, block, maxLife, initiative, minDamage, maxDamage, description)
        {
            HitBuff = hitBuff;
            HitChance += HitBuff;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nHit Chance: +{HitBuff}%";
        }

        //Override method to Calc the Dmg buff
        public override int CalcHitChance()
        {
            int result;//create the return object

            Random rand = new Random();//setup necessary resources

            result = rand.Next(MinDamage, MaxDamage);//modify the return object
             

            if (result <= 0)
            {
                Console.WriteLine("Hit Chance: +" + HitChance);
                result = 1;

            }
            return result;//return the return object
        }

    }
}


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


        //CTORS        
        public Goblin(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, int hitBuff) : base(name, hitChance, block, maxLife, maxDamage, minDamage, description)
        {
            HitBuff = hitBuff;
            HitChance += HitBuff;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }

        public override string ToString()
        { 
            return base.ToString() + $"\nHit Chance: +{HitBuff}%";
        }

        //Override method to Calc the Dmg buff
        public override int CalcHitChance()
        {            
            int result;//create the return object
            int totalHitChance;
            Random rand = new Random();//setup necessary resources

            result = rand.Next(1,21 );//modify the return object
            totalHitChance = result + HitBuff;

            if (result <= 0)
                {
                    Console.WriteLine("HitBuff is 1");
                    result = 1;

                }
            return totalHitChance;//return the return object
        }

    }
}

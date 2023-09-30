using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Dragon : Monster
    {

        //PROPS
        public int DamageBuff { get; set; }
        public int HitBuff { get; set; }


        //Default CTOR
        public Dragon() { }

        //CTORS        
        public Dragon(string name, int hitChance, int block, int maxLife, int initiative, int minDamage, int maxDamage, string description, int dmgBuff, int hitBuff) : base(name, hitChance, block, maxLife, initiative, minDamage, maxDamage, description)
        {
            DamageBuff = dmgBuff;
            MinDamage += DamageBuff;
            MaxDamage += DamageBuff;
            HitBuff = hitBuff;
            HitChance += HitBuff;
        }

        public override string ToString()
        {
            //! Update the ToString() to include your new prop
            return base.ToString() + 
                $"\nDamage: +{DamageBuff} to all Damage!" +
                $"\nHit Chance +{HitChance}";
        }

        //Override method to Calc the Dmg buff
        public override int CalcDamage()
        {
            int result = base.CalcDamage() + DamageBuff;
            if (result > MaxDamage)
            {
                Console.WriteLine("Min damage can't be more than max! Max damage stat replaced");
                result = MaxDamage;

            }
            if (result < 6)
            {
                Console.WriteLine("Dragons never do 6 damage at a min.");
                result = 6;

            }
            //Prompt to check calculation
            Console.WriteLine($"Damage Buff: +{DamageBuff}");
            Console.WriteLine($"After Mod: {result}\n");
            return result;//return the return object
        }

         public override int CalcHitChance()
         {
             int result = base.CalcHitChance();
             return result;//return the return object
         }

      
    


    }

}

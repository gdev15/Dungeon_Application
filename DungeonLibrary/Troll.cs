using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Troll : Monster
    {
                             
        //PROPS
        public int DamageBuff {  get; set; }


        //CTORS        
        public Troll(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description, int dmgBuff) : base(name, hitChance, block, maxLife, maxDamage, minDamage, description)
            {
               DamageBuff = dmgBuff;
               MaxDamage = maxDamage;
               MinDamage = minDamage + dmgBuff;
            }

            public override string ToString()
            {
                //! Update the ToString() to include your new prop
                return base.ToString() + $"\nAn empowered foe has spawned with +{DamageBuff} to min damage!";
            }

        //Override method to Calc the Dmg buff
        public override int CalcDamage()
        {
            //throw new NotImplementedException();
            int result;//create the return object
            int totalDamage;

            Random rand = new Random();//setup necessary resources          
            result = rand.Next(MinDamage, MaxDamage);//modify the return object
            totalDamage = result + DamageBuff;
            if (totalDamage > MaxDamage)
            {
                Console.WriteLine("Min damage can't be more than max! Max damage stat replaced");
                totalDamage = MaxDamage;                
             
            }
            if (totalDamage <= 0)
            {
                Console.WriteLine("Min damage has to be 1");
                totalDamage = 1;

            }
            Console.WriteLine($"After Mod: {result}+{DamageBuff}\n"+
                $"Total damage: {totalDamage}" );
            return totalDamage;//return the return object
        }


    }
    
}

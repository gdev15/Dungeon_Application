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
        public Troll(string name, int hitChance, int block, int maxLife, int initiative, int minDamage, int maxDamage, string description, int dmgBuff) : base(name, hitChance, block, maxLife, initiative, minDamage, maxDamage, description)
            {
               DamageBuff = dmgBuff;
               MinDamage += DamageBuff;
            }

            public override string ToString()
            {
                //! Update the ToString() to include your new prop
                return base.ToString() + $"\nGet Trolled! +{DamageBuff} to min damage!";
            }

        //Override method to Calc the Dmg buff
        public override int CalcDamage()
        {
            //throw new NotImplementedException();
            int result;//create the return object  

            Random rand = new Random();//setup necessary resources          
            result = rand.Next(MinDamage, MaxDamage);//modify the return object
            //Prompt to check calculation
            Console.WriteLine($"Before Mod: {result}\n");
            result += DamageBuff;
            
            if (result > MaxDamage)
            {
                Console.WriteLine("Min damage can't be more than max! Max damage stat replaced");
                result = MaxDamage;                
             
            }
            if (result <= 0)
            {
                Console.WriteLine("Min damage has to be 1");
                result = 1;

            }
            //Prompt to check calculation
            Console.WriteLine($"Damage Buff: +{DamageBuff}");
            Console.WriteLine($"After Mod: {result}\n");
            return result;//return the return object
        }


    }
    
}

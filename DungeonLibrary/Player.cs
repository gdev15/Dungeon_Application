using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //make it public, make it a child of character
    //Character includes Name, HitChance, Block, Life and MaxLife
    public class Player : Character
    {

        //Fields - none
        //Properties
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; } //CONTAINMENT
        public int Score { get; set; }

        //Constructors
        public Player(string name, int hitChance, int block, int maxLife, Race playerRace, Weapon equippedWeapon) : base(name, hitChance, block, maxLife)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            #region Potential Expansion: Racial Bonuses
            switch (PlayerRace)
            {
                case Race.Human:
                    MaxLife += 3;
                    Life = MaxLife;
                    break;
                case Race.Elf:
                    HitChance += 5;
                    break;
                default:
                    break;
            }
            #endregion
        }
        //Methods
        public override string ToString()
        {
            //A description for the race:
            string description;
            switch (PlayerRace)
            {
                case Race.Human:
                    description = "Boring, basic human. Probably snores.";
                    break;
                case Race.Elf:
                    description = "A little big for Santa's workshop...";
                    break;
                default:
                    description = "Somehow, this being has no discernable race...";
                    break;
            }

            //add the weapon and the description to the base.ToString()
            return base.ToString() + $"Weapon:\t{EquippedWeapon}\n" +
                                     $"Description: {description}\n" +
                                     $"You have defeated {Score} monster(s)";
        }//end ToString()

        //override CalcHitChance/CalcDamage... 
        public override int CalcDamage()
        {
            //create the return object
            int result;
            //setup necessary resources
            Random rand = new Random();
            //modify the return object
            int minDamage = EquippedWeapon.MinDamage;
            int maxDamage = EquippedWeapon.MaxDamage;
            if (EquippedWeapon.Type == WeaponType.Bow && PlayerRace == Race.Elf)
            {
                minDamage += 3;
                maxDamage += 5;
            }
            result = rand.Next(minDamage, maxDamage + 1);
            //return the return object
            return result;

            //return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }

    }
}

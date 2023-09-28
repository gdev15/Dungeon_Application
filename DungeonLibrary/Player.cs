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



        //Added for custom weapon damages
        public int WeaponMinDamage { get; set; }
        public int WeaponMaxDamage {  get; set; }


        //Added Default to allow a blank Player object to be generated before the user selects customizable options
        public Player() { }
        //Constructors
        public Player(string name, int hitChance, int block, int maxLife, int initiative, Race playerRace, Weapon equippedWeapon, int weaponMinDamage, int weaponMaxDamage) : base(name, hitChance, block, maxLife, initiative)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            WeaponMinDamage = weaponMinDamage;
            WeaponMaxDamage = weaponMaxDamage;

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
                    description = "Human";
                    break;
                case Race.Elf:
                    description = "Elf";
                    break;

                case Race.Dwarf:
                    description = "Dwarf";
                    break;

                case Race.Gnome:
                    description = "Gnome";
                    break;

                default:
                    description = "Somehow, this being has no discernable race...";
                    break;
            }

            //add the weapon and the description to the base.ToString()
            return base.ToString() + $"Weapon:\t{EquippedWeapon.Type}\n" +
                                     $"Weapon Damage:\t{WeaponMinDamage} to {WeaponMaxDamage}\n" +
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

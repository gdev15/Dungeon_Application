using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //Handle one side of a round of combat (one attack)
        public static void DoAttack(Character attacker, Character defender)
        {
            //pause the application to make it look like something is happening.
            Thread.Sleep(400);

            //20% chance to do a thing:
            //1 to 100: anything less than 20 will succeed
            int chance = attacker.CalcHitChance() - defender.CalcBlock();
            int roll = new Random().Next(1, 101);
            //the attacker "hits" if roll is less than the adjusted hit chance.
            if (roll >= chance)
            {
                //attacker missed:
                Console.WriteLine($"{attacker.Name} missed!");
                return;//quit the method.
            }
            //calculate the damage:
            int damage = attacker.CalcDamage();

            //remove life from the defender
            defender.Life -= damage;
            //defender.Life = defender.Life - damage;
            //show the results to the console
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} damage!");
            Console.ResetColor();
        }//end DoAttack()
        //Handle one full round of combat (player attack, then monster attack)
        //returns true if the monster has died, false if the monster is still alive.
        public static bool DoBattle(Player player, Monster monster)
        {
            #region expansions
            //Possible Expansion: Give certain character races or characters with a certain weapon an advantage
            //if (player.CharacterRace == Race.DarkElf)
            //{
            //    Combat.DoAttack(player, monster);
            //}

            //Consider adding an "Initiative" property to Character
            //Then check the Initiative to determine who attacks first
            //if (player.Initiative >= monster.Initiative)
            //{
            //    DoAttack(player, monster);
            //}
            //else
            //{
            //    DoAttack(monster, player);
            //}
            #endregion

            DoAttack(player, monster);
            if (monster.Life > 0)
            {                
                DoAttack(monster, player);
                return false;//monster is still alive
            }
            player.Score++;

            #region Combat Rewards - Potential Expansion
            //healing logic (player.Life += 5)

            //Loot drops (NOTE: This would require an Item class as well as an Inventory Property for 
            //Player List<Item>)

            //Item rubyNecklace = new Item("Ruby Necklace", "Increases Max Life", MaxLife, 10);
            //inventory.add(rubyNecklace);
            //Console.WriteLine($"{player.Name} received {rubyNecklace.Name}!");
            //Console.WriteLine("{0}", rubyNecklace);
            #endregion

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nYou killed {monster.Name}!\n");
            Console.ResetColor();
            return true;//monster has died!
        }
    }
}

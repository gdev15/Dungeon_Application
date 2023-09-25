/*
 * Filename: Combat.cs
 * Author: Gabriel Ramirez
 * Date: 9/23/2023
 * Description: Provides methods for player combat and turn base action
 */

namespace DungeonLibrary
{
    public class Combat   

    {


        public static int RollInitiative(Character character)
        {
            Random rand = new Random();
            return rand.Next(1,21);            

        }
        
        public static bool CombatRotation(Player player, Monster monster)
        {
            //Player Goes First
            if(player.Initiative > monster.Initiative)
            {
                Console.WriteLine($"{player.Name} go first");
                return true;
            }
            //Monster Goes First
            else
            {
                Console.WriteLine($"{monster.Name} ({monster.MonsterRace}) goes first!");
                return false;
            }
        }


        public static string DoAttack(Character attacker, Character defender)
        {


            string[] defensiveAction =
            {
                "Deflected",
                "Evaded",
                "Sidestepped",
                "Ducked",
                "Avoided",
                "Eluded",
                "Blocked",
                "Shielded",
                "Fended off",
                "Parried"
            };

            //Attacker turn
            Console.WriteLine("You attacked");
            Random rand = new Random();
            //index to get a random string index from the list
            int index = rand.Next(10);
            int swing = rand.Next(1, 21);
            attacker.HitChance = swing;
            Console.WriteLine($"{attacker.Name} Rolled a {swing}\n");

            //Defender turn
            Console.WriteLine("Enemy attacked");
            int index2 = rand.Next( 10);
            int swing2 = rand.Next(1, 21);
            Console.WriteLine($"{defender.Name} Rolled a {swing2}\n");
            Thread.Sleep(1000);
            Console.Clear();
            if (attacker.Life <= 0 || defender.Life <= 0)
            {
                Console.WriteLine("You are engaged in COMBAT!");
            }
            //Attcker Hit
            if (attacker.HitChance >= defender.Block)
            {
                defender.Life -= 30;

                if(defender.Life <= 0)
                {
                    defender.Life = 0;
                }
                
                return
                   $"{defender.Name} has taken damage\n" +
                   $"{defender.Name} HP: {defender.Life}";
            }
            //Defender Hit
            if(defender.HitChance >= attacker.Block)
            {
                attacker.Life -= 30;
                return
                   $"{attacker.Name} has taken damage\n" +
                   $"{attacker.Life}";
            }
            if(defender.HitChance <= attacker.Block)
            {
                return
                 $"{attacker.Name} has {defensiveAction[index]}\n";
            }
            else
            {
                return
                 $"{defender.Name} has {defensiveAction[index2]}\n";
            }
                                     
        

        }



    }
}

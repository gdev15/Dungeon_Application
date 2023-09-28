using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //Make it public, make it a child of Character
    public class Monster : Character
    {
        //unique fields
        private int _minDamage;

        //unique props
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            //custom business rule, value must be greater than 0 and less than MaxDamage.
            set
            {
                if ((value > 0 && value < MaxDamage))
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
            //set { _minDamage = (value > 0 && value < MaxDamage) ? value : 1; }              
        }
        public Monster(string name, int hitChance, int block, int maxLife, int initiative, int minDamage, int maxDamage, string description) : base(name, hitChance, block, maxLife, initiative)
        {
            MaxDamage = maxDamage;
            Description = description;
            MinDamage = minDamage;
          
        }

        public Monster()
        {

        }
        public override string ToString()
        {
            return $"\n********** MONSTER **********\n" +
                   base.ToString() +
                   $"Damage: {MinDamage} to {MaxDamage}\n" +
                   $"Description: {Description}";
        }

        public override int CalcDamage()
        {
            //throw new NotImplementedException();
            int result;//create the return object

            Random rand = new Random();//setup necessary resources

            result = rand.Next(MinDamage, MaxDamage + 1);//modify the return object

            return result;//return the return object
        }

         

        public static Monster GetMonster()
        {
            //Generate a random stat:   
            int stat= RandomRoll();

            //Generate a random description:
            string description = DescriptionGenerator();
            //create the return object
            Monster m = new();
            //setup necessary resources
            Troll troll = new("Troll", 25, 15, 25,0, 2, 8, description, stat);
            Goblin goblin = new("Goblin", 50, 20, 20,0, 2, 8, description, stat);
            Demon demon = new("Demon", 50, 20, 25,0, 2, 8, description, 0);
            Undead undead = new("Undead", 50, 20, 25,0, 2, 8, description, stat);
            Dragon dragon = new("Dragon", 50, 20, 25,0, 2, 8, description, stat, stat);
            List<Monster> monsters = new()
            {
                troll, troll, troll, troll, troll, troll,
                goblin, goblin, goblin,goblin, goblin,      
                undead, undead, undead,    
                demon, demon, demon,    
                dragon                
            };
            Random rand = new Random();
            int randomIndex = rand.Next(monsters.Count);
            //modify the return object
            m = monsters[randomIndex];
            //return the return object
            return m;

            //refactor
            //return monsters[new Random().Next(monsters.Count)];
        }

        //Method to generate a random value for stats
        public static int RandomRoll()
        {
            Random random = new Random();
            int stat = random.Next(1, 5);
            return stat;
        }

        //Monster Description Generator
        public static string DescriptionGenerator()
        {
            //Array of weapon names
            string[] descriptionList = new string[]
            {
                "Its eyes glow with an eerie, otherworldly light, sending chills down the spine of those who dare meet its gaze.",
                "A guttural growl resonates through the air.",              
                "A foul stench permeates the air around this creature",           
                "An aura of malevolence surrounds it, causing a palpable tension in the environment.",
                "Its laughter, cold and mocking, echoes hauntingly, making the bravest warriors second-guess their courage.",
                "Enveloped in an ethereal mist, its form seems to shift and waver, making it hard to pinpoint.",
                "Bony protrusions jut from its spine, each sharper than the last, serving as both armor and weapon.",
                "Chains, rusted from centuries of use, dangle from its limbs, clinking ominously with every movement.",
                "With every step, the ground trembles slightly, warning of its mighty power and relentless drive.",
                "Despite its monstrous appearance, there's an intelligence in its eyes, a cunning that's unsettling and profound.",
            };

            int i = new Random().Next(0, 10);

            string descriptionSelected = descriptionList[i];
            return descriptionSelected;

        }//end Weapon Name Generator

    }
}

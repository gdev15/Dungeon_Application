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
        public Monster(string name, int hitChance, int block, int maxLife, int minDamage, int maxDamage, string description) : base(name, hitChance, block, maxLife)
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
            //create the return object
            Monster m = new();
            //setup necessary resources
            Monster m1 = new("Monster 1", 50, 20, 25, 2, 8, "Monster 1");
            Monster m2 = new("Monster 2", 50, 20, 25, 2, 8, "Monster 2");
            Monster m3 = new("Monster 3", 50, 20, 25, 2, 8, "Monster 3");
            Monster m4 = new("Monster 4", 50, 20, 25, 2, 8, "Monster 4");
            Monster m5 = new("Monster 5", 50, 20, 25, 2, 8, "Monster 5");
            List<Monster> monsters = new()
            {
                m1, m1, m1, m1, m1,//5/17
                m2, m2, m2,        //3/17
                m3, m3, m3, m3,    //4/17
                m4, m4, m4, m4,    //4/17
                m5                 //1/17
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
    }
}

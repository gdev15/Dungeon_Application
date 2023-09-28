using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //The abstract modifier denotes this datatype class is "incomplete"
    public abstract class Character
        //public parent-only class called Character
    {
        //FIELDS (private datatype _camelCase)
        private string _name;
        private int _hitChance, _block, _maxLife, _life, _initiative;

        //PROPERTIES (public datatype PascalCase { get {} set{} } )
        public string Name { get { return _name; } set { _name = value; } }
        public int HitChance { get { return _hitChance; } set { _hitChance = value; } }
        public int Block { get { return _block; } set { _block = value; } }
        public int MaxLife { get { return _maxLife; } set { _maxLife = value; } }
        public int Initiative { get { return _initiative; } set { _initiative = value; } }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }//end Life

        //CTORS
        public Character()
        {
            //default CTOR
        }
        public Character(string name, int hitChance, int block, int maxLife, int initiative)
        {
            MaxLife = maxLife;
            Life = MaxLife;//start off with full health.
            Block = block;
            HitChance = hitChance;
            Name = name;
            Initiative = initiative;
        }
        //Methods
        public override string ToString()
        {
            //return base.ToString();
            return $"----- {Name} -----\n" +
                   $"Life: {Life} of {MaxLife}\n" +
                   $"Hit Chance: {HitChance}%\n" +
                   $"Block: {Block}%\n" +
                   $"Initiative: {Initiative}\n";
        }

        //virtual keyword allows these methods to be overridden in child classes.
        public virtual int CalcBlock()
        {
            return Block;
        }
        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcInitiative()
        {
            return Initiative;
        }


        //any child classes MUST override abstract methods.
        //you can only define abstract methods inside of abstract classes.
        public abstract int CalcDamage();
    
    
    }//end class
}//end namespace

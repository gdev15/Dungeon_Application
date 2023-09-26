using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //The abstract modifier denotes this datatype class is "incomplete"
    //We don't intend to create Character objects directly, but instead will use this 
    //class as a starting point for other, more specific types (Player and Monster)
    public abstract class Character
        //public parent-only class called Character
    {
        //FIELDS (private datatype _camelCase)
        private string _name;
        private int _hitChance, _block, _maxLife, _life;

        //PROPERTIES (public datatype PascalCase { get {} set{} } )
        public string Name { get { return _name; } set { _name = value; } }
        public int HitChance { get { return _hitChance; } set { _hitChance = value; } }
        public int Block { get { return _block; } set { _block = value; } }
        public int MaxLife { get { return _maxLife; } set { _maxLife = value; } }
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
        public Character(string name, int hitChance, int block, int maxLife)
        {
            MaxLife = maxLife;
            Life = MaxLife;//start off with full health.
            Block = block;
            HitChance = hitChance;
            Name = name;
        }
        //Methods
        public override string ToString()
        {
            //return base.ToString();
            return $"----- {Name} -----\n" +
                   $"Life: {Life} of {MaxLife}\n" +
                   $"Hit Chance: {HitChance}%\n" +
                   $"Block: {Block}%\n";
        }

        //virtual keyword allows these methods to be overridden in child classes.
        public virtual int CalcBlock()
        {
            //can be overridden in your OWN monster subtypes.
            return Block;
        }
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        //any child classes MUST override abstract methods.
        //you can only define abstract methods inside of abstract classes.
        public abstract int CalcDamage();
    }//end class
}//end namespace

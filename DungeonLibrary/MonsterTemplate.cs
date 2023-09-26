using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //! Make it public, make it a child of Monster, Rename it to whatever you want
    public class MonsterTemplate : Monster
    {
        //FIELDS - only if you have business rules


        //PROPS
        //! Add at least one custom property. 

        //CTORS        
        public MonsterTemplate(string name, int hitChance, int block, int maxLife, int maxDamage, int minDamage, string description) : base(name, hitChance, block, maxLife, maxDamage, minDamage, description)
        {
            //! Add your custom prop(s) to the parameter list and assign them here.
        }

        //! Default CTOR (creates a basic version of this monster)
        public MonsterTemplate()
        {
            //Assign each of the props some default value here
            //Name, HitChance, Block, MaxLife, MaxDamage, MinDamage, Description
        }

        public override string ToString()
        {
            //! Update the ToString() to include your new prop
            return base.ToString() + "";
        }

        //Override at least one parent method to change the functionality based on your custom prop
        //CalcBlock()
        //CalcHitChance()
        //CalcDamage()
    }
}

namespace DungeonLibrary
{
    //Starting blueprint for the Monster and Player classes
    public abstract class Character
    {
        //Fields
        private string _name;
        private int _hitChance, _block, maxLife, _life;
        //Update add initiative & level 
        private int _initiative, _characterLevel, _characterExp;


        //Properties
        public string Name { get { return _name; } set { _name = value; } }
        public int HitChance { get { return _hitChance; } set { _hitChance = value; } }

        public int Block { get { return _block; } set { _block = value; } }
        public int MaxLife { get { return maxLife; } set { maxLife = value; } }

        //Updated properties
        public int Initiative { get { return _initiative; } set { _initiative = value; } }
        public int CharacterLevel { get { return _characterLevel; } set { _characterLevel = value; } }

        public int CharacterExp { get { return _characterExp; } set { _characterExp = value; } }

        public int Life
        {
            get
            {
                return _life;
            }
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

        //Default constructor
        public Character()
        {

        }

        //Constructor with overloads
        public Character(string name, int hitChance, int block, int maxLife, int initiative, int characterLevel, int characterExp)
        {
            MaxLife = maxLife;
            Life = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block; 
            Initiative = initiative;
            CharacterLevel = characterLevel;
            CharacterExp = characterExp;
            

        }

        public override string ToString()
        {
            return
                 $"Name: {Name}\n" +                 
                 $"HP: {Life} of {MaxLife} \n" +
                 $"Hit: {HitChance}% \n" +
                 $"Block: {Block}\n" +
                 $"Initiative: {Initiative}\n" +
                 $"Level: {CharacterLevel}\n" +
                 $"Exp: {CharacterExp}\n";

        }

    }
}
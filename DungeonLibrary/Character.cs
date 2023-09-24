namespace DungeonLibrary
{
    //Starting blueprint for the Monster and Player classes
    public abstract class Character
    {
        //Fields
        private string _name;
        private int _hitChance, _block, maxLife, _life;

        //Properties
        public string Name { get { return _name; } set { _name = value; } }
        public int HitChance { get { return _hitChance; } set { _hitChance = value; } }

        public int Block { get { return _block; } set { _block = value; } }
        public int MaxLife { get { return maxLife; } set { maxLife = value; } }

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
        public Character(string name, int hitChance, int block, int maxLife, int life)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
        }

        public override string ToString()
        {
            return
                 $"{Name}\n" +
                 $"{Life}\n" +
                 $"{HitChance}\n" +
                 $"{Block}\n";
        }

    }
}
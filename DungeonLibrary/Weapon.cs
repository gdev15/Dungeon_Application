namespace DungeonLibrary
{
    public class Weapon
    {
        //FIELDS (private datatype _camelCase)
        private string _name;
        private int _minDamage, _maxDamage, _bonusHitChance;
        private bool _isTwoHanded;
        private WeaponType _type;

        //PROPERTIES (public datatype PascalCase { get {} set{} } )
        public string Name { get { return _name; } set { _name = value; } }
        public int BonusHitChance { get { return _bonusHitChance; } set { _bonusHitChance = value; } }
        public int MaxDamage { get { return _maxDamage; } set { _maxDamage = value; } }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //business rule:
                //0 < MinDamage <= MaxDamage
                if (value > 0 && value <= MaxDamage)
                {
                    //good to go
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }
        public bool IsTwoHanded { get { return _isTwoHanded; } set { _isTwoHanded = value; } }
        public WeaponType Type { get { return _type; } set { _type = value; } }

        //CTORS
        //add WeaponType type to param list
        public Weapon(string name, int minDamage, int maxDamage, int bonusHitChance, bool isTwoHanded,
            WeaponType type)
        {
            if (minDamage > maxDamage)
            {
                Console.WriteLine("Min Damage must not be more than Max Damage");
            }
            //ANY props that have business rules that depend on OTHER properties
            //must be assigned AFTER the independent properties are set.
            //MinDamage depends on MaxDamage, so MaxDamage must be set first.
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
            Type = type;
        }//Fully-Qualified Constructor

        //Method:
        public override string ToString()
        {
            //return base.ToString();//namespace.classname
            return $"Name: {Name}\n" +
                   $"Damage: {MinDamage} to {MaxDamage}\n" +
                   $"Bonus Hit: {BonusHitChance}%\n" +
                   $"{(IsTwoHanded ? "Two-" : "One-")}Handed {Type}";//update with Type
        }
    }
}
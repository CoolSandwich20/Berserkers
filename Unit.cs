namespace FirstLesson
{
    public abstract class Unit
    {
        public Unit(IRandomProvider damage, Race race,
            int Hp)
        {
            Damage = damage;
            HitChanceDie = new Dice(1, 20, 0);
            DefenceRatingDie = new Dice(1, 20, 0);
            Race = race;
            HP = Hp;
        }

        public int CarryingCapacity { get; set; }
        protected virtual Race Race { get; set; }
        public bool isDead => HP == 0;
        protected IRandomProvider Damage { get; set; }
        protected IRandomProvider HitChanceDie { get; set; }
        public IRandomProvider DefenceRatingDie { get; set; }
        private int _hp;

        public virtual int HP
        {
            get { return _hp; }
            protected set
            {
                if (value < 0) _hp = 0;
                else _hp = value;
            }
        }

        public virtual void AssignRandom(IRandomProvider DefenceRandom, IRandomProvider DamageRandom,
            IRandomProvider HitChanceRandom)
        {
        }

        public virtual void WeatherEffect(WeatherEffects weatherEffects)
        {
            IRandomProvider temp = HitChanceDie;

            switch (weatherEffects)
            {
                case WeatherEffects.Dry:
                    temp.ChangeModifier(0);
                    HitChanceDie = temp;
                    break;
                case WeatherEffects.Windy:
                    temp.ChangeModifier(-2);
                    HitChanceDie = temp;
                    break;
                case WeatherEffects.Rainy:
                    temp.ChangeModifier(-4);
                    HitChanceDie = temp;
                    break;
                case WeatherEffects.Snowy:
                    temp.ChangeModifier(-6);
                    HitChanceDie = temp;
                    break;
            }
        }


        public abstract void Attack(Unit Defender);

        public virtual void Defend(Unit Attacker)
        {
            HP -= Attacker.Damage.GetRandomNumber();
        }
    }

    public abstract class Infantry : Unit
    {
        public int Armor { get; set; } //This is A modifier

        public override void Attack(Unit DefenderUnit)
        {
            if (this.HitChanceDie.GetRandomNumber() >= DefenderUnit.DefenceRatingDie.GetRandomNumber())
            {
                Console.WriteLine($"{this} attacked {DefenderUnit} - {this.HitChanceDie}");
                DefenderUnit.Defend(this);
            }
            else
            {
                Console.WriteLine(
                    $"{this} Missed Attack - Defenders Roll Was {DefenderUnit.DefenceRatingDie} = {DefenderUnit.DefenceRatingDie.GetRandomNumber()}");
            }
        }


        protected Infantry(IRandomProvider damage,
            Race race, int Hp, int armor) : base(damage, race, Hp)
        {
            Armor = armor;
        }
    }

    public abstract class RangedUnit : Unit
    {
        public int Agility { get; set; } // This is a modifier
        private int _ammo;

        protected virtual int Ammounition
        {
            get { return _ammo; }
            set
            {
                _ammo = value;
                if (_ammo <= 0)
                {
                    Damage = new Dice(1, 6, 0); //Short Sword???
                }
            }
        }

        public override void Attack(Unit DefenderUnit)
        {
            if (HitChanceDie.GetRandomNumber() >= DefenderUnit.DefenceRatingDie.GetRandomNumber())
            {
                Console.WriteLine($"{this} attacked {DefenderUnit} - {this.HitChanceDie}");
                Defend(this);
                Ammounition--;
            }
            else
            {
                Console.WriteLine($"{this} Missed {DefenderUnit}");
            }
        }


        protected RangedUnit(IRandomProvider damage,
            Race race, int Hp, int ammo, int agility) : base(damage, race, Hp)
        {
            Ammounition = ammo;
            Agility = agility;
            HitChanceDie = new Bag(1, 1, 20, 0);
            DefenceRatingDie.ChangeModifier(Agility);
        }
    }

    public enum Race
    {
        Dwarf,
        Human,
        Orc
    }

    public enum WeatherEffects
    {
        Dry,
        Windy,
        Rainy,
        Snowy
    }
}
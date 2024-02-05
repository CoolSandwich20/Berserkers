using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLesson
{
    public sealed class DwarfRifleMan : RangedUnit
    {
        public DwarfRifleMan():base(new Bag(2, 1, 25,0),Race.Dwarf, 25, 20, 3)
        {
         
        }

        public override string ToString()
        {
            return "Dwarf Rifleman";
        }
    }

    public sealed class DwarfPikeMan : Infantry
    {
        public DwarfPikeMan(): base(new Dice(1, 10, 0),Race.Dwarf, 50, 6)
        {
        }

        public override string ToString()
        {
            return "Dwarf Pikeman";
        }
    }

    public sealed class DwarfAxeMan : Infantry
    {
        public DwarfAxeMan() : base(new Dice(2, 6, 0),Race.Dwarf, 55, 8)
        {
        }

        public override string ToString()
        {
            return "Dwarf Axeman";
        }
    }


    public sealed class OrcBowMan : RangedUnit
    {
        public OrcBowMan():base(new Dice(1, 6, 0),Race.Orc, 15, 20, 5)
        {
        }

        public override string ToString()
        {
            return "Orc Bowman";
        }
    }

    public sealed class OrcSkirmish : RangedUnit
    {
        public OrcSkirmish(): base(new Dice(2, 6, 0),Race.Orc, 30, 10, 5)
        {
        }

        public override string ToString()
        {
            return "Orc Skirmish";
        }
    }

    public sealed class OrcWarrior : Infantry
    {
        public OrcWarrior(): base(new Dice(1, 10, 0),Race.Orc, 60, 5)
        {
        }

        public override string ToString()
        {
            return "Orc Warrior";
        }
    }

    public sealed class CrossBowMan : RangedUnit
    {
        public CrossBowMan() : base(new Bag(1, 0, 20,0),Race.Human, 35, 30, 5)
        {
        }

        public override string ToString()
        {
            return "Genoese Crossbowman";
        }
    }

    public sealed class Peasnt : Infantry
    {
        public Peasnt(): base(new Dice(2, 4, 0),Race.Human, 10, 2)
        {
        }

        public override string ToString()
        {
            return "Kingdom's Peasnt";
        }
    }

    public sealed class Knight : Infantry
    {
        public Knight(): base(new Dice(2, 8, 0),Race.Human, 80, 6)
        {
        }

        public override string ToString()
        {
            return "Knight Of the Round Table";
        }
    }
}
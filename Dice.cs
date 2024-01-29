using System.Diagnostics.CodeAnalysis;


namespace FirstLesson
{
    public struct Dice : IRandomProvider
    {
        public uint  Scalar { get; set; }

        public uint MaxNumber { get; set; }
        public int Modifier { get; set; }
        //E.g., Dice(2,8,-1) => 2d8 -1
        public Dice(uint scalar, uint baseDie, int modifier)
        {
            Scalar = scalar;
            MaxNumber = baseDie;
            Modifier = modifier;
        }



        public int GetRandomNumber()
        {
            int res = 0;
            for (int i = 0; i < Scalar; i++)
            {
                res += Random.Shared.Next(1, (int)MaxNumber);
            }

            return res + Modifier;
        }

        public override string ToString()
        {
            string modifierSymb = "";
            if (Modifier >= 0) modifierSymb = "+";
            return $"{Scalar}d{MaxNumber}{modifierSymb}{Modifier}";
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) return false;
            else
            {
                Dice diceEq = (Dice)obj;
                return diceEq.Scalar == Scalar && diceEq.MaxNumber == MaxNumber && diceEq.Modifier == Modifier;
            }
        }

        public override int GetHashCode()
        {
            int prime1 = 17;
            int prime2 = 23;
            int prime3 = 31;

            int hash = prime1 * Scalar.GetHashCode();
            hash = (hash * prime2) + MaxNumber.GetHashCode();
            hash = (hash * prime3) + Modifier.GetHashCode();

            return
                hash; //This feels a bit useless because there are still 9 Archtypes that use the same 1d20 with 0 Modifier.
        }
    }
}

namespace FirstLesson
{
    public class Player
    {
        public int ResourcesOnPlayer;
        public IRandomProvider ResourcesRoll;
        public List<Unit> UnitsOnPlayer;
        public Race RaceOnPlayer { get; set; }
        public Player(Race raceOnPlayer, int unitAmounts)
        {
            UnitsOnPlayer = new();
            RaceOnPlayer = raceOnPlayer;
            ResourcesRoll = new Dice(10, 6, 0);
            for (int i = 0; i < unitAmounts; i++)
            {
                switch (raceOnPlayer)
                {
                    case Race.Human:
                        switch (Random.Shared.Next(0, 3))
                        {
                            case 0:
                                UnitsOnPlayer.Add(new CrossBowMan());
                                break;
                            case 1:
                                UnitsOnPlayer.Add(new Peasnt());
                                break;
                            case 2:
                                UnitsOnPlayer.Add(new Knight());
                                break;
                        }
                        break;
                    case Race.Orc:
                        switch (Random.Shared.Next(0, 3))
                        {
                            case 0:
                                UnitsOnPlayer.Add(new OrcBowMan());
                                break;
                            case 1:
                                UnitsOnPlayer.Add(new OrcSkirmish());
                                break;
                            case 2:
                                UnitsOnPlayer.Add(new OrcWarrior());
                                break;
                        }
                        break;
                    case Race.Dwarf:
                        switch (Random.Shared.Next(0, 3))
                        {
                            case 0:
                                UnitsOnPlayer.Add(new DwarfAxeMan());
                                break;
                            case 1:
                                UnitsOnPlayer.Add(new DwarfPikeMan());
                                break;
                            case 2:
                                UnitsOnPlayer.Add(new DwarfRifleMan());
                                break;
                        }
                        break;
                }
            }

        }

        public int TransferResources(Player losingPlayer)
        {
            return ResourcesOnPlayer += losingPlayer.ResourcesOnPlayer;
        }
        public void PrintAllUnits()
        {
            foreach (Unit unit in UnitsOnPlayer)
            {
                Console.WriteLine(unit);
            }
        }
    }
}


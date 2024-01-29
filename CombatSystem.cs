

namespace FirstLesson
{
    public class CombatSystem
    {
        public Dice WeatherDice { get; set; }
        private int _lastWeatherApplied;

        public void CombatLoop(Player firstPlayer, Player secondPlayer)
        {
            firstPlayer.ResourcesOnPlayer = firstPlayer.ResourcesRoll.GetRandomNumber();
            secondPlayer.ResourcesOnPlayer = secondPlayer.ResourcesRoll.GetRandomNumber();
            Console.WriteLine($"Marching from the North, the indomitable {firstPlayer.RaceOnPlayer} army advances toward the battlefield!");
            firstPlayer.PrintAllUnits();
            Console.WriteLine($"The mighty {secondPlayer.RaceOnPlayer} armada stands unyielding, echoing chants that reverberate for miles: 'We shall never surrender!");
            secondPlayer.PrintAllUnits();
            Console.WriteLine($"First Player Resources - {firstPlayer.ResourcesOnPlayer}");
            Console.WriteLine();
            Console.WriteLine($"Second Player Resources - {secondPlayer.ResourcesOnPlayer}");
            int turns = 0;
            do
            {

                WeatherEffect(firstPlayer, secondPlayer, turns);
                turns++;
                int firstPlayerIndex = Random.Shared.Next(0, firstPlayer.UnitsOnPlayer.Count());
                int secondPlayerIndex = Random.Shared.Next(0, secondPlayer.UnitsOnPlayer.Count());
                firstPlayer.UnitsOnPlayer[firstPlayerIndex].Attack(secondPlayer.UnitsOnPlayer[secondPlayerIndex]);
                if (secondPlayer.UnitsOnPlayer[secondPlayerIndex].isDead)
                    secondPlayer.UnitsOnPlayer.Remove(secondPlayer.UnitsOnPlayer[secondPlayerIndex]);

                if (secondPlayer.UnitsOnPlayer.Count() == 0) break;
                firstPlayerIndex = Random.Shared.Next(0, firstPlayer.UnitsOnPlayer.Count());
                secondPlayerIndex = Random.Shared.Next(0, secondPlayer.UnitsOnPlayer.Count());
                secondPlayer.UnitsOnPlayer[secondPlayerIndex].Attack(firstPlayer.UnitsOnPlayer[firstPlayerIndex]);
                if (firstPlayer.UnitsOnPlayer[firstPlayerIndex].isDead)
                    firstPlayer.UnitsOnPlayer.Remove(firstPlayer.UnitsOnPlayer[firstPlayerIndex]);

            }
            while (firstPlayer.UnitsOnPlayer.Count != 0);
            if (firstPlayer.UnitsOnPlayer.Count() == 0)
            {
                Console.WriteLine($"{firstPlayer} Won the game");
                firstPlayer.TransferResources(secondPlayer);
                Console.WriteLine($"First Player new Resources - {firstPlayer.ResourcesOnPlayer}");
            }
            else if (secondPlayer.UnitsOnPlayer.Count() == 0)
            {
                Console.WriteLine($"{secondPlayer} Won the game");
                secondPlayer.TransferResources(firstPlayer);
                Console.WriteLine($"Second Player new Resources - {secondPlayer.ResourcesOnPlayer}");
            }
            else
            {
                Console.WriteLine("Both Failed to impress the audience, endured strategic defeat, and await a shameful fate");
            }
        }
        private void WeatherEffect(Player a, Player b, int currentTurn)
        {
            int randomChance = Random.Shared.Next(0, 100);
            if (currentTurn - _lastWeatherApplied == 5)
            {
                ReturnListOfUnits(a, b, WeatherEffects.Dry);
                return;
            }
            switch (randomChance)
            {
                case <= 10:
                    ReturnListOfUnits(a, b, WeatherEffects.Snowy);
                    _lastWeatherApplied = currentTurn;
                    break;
                case > 10 when randomChance <= 25:
                    ReturnListOfUnits(a, b, WeatherEffects.Rainy);
                    _lastWeatherApplied = currentTurn;
                    break;
                case > 25 when randomChance <= 50:
                    ReturnListOfUnits(a, b, WeatherEffects.Windy);
                    _lastWeatherApplied = currentTurn;
                    break;
                default:
                    break;
            }
        }
        private void ReturnListOfUnits(Player a, Player b, WeatherEffects effects)
        {
            foreach (Unit unit in a.UnitsOnPlayer)
            {
                unit.WeatherEffect(effects);

            }
            foreach (Unit unit in b.UnitsOnPlayer)
            {
                unit.WeatherEffect(effects);
            }
            Console.WriteLine($"{effects}");
        }
    }
}

using FirstLesson;

namespace CSharp_firstLesson
{
    internal class Program
    {
        public static void Main(String[] args)
        {
            Player player = new Player(Race.Human, 5);
            Player player1 = new Player(Race.Dwarf, 5);
            CombatSystem combatSystem = new CombatSystem();
            combatSystem.CombatLoop(player, player1);
            
        }
    }
}
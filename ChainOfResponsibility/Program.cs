namespace ChainOfResponsibility
{

    /// <summary>
    /// A chain of components who all get a chance to process a command or a query,
    /// optionally having default processing implementation and an ability to
    /// terminate the processing chain.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //-------------------Method Chain-------------------
            var goblin = new Creature("Goblin", 2, 2);
            Console.WriteLine(goblin);

            var root = new CreatureModifier(goblin);

            Console.WriteLine("Let's double the goblin's attack");
            root.Add(new DoubleAttackModifier(goblin));

            Console.WriteLine("Let's stop goblin from getting any modifiers");
            root.Add(new NoBonusesModifier(goblin));

            Console.WriteLine("Let's double the goblin's defense");
            root.Add(new IncreasedDefenseModifier(goblin));

            root.Handle();
            Console.WriteLine(goblin);

        }
    }
}
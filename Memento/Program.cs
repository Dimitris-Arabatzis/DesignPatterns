namespace Memento
{

    /// <summary>
    /// A token/handle representing the system state.
    /// Lets us roll back to the state when the token was generated.
    /// May or may not directly expose state information.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //------------------- Undo Redo -------------------

            var ba = new BankAccount(100);
            var m1 = ba.Deposit(50); //150
            var m2 = ba.Deposit(25); //175

            Console.WriteLine(ba);

            ba.Undo();
            Console.WriteLine($"Undo 1: {ba}");

            ba.Undo();
            Console.WriteLine($"Undo 2: {ba}");

            ba.Redo();
            Console.WriteLine($"Redo 1: {ba}");

            ba.Redo();
            Console.WriteLine($"Redo 2: {ba}");

            //------------------- Undo Redo -------------------


        }
    }
}

using static System.Console;

namespace Command
{
    internal class Program
    {
        /// <summary>
        /// An object which represents an instruction to perform a particular action.
        /// Contains all the information necessary for the action to be taken.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //-------------------Command-------------------
            var ba = new BankAccount();
            var commands = new List<BankAccountCommand>
            {
                new BankAccountCommand(ba,BankAccountCommand.Action.Deposit,100),
                new BankAccountCommand(ba,BankAccountCommand.Action.Withdraw,50),
            };
            WriteLine(ba);

            commands.ForEach(c => c.Call());

            WriteLine(ba);
            //-------------------Undo Command-------------------
            foreach (var c in Enumerable.Reverse(commands))
            {
                c.Undo();
            }

            WriteLine(ba);
        }
    }
}
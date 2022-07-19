using System;

namespace NullObject
{
    internal class Program
    {
        /// <summary>
        /// A no-op object that conforms to the required interface,
        /// satisfying a dependency requirement of some other object.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //------------------- Null Object Example -------------------

            var log = new NullLog();
            var ba = new BankAccount(log);
            ba.Deposit(100);
        }
    }
}

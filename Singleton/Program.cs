using MoreLinq;
using Singleton;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace Prototype
{
    internal class Program
    {
        /// <summary>
        /// -A component which is instanciated only once.
        /// EX. Database Repository or Object factory
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //---------------------Singleton via lazy loading---------------------
            var db = SingletonDatabase.Instance;
            WriteLine($"Tokyo has population of {db.GetPopulation("Tokyo")}");


            //---------------------Monostate Singleton Pattern---------------------
            var ceo = new MonostateCEO() { Name = "Martin", Age = 26 };
            var ceo2 = new MonostateCEO();
            WriteLine(ceo2);
        }



    }
}
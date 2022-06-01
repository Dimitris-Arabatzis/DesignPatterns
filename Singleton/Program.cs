using MoreLinq;
using Singleton;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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


            //---------------------Monostate Singleton Pattern---------------------

            var t1 = Task.Factory.StartNew(() =>
            {
                WriteLine($"t1: " + PerThreadSingleton.Instance.Id);
            });
            var t2 = Task.Factory.StartNew(() =>
            {
                WriteLine($"t2: " + PerThreadSingleton.Instance.Id);
                WriteLine($"t2: " + PerThreadSingleton.Instance.Id);
            });

            Task.WaitAll(t1,t2);

            //---------------------Ambient Context Pattern---------------------

            var house = new Building();

            //ground floor 3000
            using(new BuildingContext(3000))
            {

                house.walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
                house.walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));

                using (new BuildingContext(3500))
                {
                    //1st floor 3500
                    house.walls.Add(new Wall(new Point(0, 0), new Point(6000, 0)));
                    house.walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
                }
                //1st floor 3000
                house.walls.Add(new Wall(new Point(5000, 0), new Point(5000, 4000)));
            }

            WriteLine(house);
        }
    }
}
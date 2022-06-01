using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Reflection;
using System.Runtime;


namespace Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;

        //TestPurpose
        private static int instanceCount;//0
        public static int Count => instanceCount;
        //TestPurpose

        private SingletonDatabase()
        {
            instanceCount++;
            WriteLine("Initializing database");

            //capitals = File.ReadAllLines("CapitalCities.txt")
            //    .Batch(2)
            //    .ToDictionary(
            //        list => list.ElementAt(0).Trim(),
            //        list => int.Parse(list.ElementAt(1).Trim())
            //    );

            capitals = File.ReadAllLines(Path.Combine(
                    new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName,
                    "CapitalCities.txt"
                ))
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1).Trim())
                );
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}

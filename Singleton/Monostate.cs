using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{

    /// <summary>
    /// Monostate is a version of the singleton pattern.
    /// You can create as many instances of this class and modify data on any of them as you wish but all will access the same properties.
    /// </summary>
    public class MonostateCEO
    {
        private static string name;
        private static int age;

        public string Name { 
            get => name;
            set => name = value;
        }
        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
    
}

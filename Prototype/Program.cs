using static System.Console;

namespace Prototype
{
    internal class Program
    {
        /// <summary>
        /// -Complicated objects are not designed from scratch.
        /// EX. Cars are reiterations of existing designs.
        /// -An existing (partially or fully constructed) design is a prototype.
        /// -We make a copy(clone) of the prototype and customize it (this requires deep copy support).
        /// -We make the copy convinient via an api(e.g. via a factory)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //---------------------Copy Constructor---------------------(This is a C++ Design pattern that works but is not recognizable by C# devs)
            WriteLine("---------------------Copy Constructor---------------------");

            var johnCC = new PersonCC(new[] { "John", "Smith" },
                new AddressCC("London Road", 123));

            var janeCC = new PersonCC(johnCC);
            janeCC.Address.houseNumber = 321;
            WriteLine(johnCC);
            WriteLine(janeCC);

            //---------------------Explicit DeepCopy Interface---------------------
            WriteLine("---------------------Explicit DeepCopy Interface---------------------");
            var johnEDCI = new PersonEDCI(new[] { "John", "Smith" },
                new AddressEDCI("London Road", 123));

            var janeEDCI = johnEDCI.DeepCopy();
            janeEDCI.Address.houseNumber = 321;
            WriteLine(johnEDCI);
            WriteLine(janeEDCI);
            //---------------------Prototype Inheritance---------------------
            WriteLine("---------------------Prototype Inheritance---------------------");
            var john = new EmployeePI();
            john.Names = new[] { "John", "Doe" };
            john.Address = new AddressPI()
            {
                houseNumber = 123,
                StreetName = "London Road"
            };
            john.Salary = 321000;
            var copy = john.DeepCopy();

            copy.Address.houseNumber = 1234556;
            copy.Names[0] = "Martin";
            copy.Salary = 999999;
            WriteLine(john);
            WriteLine(copy);
            //---------------------Copy Through Serialization--------------------- (Real world prototype pattern)
            WriteLine("---------------------Copy Through Serialization---------------------");
            var john2 = new Employee();
            john2.Names = new[] { "John", "Doe" };
            john2.Address = new Address()
            {
                houseNumber = 123,
                StreetName = "London Road"
            };
            john2.Salary = 321000;
            var copy2 = john2.DeepCopyByXmlStream();

            copy2.Address.houseNumber = 1234556;
            copy2.Names[0] = "Martin";
            copy2.Salary = 999999;
            WriteLine(john2);
            WriteLine(copy2);


        }
    }
}
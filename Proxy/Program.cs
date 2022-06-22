
namespace Proxy
{

    /// <summary>
    /// A class that functions as an interface to a particular resource. That resource may be remote, expensive to construct
    /// ,may require logging or some other added functionality.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //---------------------Protection Proxy---------------------
            ICar car = new CarProxy(new Driver(age: 12));
            ICar car2 = new CarProxy(new Driver(age: 22));
            car.Drive();
            car2.Drive();

            //---------------------Value Proxy---------------------
            Console.WriteLine(
                10f * 5.Percent()
                );

            Console.WriteLine(
                2.Percent() + 3.Percent()
                );
        }
    }
}
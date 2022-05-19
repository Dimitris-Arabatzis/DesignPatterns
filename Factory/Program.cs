using System;
using System.Threading.Tasks;

namespace Factory
{
    internal class Program
    {


        static async Task Main(string[] args)
        {

            //---------------------Factory Method---------------------
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI/2);
            Console.WriteLine(point);

            //---------------------Async Factory Method---------------------
            var foo = await Foo.CreateAsync();

            //---------------------Tracking Factory---------------------
            var trackingFactory = new TrackingThemeFactory();
            var theme1 = trackingFactory.CreateTheme(false);
            var theme2 = trackingFactory.CreateTheme(true);
            Console.WriteLine(trackingFactory.Info);

            //---------------------Replaceable Factory---------------------
            var replaceableFactory = new ReplaceableThemeFactory();
            var repleacableTheme = replaceableFactory.CreateTheme(true);
            Console.WriteLine(repleacableTheme.Value.BgrColor);
            replaceableFactory.ReplaceTheme(false);
            Console.WriteLine(repleacableTheme.Value.BgrColor);

            //---------------------Abstract Factory---------------------(User Input)
            var machine = new HotDrinkMachine();
            //var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            //drink.Consume();
            var drink = machine.MakeDrink();
            drink.Consume();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //-------------------Without Builder-------------------
            var sb = new StringBuilder();

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
                sb.Append($"<li>{word}</li>");
            sb.Append("</ul>");
            Console.WriteLine(sb);



            //-------------------Html Builder--------------------
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world");
            Console.WriteLine(builder.ToString());

            //-------------------StepWise Car Builder-------------------
            //Builds an object and guides the user with specific fuctions in a fluent api.
            var carBuilder = new StepwiseCarBuilder();
            var car = carBuilder.Create().OfType(CarType.Sedan).WithWheelSizeOf(16).Build();

            Console.WriteLine($"Car with:\n-Cartype:{car.CarType}\n-WheelSize:{car.WheelSize}");

            //-------------------Facetted Person Builder-------------------
            var pb = new PersonFaccettedBuilder();
            var person = pb
                .Works()
                    .At("CubeRM")
                    .AsA("Backend Developer")
                    .Earning(1500)
                .Lives()
                    .In("Thessaloniki")
                    .At("Antisthenous 25")
                    .WithPostCode("54250")
                .Build();
            Console.WriteLine(person);

            //-------------------Exercice Code Builder-------------------
            var codeBuilder = new CodeBuilder("Person").AddField("Name","string").AddField("Age","int");
            Console.WriteLine(codeBuilder);

        }


        public class Person
        {
            public string Name, Position;
        }

        public sealed class PersonBuilder
        {
            public readonly List<Action<Person>> Actions
              = new List<Action<Person>>();

            public PersonBuilder Called(string name)
            {
                Actions.Add(p => { p.Name = name; });
                return this;
            }

            public Person Build()
            {
                var p = new Person();
                Actions.ForEach(a => a(p));
                return p;
            }
        }

        

    }
}

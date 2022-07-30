using Autofac;

namespace Mediator
{


    /// <summary>
    /// A component that facilitates communication  between other components
    /// without them necessarily being aware of each other or having direct
    /// (reference) access to each other,
    /// Real world analogy is a Control tower for airplanes.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //------------------- ChatRoom Mediator -------------------
            var room = new ChatRoom();


            var martin = new Person("Martin");
            var john = new Person("John");
            var helen = new Person("Helen");

            room.Join(martin);
            room.Join(john);

            john.Say("hi!");
            martin.Say("hello!");

            room.Join(helen);
            helen.Say("Hey there everyone!");

            martin.PrivateMessage("Helen", "Glad you are here!");

            //------------------- Event Broker -------------------

            var cb = new ContainerBuilder();
            cb.RegisterType<EventBroker>().SingleInstance();
            cb.RegisterType<FootballCoach>();
            cb.Register((c, p) =>
                new FootballPlayer(
                    c.Resolve<EventBroker>(),
                    p.Named<string>("name")
                ));

            using (var c = cb.Build())
            {
                var coach = c.Resolve<FootballCoach>();

                var player1 = c.Resolve<FootballPlayer>(new NamedParameter("name", "Martin"));
                var player2 = c.Resolve<FootballPlayer>(new NamedParameter("name", "Stratis"));
                var player3 = c.Resolve<FootballPlayer>(new NamedParameter("name", "Irena"));

                player1.Score();
                player1.Score();
                player1.Score();
                player1.AssaultReferee();
                player2.Score();
            }
        }
    }
}
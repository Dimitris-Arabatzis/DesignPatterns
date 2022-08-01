using Autofac;
using MediatR;

namespace MediatorDP
{


    /// <summary>
    /// A component that facilitates communication  between other components
    /// without them necessarily being aware of each other or having direct
    /// (reference) access to each other,
    /// Real world analogy is a Control tower for airplanes.
    /// </summary>
    internal class Program
    {
        static async Task Main(string[] args)
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

            //------------------- MediatR -------------------

            var builder = new ContainerBuilder();
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.RegisterAssemblyTypes(typeof(Program).Assembly).AsImplementedInterfaces();

            var container = builder.Build();
            var mediator = container.Resolve<IMediator>();

            var response = await mediator.Send(new PingCommand());

            Console.WriteLine($"We got a response at {response.TimeStamp}");

            //------------------- Exercise -------------------
            var exerciseMediator = new Coding.Exercise.Mediator();

            var participant1 = new Coding.Exercise.Participant(exerciseMediator);
            var participant2 = new Coding.Exercise.Participant(exerciseMediator);

            Console.WriteLine($"Participant 1: {participant1.Value}");
            Console.WriteLine($"Participant 2: {participant2.Value}");

            participant1.Say(3);
            Console.WriteLine($"Participant 1: {participant1.Value}");
            Console.WriteLine($"Participant 2: {participant2.Value}");

            participant2.Say(2);
            Console.WriteLine($"Participant 1: {participant1.Value}");
            Console.WriteLine($"Participant 2: {participant2.Value}");


        }
    }
}
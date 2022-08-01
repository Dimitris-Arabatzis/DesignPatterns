using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDP
{

    public class Actor
    {
        protected EventBroker broker;

        public Actor(EventBroker broker)
        {
            this.broker = broker;
        }
    }

    public class FootballPlayer : Actor
    {
        public string Name { get; set; }
        public int GoalsScored { get; set; }
        public FootballPlayer(EventBroker broker, string name) : base(broker)
        {
            this.Name = name ?? throw new ArgumentNullException(paramName: nameof(name));

            broker.OfType<PlayerScoredEvent>()
                .Where(ps => !ps.Name.Equals(Name))
                .Subscribe(ps =>
                {
                    Console.WriteLine($"{Name}: Niiiice {ps.Name}!! It's your {ps.GoalsScored} goal!");
                });

            broker.OfType<PlayerSentOffEvent>()
                .Where(ps => !ps.Name.Equals(Name))
                .Subscribe(ps =>
                {
                    Console.WriteLine($"{Name}: See you in the lockers {ps.Name}");
                });
        }

        public void Score()
        {
            GoalsScored++;
            broker.Publish(new PlayerScoredEvent { Name = this.Name, GoalsScored = this.GoalsScored });
        }

        public void AssaultReferee()
        {
            broker.Publish(new PlayerSentOffEvent { Name = this.Name, Reason = "violence" });
        }
    }

    public class FootballCoach : Actor
    {
        public FootballCoach(EventBroker broker) : base(broker)
        {
            broker.OfType<PlayerScoredEvent>()
                .Subscribe(pe =>
                {
                    if (pe.GoalsScored < 3)
                        Console.WriteLine($"Coach: Well done, {pe.Name}");
                });

            broker.OfType<PlayerSentOffEvent>()
                .Subscribe(pe =>
                {
                    if(pe.Reason == "violence")
                        Console.WriteLine($"Coach: Why did you do that, {pe.Name}?");

                });
        }
    }

    public class PlayerEvent
    {
        public string Name { get; set; }

    }

    public class PlayerScoredEvent : PlayerEvent
    {
        public int GoalsScored { get; set; }
    }
    public class PlayerSentOffEvent : PlayerEvent
    {
        public string Reason { get; set; }
    }

    public class EventBroker : IObservable<PlayerEvent>
    {
        Subject<PlayerEvent> subscriptions = new Subject<PlayerEvent>();

        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
            return subscriptions.Subscribe(observer);
        }

        public void Publish(PlayerEvent pe)
        {
            subscriptions.OnNext(pe);
        }
    }
}

using System;

namespace Coding.Exercise
{

    /// <summary>
    /// Our system has any number of instances of Participant  classes. Each Participant has a Value integer, initially zero.
    ///
    ///A participant can Say()  a particular value, which is broadcast to all other participants.At this point in time, 
    ///every other participant is obliged to increase their Value by the value being broadcast.
    ///Example:
    ///Two participants start with values 0 and 0 respectively
    ///Participant 1 broadcasts the value 3. We now have Participant 1 value = 0, Participant 2 value = 3
    ///Participant 2 broadcasts the value 2. We now have Participant 1 value = 2, Participant 2 value = 3
    /// </summary>
    public class Participant
    {
        public int Value { get; set; }
        private readonly Mediator _mediator;

        public Participant(Mediator mediator)
        {
            _mediator = mediator;
            _mediator.participants.Add(this);
            Value = 0;
        }

        public void Say(int n)
        {
            _mediator.Broadcast(this,n);
        }
    }

    public class Mediator
    {
        public List<Participant> participants { get; set; }

        public Mediator()
        {
            this.participants = new List<Participant>();
        }

        public void Broadcast(Participant p, int value)
        {

            foreach (var participant in participants.Where(x => !x.Equals(p)))
            {
                participant.Value = value;
            }
        }


    }
}

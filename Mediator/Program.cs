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

            
        }
    }
}
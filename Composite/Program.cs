namespace Composite
{
    internal class Program
    {
        /// <summary>
        /// A mechanism for treating individual objects and composition of objects in a uniform manner.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //---------------------Simple Composite---------------------
            var drawing = new GraphicObject { Name = "My Drawing" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Circle { Color = "Yellow" });

            var group = new GraphicObject {};
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            drawing.Children.Add(group);

            Console.WriteLine(drawing);

            //---------------------Implementation of Composite in NeuralNetworks---------------------
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            neuron1.ConnectTo(neuron2);

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);

        }
    }
}
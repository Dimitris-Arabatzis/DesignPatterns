using Autofac;
using Autofac.Features.Metadata;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static System.Console;

namespace Adapter
{
    /// <summary>
    /// A construct which adapts an existing interface X to conform to the required interface Y.
    /// (Getting the interface you want given the interface you have.)
    /// </summary>
    internal class Program
    {
        private static readonly List<VectorObject> vectorObjects
            = new List<VectorObject>()
            {
                new VectorRectangle(1,1,10,10),
                new VectorRectangle(3,3,6,6)
            };

        static void Main(string[] args)
        {
            //---------------------Simple Adapter---------------------
            Draw();
            //---------------------Adapter in DI---------------------

            var b = new ContainerBuilder();
            b.RegisterType<SaveCommand>().As<ICommand>().WithMetadata("Name", "Save");
            b.RegisterType<OpenCommand>().As<ICommand>().WithMetadata("Name", "Open");
            //b.RegisterType<Button>();
            //b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd));
            b.RegisterAdapter<Meta<ICommand>, Button>(cmd => 
                new Button(cmd.Value, (string)cmd.Metadata["Name"]));
            b.RegisterType<Editor>();

            using (var c = b.Build())
            {
                var editor = c.Resolve<Editor>();
                //editor.ClickAll();
                foreach (var btn in editor.Buttons)
                    btn.PrintMe();
            }
        }

        private static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }

        public static void DrawPoint(Point p)
        {
            Write(".");
        }
    }
}
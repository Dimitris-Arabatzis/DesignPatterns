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
        

        static void Main(string[] args)
        {
            //---------------------Simple Adapter---------------------
            AdapterExecutor.Draw();
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
    }
}
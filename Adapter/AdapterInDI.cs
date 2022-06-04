using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface ICommand
    {
        public void Execute();
    }

    public class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving file!..");
        }
    }
    public class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening file!..");
        }
    }

    public class Button
    {
        private ICommand _command;
        private string name;

        public Button(ICommand command, string name)
        {
            _command = command;
            this.name = name;
        }

        public void Click()
        {
            _command.Execute();
        }

        public void PrintMe()
        {
            Console.WriteLine($"I am a button called {name}");
        }
    }

    public class Editor
    {
        IEnumerable<Button> buttons;
        public IEnumerable<Button> Buttons => buttons;

        public Editor(IEnumerable<Button> buttons)
        {
            this.buttons = buttons;
        }

        public void ClickAll()
        {
            foreach (var btn in buttons)
                btn.Click();
        }

    }
}

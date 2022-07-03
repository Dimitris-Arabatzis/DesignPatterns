using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    internal class Token
    {
        public enum Type
        {
            Integer, Plus, Minus, Lparen, Rparen
        }

        public Type MyType;
        public string Text;

        public Token(Type myType, string text)
        {
            MyType = myType;
            Text = text;
        }

        public override string? ToString()
        {
            return $"`{Text}`";
        }
    }
}

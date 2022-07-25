using System;
using System.Text;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            Value = value;
        }
    }

    public class Memento
    {
        public List<Token> Tokens = new List<Token>();
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public Memento AddToken(int value)
        {
            return AddToken(new Token(value));
        }

        public Memento AddToken(Token token)
        {
            Tokens.Add(token);
            var m = new Memento();
            m.Tokens = Tokens.Select(t => new Token(t.Value)).ToList();
            return m;
        }

        public void Revert(Memento m)
        {
            Tokens = m.Tokens.Select(mm => new Token(mm.Value)).ToList();
        }
    }
}


using Interpreter;
using System.Text;
using static System.Console;

namespace Command
{
    internal class Program
    {
        /// <summary>
        /// Turning strings into OOP based structures in a complicated process.
        /// A component that processes structured text data.
        /// Does so by turning it into seperate lexical tokens (lexing)
        /// and then interpreting sequences of said tokens (parsing).
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //-------------------Lexing-------------------
            string input = "(13+4)-(12+1)";
            var tokens = Lex(input);
            WriteLine(String.Join("\t", tokens));
        }

        static List<Token> Lex(string input)
        {
            var result = new List<Token>();
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                        result.Add(new Token(Token.Type.Plus, "+"));
                        break;
                    case '-':
                        result.Add(new Token(Token.Type.Minus, "-"));
                        break;
                    case '(':
                        result.Add(new Token(Token.Type.Lparen, "("));
                        break;
                    case ')':
                        result.Add(new Token(Token.Type.Rparen, ")"));
                        break;
                    default:
                        var sb = new StringBuilder(input[i].ToString());
                        for (int j = i+1; j < input.Length; ++j)
                        {
                            if (char.IsDigit(input[j]))
                            {
                                sb.Append(input[j]);
                                ++i;
                            }
                            else
                            {
                                result.Add(new Token(Token.Type.Integer, sb.ToString()));
                                break;
                            }
                        }
                        break;
                }
            }
            return result;
        }
    }
}
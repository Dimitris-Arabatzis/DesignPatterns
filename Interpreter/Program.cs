using Interpreter;
using Interpreter.Exercise;
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
            //-------------------Parsing-------------------
            var parsed = Parse(tokens);
            WriteLine($"{input} = {parsed.Value}");
            //-------------------Exercise-------------------
            var ep = new ExpressionProcessor();
            ep.Variables.Add('x', 5);
            WriteLine(ep.Calculate("1+x"));
        }


        static IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            bool haveLHS = false;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                switch (token.MyType)
                {
                    case Token.Type.Integer:
                        var integer = new Integer(int.Parse(token.Text));
                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }
                        break;
                    case Token.Type.Plus:
                        result.MyType = BinaryOperation.Type.Addition;
                        break;
                    case Token.Type.Minus:
                        result.MyType = BinaryOperation.Type.Subtraction;
                        break;
                    case Token.Type.Lparen:
                        int j = i;
                        for (; j < tokens.Count; ++j)
                            if (tokens[j].MyType == Token.Type.Rparen)
                                break;
                        var subExpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                        var element = Parse(subExpression);
                        if (!haveLHS)
                        {
                            result.Left = element;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = element;
                        }
                        i = j;
                        break;
                    case Token.Type.Rparen:
                        break;
                    default:
                        break;
                }
            }
            return result;
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
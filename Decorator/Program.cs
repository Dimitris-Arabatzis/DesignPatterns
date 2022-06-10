namespace Decorator
{
    internal class Program
    {
        /// <summary>
        /// The purpose of the pattern is to add functionality to an object withoud altering the code or rewriting the class. (Open-closed principle).
        /// It keeps new functionality separate (Single Resp. Principle)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //---------------------Custom String Builder---------------------
            var cb = new CodeBuilder();
            cb.AppendLine("class Foo")
              .AppendLine("{")
              .AppendLine("}");
            Console.WriteLine(cb);

            //---------------------Adapter Decorator---------------------

            MyStringBuilder msb = "Hello ";
            msb += "world";
            Console.WriteLine(msb);

        }
    }
}
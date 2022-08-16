namespace Strategy
{
    /// <summary>
    /// Enables the exact behavior of a system to be selected either at run-time (dynamic)
    /// or at compile-time (static).
    /// 
    /// Also known as policy in the C++ world.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //--------------------- Dynamic Strategy ---------------------
            var tp = new DynamicTextProcessor();
            tp.SetOutputFormat(OutputFormat.Markdown);
            tp.AppendList(new[] { "Dimitris", "Martin", "Arabatzis" });
            Console.WriteLine(tp);

            tp.Clear();

            tp.SetOutputFormat(OutputFormat.Html);
            tp.AppendList(new[] { "Dimitris", "Martin", "Arabatzis" });
            Console.WriteLine(tp);

            //--------------------- Static Strategy ---------------------
            var tp1 = new StaticTextProcessor<MarkdownListStrategy>();
            tp1.AppendList(new[] { "Arabatzis", "Martin", "Dimitris" });
            Console.WriteLine(tp1);

            var tp2 = new StaticTextProcessor<HtmlListStrategy>();
            tp2.AppendList(new[] { "Arabatzis", "Martin", "Dimitris" });
            Console.WriteLine(tp2);

        }
    }
}
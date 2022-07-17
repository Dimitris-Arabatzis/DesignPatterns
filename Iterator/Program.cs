namespace Iterator
{
    internal class Program
    {
        /// <summary>
        /// An object (or in .Net a method) that facilitates the traversal of a data structure.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //------------------- Iterator Object -------------------
            //   1
            //  / \
            // 2   3

            //in-order: 2,1,3
            //preorder: 1,2,3
            var root = new Node<int>(1,
                new Node<int>(2),
                new Node<int>(3)
                );

            var it = new InOrderIterator<int>(root);
            while (it.MoveNext())
            {
                Console.Write(it.Current.Value);
                Console.Write(',');
            }
            Console.WriteLine();

            //------------------- Iterator Method-------------------
            var tree = new BinaryTree<int>(root);
            Console.WriteLine(string.Join(",", tree.InOrder.Select(x=>x.Value)));

        }
    }
}
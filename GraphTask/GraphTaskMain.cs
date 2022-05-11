namespace GraphTask
{
    public class GraphTaskMain
    {
        static void Main()
        {
            Graph graph = new Graph(new int[8,8]);

            graph.ConnectVertexes(0, 1);
            graph.ConnectVertexes(2, 1);
            graph.ConnectVertexes(3, 1);
            graph.ConnectVertexes(4, 1);
            graph.ConnectVertexes(5, 1);
            graph.ConnectVertexes(2, 6);

            Action<int> action = (x) =>
            {
                Console.Write(x);
                Console.Write(", ");
            };

            graph.BypassByWidth(action);
            Console.WriteLine();

            graph.BypassByDeep(action);
            Console.WriteLine();

            graph.BypassByRecursiveDeep(action);
        }
    }
}
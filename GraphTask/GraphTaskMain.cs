namespace GraphTask
{
    public class GraphTaskMain
    {
        static void Main()
        {
            Graph graph = new(7);

            graph.ConnectPeeks(0, 1);
            graph.ConnectPeeks(1, 2);
            graph.ConnectPeeks(1, 3);
            graph.ConnectPeeks(1, 4);
            graph.ConnectPeeks(1, 5);
            graph.ConnectPeeks(2, 6);

            Console.WriteLine(graph.BypassByDeep());
        }
    }
}
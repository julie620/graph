public class Test {
    public static void Main(String[] args) {
        Graph graph = new Graph(5);

        graph.AddVertex(0, new Vertex("A"));
        graph.AddVertex(1, new Vertex("B"));
        graph.AddVertex(2, new Vertex("C"));
        graph.AddVertex(3, new Vertex("D"));
        graph.AddVertex(4, new Vertex("E"));

        graph.AddEdge(0, 2, 1);
        graph.AddEdge(0, 3, 1);
        graph.AddEdge(2, 3, 1);
        graph.AddEdge(2, 1, 1);
        graph.AddEdge(1, 4, 1);

       
        graph.BreadthFirstSearch(0);
    }
}
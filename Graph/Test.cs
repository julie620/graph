/*
 * Author: Juliana Serrano
 * Last Modified: 03/07/2025
 * Lab 6: Hashing
 * The Test class contains a main method with a test graph and traversals
*/

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

        Console.WriteLine("Depth First Search");
        graph.DepthFirstSearch(0);
        Console.WriteLine("Breadth First Search");
        graph.BreadthFirstSearch(0);
    }
}
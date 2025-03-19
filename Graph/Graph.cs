/*
 * Author: Juliana Serrano
 * Last Modified: 03/15/2025
 * Graph
 * The Graph class contains methods to create and traverse graph
*/

using System.Diagnostics;

public class Graph {
    
    private int [,] matrix; // adjaceny matrix
    private Vertex[] vertices; //array of added vertices
    private List<Vertex> visitedVertices; // for traversals
    private int edgeNum;

    public Graph(int size) {
        matrix = new int[size, size];
        vertices = new Vertex[size];
        edgeNum = 0;
    }

    public int VertexCount() {
        return vertices.Length;
    }

    public int EdgeCount() {
        return edgeNum;
    }

    public string GetValue(int index)  {
        return vertices[index].GetData();
    }

    public Vertex GetVertex(int index) {
        return vertices[index];
    }

    public void AddVertex(int index, Vertex vertex) {
        vertices[index] = vertex;
        vertex.SetIndex(index);
    }

    public void AddEdge(int start, int end, int weight) {
        if (weight == 0) { // will not edge with with weight of 0
            return;
        }
        if (matrix[start, end] == 0) { //counts new edge if edge does not exist
            edgeNum++;
        }
        matrix[start, end] = weight;
    }

    public int Weight(int start, int end) {
        return matrix[start, end];
    }

    public void RemoveEdge(int start, int end) {
        if (matrix[start, end] == 0) {
            matrix[start, end] = 0;
            edgeNum--;
        }
    }

    public bool HasEdge(int start, int end) {
        return matrix[start, end] != 0;
    }

    public int[] GetNeighbors(int verticesIndex) {
        int count = 0;
        int[] temp;
        //gets number of neighbors 
        for (int i = 0; i < vertices.Length; i++) {
            if (matrix[verticesIndex, i] != 0) {
                count++;
            }
        }
        temp = new int[count];
        count = 0;
        //adds index numbers of neighoboring vertices into temp array
        for (int i = 0; i < vertices.Length; i++) {
            if (matrix[verticesIndex, i] != 0) {
                temp[count++] = i;;
            }
        }
        return temp;
    }

    // sets up List to track visited vertices during traversals
    public List<Vertex> GetVisitedList(int start) {
        visitedVertices = new List<Vertex>();
        visitedVertices.Add(vertices[start]);
        return visitedVertices;
    }

    //traverses all adjacent vertices and reachable vertices
    public void DepthFirstSearch(int start) {
        visitedVertices = GetVisitedList(start);
        Console.WriteLine(vertices[start].GetData());

        foreach (int index in GetNeighbors(start)) {
            Vertex neighbor = vertices[index];
            
            if (!visitedVertices.Contains(neighbor)) {
                visitedVertices.Add(neighbor);
                DepthFirstSearch(index);
            }
        }
    }

    // traverses all adjacent vertices than the adjacent vertices of those vertices
    public void BreadthFirstSearch(int start) {
        visitedVertices = GetVisitedList(start);
        Queue<Vertex> vertexQueue = new Queue<Vertex>();
        vertexQueue.Enqueue(vertices[start]);
        while (vertexQueue.Count != 0) {
            Vertex current = vertexQueue.Dequeue();
            Console.WriteLine(current.GetData());

            foreach (int index in GetNeighbors(current.GetIndex())) {
                Vertex neighbor = vertices[index];
                if (!visitedVertices.Contains(neighbor)) {
                    visitedVertices.Add(neighbor);
                    vertexQueue.Enqueue(neighbor);
                }
            }
        }   
    }

    //prints out adjacency matrix
    public void PrintMatrix() {
        Console.Write("  ");
        foreach (Vertex vertex in vertices) {
            Console.Write(vertex.GetData() + " ");
        }
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(1); i++) {
            Console.Write(vertices[i].GetData() + " ");
            for (int j = 0; j < matrix.GetLength(0); j++) {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
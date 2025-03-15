public class Graph {
    
    private int [,] matrix;
    private Vertex[] vertices;
    private int edgeNum;

    public Graph(int size) {
        matrix = new int[size, size];
        vertices = new Vertex[size];
        edgeNum = 0;
    }

    public int NodeCount() {
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
    }

    public void AddEdge(int start, int end, int weight) {
        if (weight == 0) {
            return;
        }
        if (matrix[start, end] == 0) {
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

    public int[] GetNeighbors(int start) {
        int count = 0;
        int[] temp;

        for (int i = 0; i < vertices.Length; i++) {
            if (matrix[start, i] != 0) {
                count++;
            }
        }
        temp = new int[count];
        count = 0;
        for (int i = 0; i < vertices.Length; i++) {
            if (matrix[start, i] != 0) {
                temp[count++] = i;;
            }
        }
        return temp;
    }

    public void DepthFirstSearch(int start, List<Vertex> visitedVertices) {
        Console.WriteLine(vertices[start].GetData());

        foreach (int index in GetNeighbors(start)) {
            Vertex neighbor = vertices[index];
            
            if (!visitedVertices.Contains(neighbor)) {
                visitedVertices.Add(neighbor);
                DepthFirstSearch(index, visitedVertices);
            }
        }
    }

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
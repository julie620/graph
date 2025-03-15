public class Graph {
    
    private int [,] matrix;
    private Vertex[] vertexes;
    private int edgeNum;

    public Graph(int size) {
        matrix = new int[size, size];
        vertexes = new Vertex[size];
        edgeNum = 0;
    }

    public int NodeCount() {
        return vertexes.Length;
    }

    public int EdgeCount() {
        return edgeNum;
    }

    public string GetValue(int index)  {
        return vertexes[index].GetData();
    }

    public void AddVertex(int index, Vertex vertex) {
        vertexes[index] = vertex;
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

    public int[] Neighbors(int start) {
        int count = 0;
        int[] temp;

        for (int i = 0; i < vertexes.Length; i++) {
            if (matrix[start, i] != 0) {
                count++;
            }
        }
        temp = new int[count];
        count = 0;
        for (int i = 0; i < vertexes.Length; i++) {
            if (matrix[start, i] != 0) {
                temp[count++] = i;;
            }
        }
        return temp;
    }

    public void PrintMatrix() {
        Console.Write("  ");
        foreach (Vertex vertex in vertexes) {
            Console.Write(vertex.GetData() + " ");
        }
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(1); i++) {
            Console.Write(vertexes[i].GetData() + " ");
            for (int j = 0; j < matrix.GetLength(0); j++) {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
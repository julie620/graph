/*
 * Author: Juliana Serrano
 * Last Modified: 03/15/2025
 * Graph
 * The Vertex class allows for a vertex/node to be created and provides getters and setters
*/

public class Vertex{
    private string data;
    private int index;

    public Vertex(string data) {
        this.data = data;
    }

    public string GetData() {
        return data;
    }

    public void SetIndex(int index) {
        this.index = index;
    }

    public int GetIndex() {
        return index;
    }
}
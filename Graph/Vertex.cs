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
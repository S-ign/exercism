public class Matrix
{
    private List<List<int>> matrix = new List<List<int>>();

    public Matrix(string input) =>
        matrix = input.Split('\n').Select(row => row.Split().Select(int.Parse).ToList()).ToList();

    public int[] Row(int row) => matrix[row-1].ToArray();

    public int[] Column(int col) => matrix.Select(row => row[col-1]).ToArray();
}

public class Day12
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllLines(inputPath);

        var inputGrid = text.Select(line => line.ToCharArray()).ToArray();

        var n = inputGrid.Length;
        var m = inputGrid[0].Length;

        var start = (-1, -1);
        var end = (-1, -1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                char c = inputGrid[i][j];
                if (c == 'S')
                {
                    start = (i, j);
                }
                if (c == 'E')
                {
                    end = (i, j);
                }
            }
        }

        var visited = new int[n, m];

        var elements = new List<(int, int, int)>
        {
            (0, end.Item1, end.Item2)
        };


        while (true)
        {
            var tuple = elements.ElementAt(0);
            elements.RemoveAt(0);
            int steps = tuple.Item1;
            int i = tuple.Item2;
            int j = tuple.Item3;

            if (visited[i,j] == 1)
            {
                continue;
            }
            visited[i,j] = 1;

            if (Height(inputGrid[i][j]) == 0)
            {
                Console.WriteLine("STEPS: " + steps);
                break;
            }

            foreach ((int, int) coord in ExploreNeighbors(i, j))
            {
                int ii = coord.Item1;
                int jj = coord.Item2;
                elements.Add((steps + 1, ii, jj));
            }
        }

        int Height(char c)
        {
            if (c == 'S') return 0;
            else if (c == 'E') return 25;
            else return (int)c - 97;
        }

        IEnumerable<(int, int)> ExploreNeighbors(int x, int y)
        {
            var directions = new (int X, int Y)[4] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            foreach (var direction in directions)
            {
                int newX = x + direction.X;
                int newY = y + direction.Y;

                if (!((0 <= newX && newX < n) && (0 <= newY && newY < m)))
                    continue;

                if (Height(inputGrid[newX][newY]) >= Height(inputGrid[x][y]) - 1)
                    yield return (newX, newY);
            }
        }


        Console.ReadLine();
    }
}

public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Elevation { get; set; }
}
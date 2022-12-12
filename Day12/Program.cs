public class Day12
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllLines(testInputPath);

        var inputGrid = text.Select(line => line.ToCharArray()).ToArray();

        var length = inputGrid.Count(); //x
        var height = inputGrid.First().Count(); //y

        int startX = 0, startY = 0, endX = 0, endY = 0;

        for(var i = 0; i < length; i++)
        {
            for (var j = 0; j < height; j++)
            {
                if (inputGrid[i][j] == 'S')
                {
                    startX = i;
                    startY = j;
                }
                else if (inputGrid[i][j] == 'E')
                {
                    endX = i;
                    endY = j;
                }
            }
        }

        //TODO check if in bounds
        (int, int) ExploreNeighbours(int x, int y)
        {
            var validMovements = new (int X, int Y)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            foreach (var item in validMovements)
            {
                var newX = x + item.X;
                var newY = y + item.Y;

                if (GetHeightOfCharacter(inputGrid[newX][newY]) <= GetHeightOfCharacter(inputGrid[x][y]) + 1)
                    return (newX, newY);
            }
            return (-1, -1);
        }

        int GetHeightOfCharacter(char c)
        {
            if (c == 'S') return 0;
            else if (c == 'E') return 25;
            else return (int)c - 97;
        }

        Console.ReadLine();
    }
}
public class Day12
{
    public static void Main()
    {
        Console.WriteLine("Hello world!");
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

        

        Console.ReadLine();
    }
}
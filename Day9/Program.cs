using System.ComponentModel;
using System.Text.RegularExpressions;

public class Position
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;

    public Position() { }

    public void Reposition(string direction)
    {
        if (direction == "U") Y ++;
        else if (direction == "D") Y --;
        else if (direction == "L") X --;
        else if (direction == "R") X ++;
    }

    public void FollowHead(Position posToFollow)
    {
        if (Math.Abs(posToFollow.X - X) > 1 || Math.Abs(posToFollow.Y - Y) > 1)
        {
            
            X += (posToFollow.X - X).CompareTo(0);
            Y += (posToFollow.Y - Y).CompareTo(0);
        }
    }
}


public class Day3
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllLines(inputPath);

        var tailVisited = new List<string>();

        var head = new Position();
        var tail = new Position();

        foreach (var line in text)
        {
            var direction = line.Split(" ")[0];
            var amount = int.Parse(line.Split(" ")[1]);

            for (int i = 0; i < amount; i++)
            {
                head.Reposition(direction);

                tail.FollowHead(head);
                tailVisited.Add($"{tail.X}-{tail.Y}");
            }
        }
        Console.WriteLine("TAIL VISITED: " + tailVisited.Distinct().Count());

        Console.ReadKey();
    }
}
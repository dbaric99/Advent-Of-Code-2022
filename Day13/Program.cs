using System.Security.Cryptography;

public class Day7
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllLines(testInputPath).Where(line => !string.IsNullOrEmpty(line));

        var allPairs = new List<Pair>();

        for (int i = 0; i < text.Count(); i+=2)
        {
            allPairs.Add(new Pair(text.ElementAt(i), text.ElementAt(i + 1)));
        }

        foreach (var item in allPairs)
        {
            Console.WriteLine($"LEFT: {item.Left}\tRIGHT: {item.Right}");
        }

        Console.ReadLine();
    }
}

public class Pair
{
    public string Left { get; set; }
    public string Right { get; set; }

    public Pair(string left, string right)
    {
        Left = left.Substring(1, left.Length - 2);
        Right = right.Substring(1, right.Length - 2);
    }
}

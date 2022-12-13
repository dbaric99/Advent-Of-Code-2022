using System.Collections;
using System.Security.Cryptography;
using System.Text.Json.Nodes;

public class Day7
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllLines(inputPath).Where(line => !string.IsNullOrEmpty(line));

        var allPairs = new List<Pair>();
        var pairCounter = 1;
        for (int i = 0; i < text.Count(); i+=2)
        {
            allPairs.Add(new Pair(text.ElementAt(i), text.ElementAt(i + 1), pairCounter));
            
            pairCounter++;
        }

        var sum = 0;
        var counter = 1;
        foreach (var item in allPairs)
        {
            if (Pair.Compare(item) < 0)
                sum += counter;

            counter++;
        }

        Console.WriteLine("ITEMS IN ORDER: " + sum); //6623

        Console.ReadLine();
    }
}

public class Pair
{

    public JsonNode Left { get; set; }
    public JsonNode Right { get; set; }
    public int Index { get; set; } = 0;

    public Pair(string left, string right)
    {
        Left = JsonValue.Parse(left);
        Right = JsonNode.Parse(right);
    }

    public Pair(string left, string right, int index)
    {
        Left = JsonValue.Parse(left);
        Right = JsonNode.Parse(right);
        Index = index;
    }

    public static int Compare(Pair pairToCompare)
    {
        var left = pairToCompare.Left;
        var right = pairToCompare.Right;

        if (left is JsonValue && right is JsonValue)
        {
            return (int)left - (int)right;
        }
        else
        {
            var leftArr = left as JsonArray;
            var rightArr = right as JsonArray;

            if (left is not JsonArray)
                leftArr = new JsonArray((int)left);
            if (right is not JsonArray)
                rightArr = new JsonArray((int)right);

            for (int i = 0; i < leftArr.Count && i < rightArr.Count; i++)
            {
                int comparison = Compare(new Pair(leftArr[i].ToString(), rightArr[i].ToString()));
                if (comparison != 0)
                {
                    return comparison;
                }
            }
            return leftArr.Count - rightArr.Count;
        }
    }
}

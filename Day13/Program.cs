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

        var counter = 0;

        foreach (var item in allPairs)
        {
            if (Pair.Compare(item) > 0)
                counter += (allPairs.IndexOf(item) + 1);
        }

        Console.WriteLine("ITEMS IN ORDER: " + counter);

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


            var result = 0;
            var i = 0;
            foreach (var l in leftArr)
            {
                if (i >= 0 && i < rightArr.Count())
                {
                    var r = rightArr[i];
                    result = Compare(new Pair(l.ToString(), r.ToString()));
                    if (result != 0)
                    {
                        break;
                    }
                }
                i++;
            }



            return result == 0 ? leftArr.Count - rightArr.Count : pairToCompare.Index;
        }
    }
}

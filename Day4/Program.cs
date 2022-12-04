public class Day3
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllText(inputPath);

        var pairs = text.Split("\n");

        int counter = 0;

        foreach (var p in pairs)
        {
            var pair = p.Split(",");

            var firstElfRange = pair[0].Split("-").Select(Int32.Parse).ToArray();
            var secondElfRange = pair[1].Split("-").Select(Int32.Parse).ToArray();

            var firstList = Enumerable.Range(firstElfRange[0], firstElfRange[1] - firstElfRange[0] +1).ToList();
            var secondList = Enumerable.Range(secondElfRange[0], secondElfRange[1] - secondElfRange[0]+1).ToList();

            if (firstList.Intersect(secondList).Any())
                counter++;
        }

        Console.WriteLine("COUNTER: " + counter);

        Console.ReadKey();
    }
}
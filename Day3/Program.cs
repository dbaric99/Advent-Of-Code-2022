public class Day3
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllText(inputPath);

        var textInputByLines = text.Split("\n");

        var priority = 0;

        foreach (var line in textInputByLines)
        {
            var firstRucksack = line.Substring(0, (int)(line.Length / 2));
            var secondRucksack = line.Substring((int)(line.Length / 2), (int)(line.Length / 2));

            firstRucksack = new string(firstRucksack.ToCharArray().Distinct().ToArray());
            secondRucksack = new string(secondRucksack.ToCharArray().Distinct().ToArray());

            foreach (var item in firstRucksack)
            {
                if (secondRucksack.Contains(item))
                    priority += getCharacterValue(item);
            }
        }

        Console.WriteLine("PRIORITY: "+priority);

        int getCharacterValue(char letter)
        {
            if (Char.IsUpper(letter))
            {
                return (int)letter - 38;
            }
            return (int)letter - 96;
        }

        Console.ReadKey();
    }
}
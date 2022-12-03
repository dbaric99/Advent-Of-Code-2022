public class Day3
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllText(inputPath);

        var textInputByLines = text.Split("\n");

        var priority = 0;

        for (int i = 0; i < textInputByLines.Length; i+=3)
        {
            var firstElf = new string(textInputByLines[i].ToCharArray().Distinct().ToArray());
            var secondElf = new string(textInputByLines[i + 1].ToCharArray().Distinct().ToArray());
            var thirdElf = new string(textInputByLines[i + 2].ToCharArray().Distinct().ToArray());

            foreach (var item in firstElf)
            {
                if (secondElf.Contains(item) && thirdElf.Contains(item))
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
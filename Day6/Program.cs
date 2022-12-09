public class Day6
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllText(inputPath);

        const int SIGNAL = 14;

        for (int i = 0; i < text.Length - SIGNAL; i++)
        {
            var past = text.Substring(i, SIGNAL);
            if (past.Length == past.Distinct().Count())
            {
                Console.WriteLine(i+SIGNAL);
                break;
            }
        }

        Console.ReadLine();
    }
}
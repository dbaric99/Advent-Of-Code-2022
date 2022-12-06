using System.Text.RegularExpressions;

public class Day3
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllLines(inputPath);

        List<(int Number, List<string> Crates)> stacks = new List<(int Number, List<string> Crates)>(9)
        {
            (1,new List<string>()),
            (2,new List<string>()),
            (3,new List<string>()),
            (4,new List<string>()),
            (5,new List<string>()),
            (6,new List<string>()),
            (7,new List<string>()),
            (8,new List<string>()),
            (9,new List<string>()),
        };

        foreach (var line in text)
        {
            var crateNumber = 0;
            for (int i = 1; i < line.Length; i+=4)
            {
                var crate = line[i];
                if (crate != ' ' && Char.IsUpper(crate))
                    stacks[crateNumber].Crates.Add(crate.ToString());
                crateNumber++;
            }
            if (line.Contains("move"))
            {
                var move = line.Split(" ");
                var crateToMoveCount= int.Parse(move[1]);
                var moveFrom = int.Parse(move[3]);
                var moveTo = int.Parse(move[5]);

                var cratesToMoveList = stacks.First(x => x.Number == moveFrom).Crates.Take(crateToMoveCount).ToList();

                for (int i = (cratesToMoveList.Count() - 1); i >= 0; i--)
                {
                    stacks.First(x => x.Number == moveTo).Crates.Add(cratesToMoveList[i]);

                }
                stacks.First(x => x.Number == moveFrom).Crates.RemoveAt(0);
            }
        }

        foreach (var stack in stacks)
            Console.Write(stack.Crates.Last());

        Console.ReadKey();
    }
}
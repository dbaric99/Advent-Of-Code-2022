using System.Linq;

public class Day7
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllText(inputPath);

        var monkeys = text.Split("\n\n");

        var listOfMonkeys = new List<Monkey>();

        foreach (var item in monkeys)
        {
            listOfMonkeys.Add(new Monkey(item));
        }

        var fac = listOfMonkeys.Aggregate(1, (long i, Monkey m) => i * m.Test);

        for (long i = 0; i < 10000; i++)
        {
            foreach (var monkey in listOfMonkeys)
            {
                while (monkey.Items.Count() > 0)
                {
                    var currentItem = monkey.Items[0];
                    monkey.Items.RemoveAt(0);

                    var worryIndex = monkey.Operate(currentItem) % fac;

                    var test = worryIndex % monkey.Test == 0;
                    var nextMonkey = test ? monkey.VersionTrue : monkey.VersionFalse;

                    listOfMonkeys[(int)nextMonkey].Items.Add(worryIndex);

                    monkey.Counter++;
                }
            }
        }

        var topMonkey = listOfMonkeys.OrderByDescending(m => m.Counter).Take(2).ToList();

        Console.WriteLine("Monkey 1: " + topMonkey[0].Counter);
        Console.WriteLine("Monkey 2: " + topMonkey[1].Counter);
        Console.WriteLine("\tMult: " + topMonkey[0].Counter * topMonkey[1].Counter);

        Console.ReadLine();
    }
}

public class Monkey
{
    public long MonkeyId { get; set; }

    public List<long> Items { get; set; } = new List<long>();

    public (string Operation, long Factor) Operation { get; set; }

    public long Test { get; set; }

    public long VersionTrue { get; set; }

    public long VersionFalse { get; set; }

    public long Counter { get; set; } = 0;

    public Monkey(string inputToParse)
    {
        var listOfInputs = inputToParse.Split("\n");
        
        MonkeyId = long.Parse(listOfInputs[0].Split(" ")[1].Replace(":",""));

        var startingItems = listOfInputs[1].Replace(",","").Split(" ").ToList();

        startingItems.RemoveRange(0, 2);

        foreach (var item in startingItems)
        {
            Items.Add(long.Parse(item));
        }

        var operationLine = listOfInputs[2].Split(" ").ToList();
        
        Operation = (Operation: operationLine[4], Factor: operationLine[5] == "old" ? 0 : long.Parse(operationLine[5]));

        Test = long.Parse(listOfInputs[3].Split(" ")[3]);

        VersionTrue = long.Parse(listOfInputs[4].Split(" ")[5]);

        VersionFalse = long.Parse(listOfInputs[5].Split(" ")[5]);
    }

    public long Operate(long item)
    {
        var fac = Operation.Factor == 0 ? item : Operation.Factor;

        return Operation.Operation == "*" ? item * fac : item + fac;
    }
}
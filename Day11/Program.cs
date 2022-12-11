using System.Security.Cryptography;

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

        for (int i = 0; i < 20; i++)
        {
            foreach (var monkey in listOfMonkeys)
            {
                while (monkey.Items.Count() > 0)
                {
                    var currentItem = monkey.Items[0];
                    monkey.Items.RemoveAt(0);

                    var worryIndex = monkey.Operate(currentItem) / 3;

                    var test = worryIndex % monkey.Test == 0;
                    var nextMonkey = test ? monkey.VersionTrue : monkey.VersionFalse;

                    listOfMonkeys[nextMonkey].Items.Add(worryIndex);

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
    public int MonkeyId { get; set; }

    public List<int> Items { get; set; } = new List<int>();

    public (string Operation, int Factor) Operation { get; set; }

    public int Test { get; set; }

    public int VersionTrue { get; set; }

    public int VersionFalse { get; set; }

    public int Counter { get; set; } = 0;

    public Monkey(string inputToParse)
    {
        var listOfInputs = inputToParse.Split("\n");
        
        MonkeyId = int.Parse(listOfInputs[0].Split(" ")[1].Replace(":",""));

        var startingItems = listOfInputs[1].Replace(",","").Split(" ").ToList();

        startingItems.RemoveRange(0, 2);

        foreach (var item in startingItems)
        {
            Items.Add(int.Parse(item));
        }

        var operationLine = listOfInputs[2].Split(" ").ToList();
        
        Operation = (Operation: operationLine[4], Factor: operationLine[5] == "old" ? 0 : int.Parse(operationLine[5]));

        Test = int.Parse(listOfInputs[3].Split(" ")[3]);

        VersionTrue = int.Parse(listOfInputs[4].Split(" ")[5]);

        VersionFalse = int.Parse(listOfInputs[5].Split(" ")[5]);
    }

    public int Operate(int item)
    {
        var fac = Operation.Factor == 0 ? item : Operation.Factor;

        return Operation.Operation == "*" ? item * fac : item + fac;
    }
}
using System.Drawing;

public enum opponent
{
    A = 1, //Rock
    B = 2, //Paper
    C = 3//Scissors
    
}

public enum move
{
    X = 1, //Rock
    Y = 2, //Paper
    Z = 3, //Scissors
}

public class Day2
{
    public static void Main()
    {
        var testInputPath = "../../../testInput.txt";
        var inputPath = "../../../input.txt";

        var text = File.ReadAllText(inputPath);

        var strategyGuide = text.Split("\n");


        int score = 0;
        foreach(var res in strategyGuide)
        {
            var oneRound = res.Split(" ");

            int opponentChoice = (int)Enum.Parse(typeof(opponent), oneRound[0]);
            int yourChoice = (int)Enum.Parse(typeof(move), oneRound[1]);

            score += yourChoice;

            if (opponentChoice == yourChoice)
                score += 3;
            else if ((yourChoice == 1 && opponentChoice == 3) || (yourChoice == 2 && opponentChoice == 1) || (yourChoice == 3 && opponentChoice == 2))
            {
                score += 6;
            }
        }

        Console.WriteLine(score);

        Console.ReadKey();
    }
}
using System.Drawing;

public enum opponent
{
    A = 1, //Rock
    B = 2, //Paper
    C = 3//Scissors
    
}

public enum move
{
    X = 0, //Lose
    Y = 3, //Draw
    Z = 6, //Win
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

            switch (opponentChoice)
            {
                case 1:
                    {
                        if (yourChoice == 3)
                        {
                            score += 1;
                        }
                        else if(yourChoice == 6)
                        {
                            score += 2;
                        }
                        else
                        {
                            score += 3;
                        }
                        break;
                    }
                case 2:
                    {
                        if (yourChoice == 3)
                        {
                            score += 2;
                        }
                        else if (yourChoice == 6)
                        {
                            score += 3;
                        }
                        else
                        {
                            score += 1;
                        }
                        break;
                    }
                case 3:
                    {
                        if (yourChoice == 3)
                        {
                            score += 3;
                        }
                        else if (yourChoice == 6)
                        {
                            score += 1;
                        }
                        else
                        {
                            score += 2;
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        Console.WriteLine(score);

        Console.ReadKey();
    }
}
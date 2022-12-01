string exampleInput = File.ReadAllText("../../../testInput.txt");
string inputText = File.ReadAllText("../../../input.txt");

List<int> findElfWithMostCalories(string input)
{
    List<int> calories = new List<int>();
    var elves = input.Split("\n\n").ToList();
    foreach (var item in elves)
    {
        var sum = item.Split("\n").Select(int.Parse).Sum();
        calories.Add(sum);
    }
    calories.Sort((x, y) => y.CompareTo(x));
    return calories;
}

var calories = findElfWithMostCalories(inputText);

//first star
Console.WriteLine("ELF WITH MOST CALORIES: " + calories[0]);

//second star
Console.WriteLine("CALORIES OF FIRST THREE ELVES: " + calories.GetRange(0,3).Sum());

Console.ReadKey();


namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split('\n');
        int sum = 0;
        int counter = 1;
        Dictionary<int, int> ElfCalories = new();

        foreach (var line in lines)
        {
            if (int.TryParse(line, out int number))
            {
                sum += number;
            }
            else
            {
                ElfCalories.Add(counter, sum);
                sum = 0;
                counter++;
            }
        }
        //Part 1
        var max = ElfCalories.MaxBy(kv => kv.Value);
        
        return new($"{max.Value}");
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split('\n');
        int sum = 0;
        int counter = 1;
        Dictionary<int, int> ElfCalories = new();

        foreach (var line in lines)
        {
            if (int.TryParse(line, out int number))
            {
                sum += number;
            }
            else
            {
                ElfCalories.Add(counter, sum);
                sum = 0;
                counter++;
            }
        }

        var sorted = ElfCalories.OrderBy(x => x.Value).Reverse().Take(3).ToList();
        var total = sorted.Sum(x => x.Value);
        return new($"{total}");
    }
}

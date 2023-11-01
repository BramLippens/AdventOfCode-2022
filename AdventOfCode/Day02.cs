namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
    }
    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split('\n');
        int total = 0; int grandTotal = 0;
        char opponent;
        char me;
        int win = 6; int loss = 0; int draw = 3;

        Dictionary<char, Dictionary<char, (int, int)>> opponentValues = new()
            {
                { 'A', new Dictionary<char, (int, int)> { { 'X', (1, draw) }, { 'Y', (2, win) }, { 'Z', (3, loss) } } },
                { 'B', new Dictionary<char, (int, int)> { { 'X', (1, loss) }, { 'Y', (2, draw) }, { 'Z', (3, win) } } },
                { 'C', new Dictionary<char, (int, int)> { { 'X', (1, win) }, { 'Y', (2, loss) }, { 'Z', (3, draw) } } }
            };

        foreach (var line in lines)
        {
            var play = line.Split(" ");
            opponent = play[0].ToCharArray()[0];
            me = play[1].ToCharArray()[0];

            if (opponentValues.ContainsKey(opponent) && opponentValues[opponent].ContainsKey(me))
            {
                var (value, extra) = opponentValues[opponent][me];
                total += value;
                total += extra;
            }

            grandTotal += total;
            total = 0;
        }
        return new($"{grandTotal}");
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split('\n');
        int total = 0; int grandTotal = 0;
        char opponent;
        char me;
        int win = 6; int loss = 0; int draw = 3;

        Dictionary<char, Dictionary<char, (int, int)>> opponentValues = new()
            {
                { 'A', new Dictionary<char, (int, int)> { { 'X', (3, loss) }, { 'Y', (1, draw) }, { 'Z', (2, win) } } },
                { 'B', new Dictionary<char, (int, int)> { { 'X', (1, loss) }, { 'Y', (2, draw) }, { 'Z', (3, win) } } },
                { 'C', new Dictionary<char, (int, int)> { { 'X', (2, loss) }, { 'Y', (3, draw) }, { 'Z', (1, win) } } }
            };

        foreach (var line in lines)
        {
            var play = line.Split(" ");
            opponent = play[0].ToCharArray()[0];
            me = play[1].ToCharArray()[0];

            // Calculate the total based on opponent and me
            if (opponentValues.ContainsKey(opponent) && opponentValues[opponent].ContainsKey(me))
            {
                var (value, extra) = opponentValues[opponent][me];
                total += value;
                total += extra;
            }

            // Update grandTotal and reset total
            grandTotal += total;
            total = 0;


        }
        return new($"{grandTotal}");
    }
}

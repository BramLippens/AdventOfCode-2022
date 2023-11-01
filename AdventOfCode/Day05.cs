namespace AdventOfCode
{
    public class Day05 : BaseDay
    {
        private readonly string _input;

        public Day05()
        {
            _input = File.ReadAllText(InputFilePath);
        }
        public override ValueTask<string> Solve_1()
        {
            var lines = _input.Split('\n');
            var divider = Array.IndexOf(lines, "\r");
            var numberOfStacks = int.Parse(lines[divider - 1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
            var stacks = new Stack<char>[numberOfStacks];

            for (int index = divider - 2; index >= 0; index--)
            {
                var line = lines[index];
                for (int stackIndex = 0; stackIndex < numberOfStacks; stackIndex++)
                {
                    var box = line[stackIndex * 4 + 1];
                    if (char.IsLetter(box))
                    {
                        stacks[stackIndex] ??= new();
                        stacks[stackIndex].Push(box);
                    }
                }

            }
            for (int index = divider + 1; index < lines.Length; index++)
            {
                var instructions = lines[index];
                var parts = instructions.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var amount = int.Parse(parts[1]);
                var from = int.Parse(parts[3]) - 1;
                var to = int.Parse(parts[5]) - 1;

                for (int i = 0; i < amount; i++)
                {
                    stacks[to].Push(stacks[from].Pop());
                }
            }
            var answer = "";
            for (int stackIndex = 0; stackIndex < numberOfStacks; stackIndex++)
            {
                answer += stacks[stackIndex].Peek();
            }
            return new($"{answer}");
        }

        public override ValueTask<string> Solve_2()
        {
            var lines = _input.Split('\n');
            var divider = Array.IndexOf(lines, "\r");
            var numberOfStacks = int.Parse(lines[divider - 1].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Last());
            var stacks = new Stack<char>[numberOfStacks + 1];

            for (int index = divider - 2; index >= 0; index--)
            {
                var line = lines[index];
                for (int stackIndex = 0; stackIndex < numberOfStacks; stackIndex++)
                {
                    var box = line[stackIndex * 4 + 1];
                    if (char.IsLetter(box))
                    {
                        stacks[stackIndex] ??= new();
                        stacks[stackIndex].Push(box);
                    }
                }

            }
            stacks[numberOfStacks] ??= new();
            for (int index = divider + 1; index < lines.Length; index++)
            {
                var instructions = lines[index];
                var parts = instructions.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var amount = int.Parse(parts[1]);
                var from = int.Parse(parts[3]) - 1;
                var to = int.Parse(parts[5]) - 1;
                var placeholder = numberOfStacks;

                for (int i = 0; i < amount; i++)
                {
                    stacks[placeholder].Push(stacks[from].Pop());
                }
                for (int i = 0; i < amount; i++)
                {
                    stacks[to].Push(stacks[placeholder].Pop());
                }
            }
            var answer = "";
            for (int stackIndex = 0; stackIndex < numberOfStacks; stackIndex++)
            {
                answer += stacks[stackIndex].Peek();
            }
            return new($"{answer}");
        }
    }
}
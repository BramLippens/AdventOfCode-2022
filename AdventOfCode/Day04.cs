namespace AdventOfCode
{
    public class Day04 : BaseDay
    {
        private readonly string _input;

        public Day04()
        {
            _input = File.ReadAllText(InputFilePath);
        }
        public override ValueTask<string> Solve_1()
        {
            var lines = _input.Split('\n');
            var count = 0;

            foreach (var item in lines)
            {
                var parts = item.Split(",");
                var elf1 = parts[0].Split("-").Select(e => int.Parse(e)).ToList();
                var elf2 = parts[1].Split("-").Select(e => int.Parse(e)).ToList();

                if ((elf1[0] <= elf2[0] && elf1[1] >= elf2[1]) || (elf2[0] <= elf1[0] && elf2[1] >= elf1[1]))
                {
                    count++;
                }
            }
            return new($"{count}");
        }

        public override ValueTask<string> Solve_2()
        {
            var lines = _input.Split('\n');
            var count = 0;

            foreach (var item in lines)
            {
                var parts = item.Split(",");
                var elf1 = parts[0].Split("-").Select(e => int.Parse(e)).ToList();
                var elf2 = parts[1].Split("-").Select(e => int.Parse(e)).ToList();

                if (elf1[0] <= elf2[0] && (elf1[1] >= elf2[0] || elf2[1] <= elf1[0]))
                {
                    count++;
                }
                else if (elf2[0] <= elf1[0] && (elf2[1] >= elf1[0] || elf1[1] <= elf2[0]))
                {
                    count++;
                }
            }
            return new($"{count}");
        }
    }
}